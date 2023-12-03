using InsuranceApp.DTO;
using InsuranceApp.Exceptions;
using InsuranceApp.Models;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<RoleDto> roleDtos = new List<RoleDto>();
            var roles = _roleService.GetAll();
            if (roles.Count > 0)
            {
                foreach (var role in roles)
                    roleDtos.Add(ConvertToDto(role));
                return Ok(roleDtos);
            }
            throw new EntityNotFoundError("No role created");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var role = _roleService.Get(id);
            if (role != null)
                return Ok(ConvertToDto(role));
            throw new EntityNotFoundError("No such Role Found");
        }
        [HttpPost]
        public IActionResult Add(RoleDto roleDto)
        {
            var role = ConvertToModel(roleDto);
            int id = _roleService.Add(role);
            if (id != null)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding record");
        }
        [HttpPut]
        public IActionResult Update(RoleDto roleDto)
        {
            var existingRole = _roleService.Check(roleDto.RoleId);
            if (existingRole != null)
            {
                var role = ConvertToModel(roleDto);
                var modifiedRole = _roleService.Update(role);
                return Ok(ConvertToDto(modifiedRole));
            }
            throw new EntityNotFoundError("No such record exists");
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var roleToDelete = _roleService.Check(id);
            if (roleToDelete != null)
            {
                _roleService.Delete(roleToDelete);
                return Ok(roleToDelete.RoleId);
            }
            throw new EntityNotFoundError("No such record exists");
        }
        private RoleDto ConvertToDto(Role role)
        {
            return new RoleDto()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
              
                //Contacts = user.Contacts
            };
        }
        private Role ConvertToModel(RoleDto roleDto)
        {
            return new Role()
            {
                RoleId = roleDto.RoleId,
                RoleName = roleDto.RoleName,
                IsActive = true,

                //Contacts = userDto.Contacts
            };
        }
    }
}
