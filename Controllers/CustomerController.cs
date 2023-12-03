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
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        private IUserService _userService;

        public CustomerController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            var customers = _customerService.GetAll();
            if (customers.Count > 0)
            {
                foreach (var customer in customers)
                    customerDtos.Add(ConvertToDto(customer));
                return Ok(customerDtos);
            }

            throw new EntityNotFoundError("No customers created");
        }

        [HttpGet("getByUserId")]
        public IActionResult GetCustomerByUserId(int id)
        {
            var customerData = _customerService.GetByUserId(id);
            return Ok(customerData);
        }


        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var customer = _userService.Get(changePasswordDto.Id);
            if (customer != null)
            {
                if (BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, customer.Password))
                {
                    customer.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
                    _userService.Update(customer);
                    return Ok(1);
                }
                return BadRequest("Old Password Does Not Match");
            }
            return BadRequest("Customer Not Found");
        }

        [HttpPost("ChangeUsername")]
        public IActionResult ChangeUsername(ChangeUsernameDto changeUsernameDto)
        {
            var customer = _userService.Get(changeUsernameDto.Id);
            if (customer != null)
            {
                if (changeUsernameDto.OldUsername == customer.UserName)
                {
                    customer.UserName = changeUsernameDto.NewUsername;
                    _userService.Update(customer);
                    return Ok(1);
                }
                return BadRequest("Old Username Does Not Match");
            }
            return BadRequest("Customer Not Found");
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.Get(id);
            if (customer != null)
                return Ok(ConvertToDto(customer));
            throw new EntityNotFoundError("No such customer found");
        }

        [HttpPost]
        public IActionResult Add(CustomerDto customerDto)
        {
            var userDto = new UserDto()
            {
                Password = customerDto.Password,
                UserName = customerDto.UserName,
                RoleId = 4
            };
            var userId = _userService.Add(userDto);
            customerDto.UserId = userId;
            var customerModel = ConvertToModel(customerDto);
            int id = _customerService.Add(customerModel);
            if (id != 0)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding the customer");
        }

        [HttpPut]
        public IActionResult Update(CustomerDto customerDto)
        {
            var existingCustomer = _customerService.Check(customerDto.CustomerId);
            if (existingCustomer != null)
            {
                var customer = ConvertToModel(customerDto);
                var modifiedCustomer = _customerService.Update(customer);
                return Ok(ConvertToDto(modifiedCustomer));
            }
            throw new EntityNotFoundError("No such customer record exists");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var customerToDelete = _customerService.Check(id);
            if (customerToDelete != null)
            {
                _customerService.Delete(customerToDelete);
                return Ok(customerToDelete.CustomerId);
            }
            throw new EntityNotFoundError("No such record exists");
        }
        [HttpGet("getByAgentId/{agentId:int}")]
        public IActionResult GetByAgentId(int agentId)
        {
            List<CustomerDto> customerDtos = new List<CustomerDto>();
            var customers = _customerService.GetByAgentId(agentId);

            if (customers.Count > 0)
            {
                foreach (var customer in customers)
                    customerDtos.Add(ConvertToDto(customer));

                return Ok(customerDtos);
            }

            throw new EntityNotFoundError($"No customers for agent with ID {agentId}");
        }



        private CustomerDto ConvertToDto(Customer customer)
        {
            return new CustomerDto()
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                MobileNo = customer.MobileNo,
                State = customer.State,
                City = customer.City,
                Nominee = customer.Nominee,
                NomineeRelation = customer.NomineeRelation,
                AgentId = customer.AgentId,
                UserId = customer.UserId,
                //IsActive = customer.IsActive
            };
        }

        private Customer ConvertToModel(CustomerDto customerDto)
        {
            return new Customer()
            {
                CustomerId = customerDto.CustomerId,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                MobileNo = customerDto.MobileNo,
                State = customerDto.State,
                City = customerDto.City,
                Nominee = customerDto.Nominee,
                NomineeRelation = customerDto.NomineeRelation,
                AgentId = customerDto.AgentId,
                UserId = customerDto.UserId,
                IsActive = true
            };
        }
    }
}

