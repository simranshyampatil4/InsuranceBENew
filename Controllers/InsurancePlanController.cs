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
    public class InsurancePlanController : ControllerBase
    {
        private IInsurancePlanService _insurancePlanService;
        public InsurancePlanController(IInsurancePlanService insurancePlanService)
        {
            _insurancePlanService = insurancePlanService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<InsurancePlanDto> insurancePlanDtos = new List<InsurancePlanDto>();
            var insurPlan = _insurancePlanService.GetAll();
            if (insurPlan.Count > 0)
            {
                foreach (var insurPl in insurPlan)
                    insurancePlanDtos.Add(ConvertToDto(insurPl));
                return Ok(insurancePlanDtos);
            }
            throw new EntityNotFoundError("No Such Insurance Plan Found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var insurPlan = _insurancePlanService.Get(id);
            if (insurPlan != null)
                return Ok(ConvertToDto(insurPlan));
            throw new EntityNotFoundError("No Such Insurance Plan Found");
        }
        [HttpPost]
        public IActionResult Add(InsurancePlanDto insurancePlanDto)
        {
            var insurancePlan = ConvertToModel(insurancePlanDto);
            int id = _insurancePlanService.Add(insurancePlan);
            if (id != null)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding Insurance Plan");
        }
        [HttpPut]
        public IActionResult Update(InsurancePlanDto insurancePlanDto)
        {
            var existingUser = _insurancePlanService.Check(insurancePlanDto.PlanId);
            if (existingUser != null)
            {
                var insurancePlan = ConvertToModel(insurancePlanDto);
                var modifiedPlan = _insurancePlanService.Update(insurancePlan);
                return Ok(ConvertToDto(modifiedPlan));
            }
            throw new EntityNotFoundError("No Such Insurance Plan Exists");
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var insuranceToDelete = _insurancePlanService.Check(id);
            if (insuranceToDelete != null)
            {
                _insurancePlanService.Delete(insuranceToDelete);
                return Ok(insuranceToDelete.PlanId);
            }
            throw new EntityNotFoundError("No Such Insurance Plan Exists");


        }
        private InsurancePlanDto ConvertToDto(InsurancePlan insurancePlan)
        {
            return new InsurancePlanDto()
            {
                PlanId = insurancePlan.PlanId,
                PlanName = insurancePlan.PlanName,
                //SchemeId = insurancePlan.SchemeId,
                //Contacts = user.Contacts
            };
        }
        private InsurancePlan ConvertToModel(InsurancePlanDto insurancePlanDto)
        {
            return new InsurancePlan()
            {
                PlanId = insurancePlanDto.PlanId,
                PlanName = insurancePlanDto.PlanName,
                //SchemeId = insurancePlanDto.SchemeId,
                IsActive = true,
                //Contacts = userDto.Contacts
            };
        }
    }
}
