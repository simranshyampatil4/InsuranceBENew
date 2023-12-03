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
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        private IUserService _userService;
        public EmployeeController(IEmployeeService employeeService, IUserService userService)
        {
            _employeeService = employeeService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();
            var employees = _employeeService.GetAll();
            if (employees.Count > 0)
            {
                foreach (var employee in employees)
                    employeeDtos.Add(ConvertToDto(employee));
                return Ok(employeeDtos);
            }
            throw new EntityNotFoundError("No Employee created");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.Get(id);
            if (employee != null)
                return Ok(ConvertToDto(employee));
            throw new EntityNotFoundError("No such employee found");
        }
        [HttpPost]
        public IActionResult Add(EmployeeDto employeeDto)
        {
            //employeeDto.IsActive = true;
            var userDto = new UserDto()
            {
                Password = employeeDto.Password,
                UserName = employeeDto.UserName,
                RoleId = 2
            };
            var userId = _userService.Add(userDto);
            employeeDto.UserId = userId;
            var employee = ConvertToModel(employeeDto);
            int id = _employeeService.Add(employee);
            if (id != null)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding employee record");
        }

        [HttpGet("getByUserId")]
        public IActionResult GetEmployeeByUserId(int id)
        {
            var employeeData = _employeeService.GetByUserId(id);
            return Ok(employeeData);
        }

        [HttpPut]
        public IActionResult Update(EmployeeDto employeeDto)
        {
            var existingEmployee = _employeeService.Check(employeeDto.EmployeeId);
            if (existingEmployee != null)
            {
                //employeeDto.IsActive = existingEmployee.IsActive;
                var employee = ConvertToModel(employeeDto);
                var modifiedEmployee = _employeeService.Update(employee);
                return Ok(ConvertToDto(modifiedEmployee));
            }
            throw new EntityNotFoundError("No such record of employee exists");
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var employeeToDelete = _employeeService.Check(id);
            if (employeeToDelete != null)
            {
                _employeeService.Delete(employeeToDelete);
                return Ok(employeeToDelete.EmployeeId);
            }
            throw new EntityNotFoundError("No such record of employee exists");
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var employee = _userService.Get(changePasswordDto.Id);
            if (employee != null)
            {
                if (BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, employee.Password))
                {
                    employee.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
                    _userService.Update(employee);
                    return Ok(1);
                }
                return BadRequest("Old Password Does Not Match");
            }
            return BadRequest("Employee Not Found");
        }

        [HttpPost("ChangeUsername")]
        public IActionResult ChangeUsername(ChangeUsernameDto changeUsernameDto)
        {
            var employee = _userService.Get(changeUsernameDto.Id);
            if (employee != null)
            {
                if (changeUsernameDto.OldUsername == employee.UserName)
                {
                    employee.UserName = changeUsernameDto.NewUsername;
                    _userService.Update(employee);
                    return Ok(1);
                }
                return BadRequest("Old Username Does Not Match");
            }
            return BadRequest("Employee Not Found");
        }

        private EmployeeDto ConvertToDto(Employee employee)
        {
            return new EmployeeDto()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MobileNo = employee.MobileNo,
                Email = employee.Email,
                Salary = employee.Salary,
                UserId = employee.UserId,
                //IsActive = true,

            };
        }
        private Employee ConvertToModel(EmployeeDto employeeDto)
        {
            return new Employee()
            {
                EmployeeId = employeeDto.EmployeeId,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                MobileNo = employeeDto.MobileNo,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary,
                UserId = employeeDto.UserId,
                IsActive = true,

            };
        }
    }
}

