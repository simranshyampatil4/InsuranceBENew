
using InsuranceApp.DTO;
using InsuranceApp.Exceptions;
using InsuranceApp.Models;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace InsuranceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private IAgentService _agentService;
        private IUserService _userService;

        public AgentController(IAgentService agentService, IUserService userService)
        {
            _agentService = agentService;
            _userService = userService;
        }

        [HttpGet("get")/*, Authorize(Roles = "Admin")*/]
        public IActionResult Get()
        {
            List<AgentDto> agentDtos = new List<AgentDto>();
            var agents = _agentService.GetAll();
            if (agents.Count > 0)
            {
                foreach (var agent in agents)
                    agentDtos.Add(ConvertToDto(agent));
                return Ok(agentDtos);
            }

            throw new EntityNotFoundError("No agents created");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var agent = _agentService.Get(id);
            if (agent != null)
                return Ok(ConvertToDto(agent));
            throw new EntityNotFoundError("No such agent found");
        }

        [HttpPost]
        public IActionResult Add(AgentDto agentDto)
        {
            var userDto = new UserDto()
            {
                Password = agentDto.Password,
                UserName = agentDto.UserName,
                RoleId = 3
            };
            var userId = _userService.Add(userDto);
            agentDto.UserId = userId;
            var agentModel = ConvertToModel(agentDto);
            int id = _agentService.Add(agentModel);
            if (id != 0)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding the agent");
        }

        [HttpPut]
        public IActionResult Update(AgentDto agentDto)
        {
            var existingAgent = _agentService.Check(agentDto.AgentId);
            if (existingAgent != null)
            {
                var agent = ConvertToModel(agentDto);
                var modifiedAgent = _agentService.Update(agent);
                return Ok(ConvertToDto(modifiedAgent));
            }
            throw new EntityNotFoundError("No such agent record exists");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var agentToDelete = _agentService.Check(id);
            if (agentToDelete != null)
            {
                _agentService.Delete(agentToDelete);
                return Ok(agentToDelete.AgentId);
            }
            throw new EntityNotFoundError("Agent does not exist");
        }

        private AgentDto ConvertToDto(Agent agent)
        {
            return new AgentDto()
            {
                AgentId = agent.AgentId,
                FirstName = agent.FirstName,
                LastName = agent.LastName,
                Qualification = agent.Qualification,
                Email = agent.Email,
                MobileNo = agent.MobileNo,
                UserId = agent.UserId,
                CommissionEarned = agent.CommissionEarned,
                //IsActive = agent.IsActive
            };
        }

        private Agent ConvertToModel(AgentDto agentDto)
        {
            return new Agent()
            {
                AgentId = agentDto.AgentId,
                FirstName = agentDto.FirstName,
                LastName = agentDto.LastName,
                Qualification = agentDto.Qualification,
                Email = agentDto.Email,
                MobileNo = agentDto.MobileNo,
                UserId = agentDto.UserId,
                CommissionEarned = agentDto.CommissionEarned,
                IsActive = true
            };
        }
    }
}






