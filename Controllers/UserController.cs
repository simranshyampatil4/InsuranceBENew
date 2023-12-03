using InsuranceApp.DTO;
using InsuranceApp.Exceptions;
using InsuranceApp.Models;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Claim = System.Security.Claims.Claim;

namespace InsuranceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<UserDto> userDtos = new List<UserDto>();
            var users = _userService.GetAll();
            if (users.Count > 0)
            {
                foreach (var user in users)
                    userDtos.Add(ConvertToDto(user));
                return Ok(userDtos);
            }
            throw new EntityNotFoundError("No users created");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.Get(id);
            if (user != null)
                return Ok(ConvertToDto(user));
            throw new EntityNotFoundError("No such user found");
        }
        //[HttpPost]
        //public IActionResult Add(UserDto userDto)
        //{
        //    var user = ConvertToModel(userDto);
        //    int id = _userService.Add(user);
        //    if (id != null)
        //        return Ok(id);
        //    throw new EntityInsertError("Some issue while adding record");
        //}
        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {
            var existingUser = _userService.Check(userDto.UserId);
            if (existingUser != null)
            {
                var user = ConvertToModel(userDto);
                var modifiedUser = _userService.Update(user);
                return Ok(ConvertToDto(modifiedUser));
            }
            throw new EntityNotFoundError("No such record exists");
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var userToDelete = _userService.Check(id);
            if (userToDelete != null)
            {
                _userService.Delete(userToDelete);
                return Ok(userToDelete.UserId);
            }
            throw new EntityNotFoundError("No such record exists");
        }

        [HttpGet("FindUser/{username}")]
        public IActionResult FindUser(string username)
        {
            var user = _userService.FindUser(username);
            if (user != null)
                return Ok(ConvertToDto(user));
            return NotFound($"User with username {username} not found");
        }

        [HttpGet("GetRoleName/{roleId:int}")]
        public IActionResult GetRoleName(User user)
        {
            var roleName = _userService.GetRoleName(user);
            if (roleName != null)
                return Ok(roleName);
            return NotFound($"Role with ID {user.RoleId} not found");
        }

        [HttpPost("Register")]
        public IActionResult Register(UserDto userDto)
        {
            var existingUser = _userService.FindUser(userDto.UserName);
            if (existingUser == null)
            {
                int userId = _userService.Add(userDto);
               // return Ok(userId.);
               return Ok(new { UserId = userId });
                //return Ok(_userService.Add(userDto));
            }
            return BadRequest("UserName already exists");
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto userDto)
        {
            var user = _userService.FindUser(userDto.UserName);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(userDto.Password, user.Password))
                {
                    string jwt = CreateToken(user);
                    Response.Headers.Add("Jwt", JsonConvert.SerializeObject(jwt));
                    return Ok(new LoginResponseDto()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                        RoleName = _userService.GetRoleName(user)
                    });
                }
            }
            return BadRequest("Username/Password doesn't match");
        }

        private string CreateToken(User user)
        {
            var role = _userService.GetRoleName(user);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }

        private UserDto ConvertToDto(User user)
        {
            return new UserDto()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                RoleId = user.RoleId,
                //Contacts = user.Contacts
            };
        }
        private User ConvertToModel(UserDto userDto)
        {
            return new User()
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                Password = userDto.Password,
                RoleId = userDto.RoleId,
                IsActive = true,
                //Contacts = userDto.Contacts
            };
        }
    }
}
