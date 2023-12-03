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
    public class InsuranceSchemeController : ControllerBase
    {
        private IInsuranceSchemeService _insuranceSchemeService;
        public InsuranceSchemeController(IInsuranceSchemeService insuranceSchemeService)
        {
            _insuranceSchemeService = insuranceSchemeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<InsuranceSchemeDto> insuranceSchemeDtos = new List<InsuranceSchemeDto>();
            var insurSchemes = _insuranceSchemeService.GetAll();
            if (insurSchemes.Count > 0)
            {
                foreach (var insurScheme in insurSchemes)
                    insuranceSchemeDtos.Add(ConvertToDto(insurScheme));
                return Ok(insuranceSchemeDtos);
            }
            throw new EntityNotFoundError("No Such Insurance Scheme Found");

        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var insurScheme = _insuranceSchemeService.Get(id);
            if (insurScheme != null)
                return Ok(ConvertToDto(insurScheme));
            throw new EntityNotFoundError("No Such Insurance Scheme Found");

        }
        [HttpPost]
        public IActionResult Add(InsuranceSchemeDto insuranceSchemeDto)
        {
            var insuranceScheme = ConvertToModel(insuranceSchemeDto);
            int id = _insuranceSchemeService.Add(insuranceScheme);
            if (id != null)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding Insurance Scheme");

        }
        [HttpPut]
        public IActionResult Update(InsuranceSchemeDto insuranceSchemeDto)
        {
            var existingScheme = _insuranceSchemeService.Check(insuranceSchemeDto.SchemeId);
            if (existingScheme != null)
            {
                var insuranceScheme = ConvertToModel(insuranceSchemeDto);
                var modifiedScheme = _insuranceSchemeService.Update(insuranceScheme);
                return Ok(ConvertToDto(modifiedScheme));
            }
            throw new EntityNotFoundError("No Such Insurance Scheme Exists");

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var insuranceSchemeToDelete = _insuranceSchemeService.Check(id);
            if (insuranceSchemeToDelete != null)
            {
                _insuranceSchemeService.Delete(insuranceSchemeToDelete);
                return Ok(insuranceSchemeToDelete.SchemeId);
            }
            throw new EntityNotFoundError("No Such Insurance Scheme exists");

        }
        private InsuranceSchemeDto ConvertToDto(InsuranceScheme insuranceScheme)
        {
            return new InsuranceSchemeDto()
            {
                SchemeId = insuranceScheme.SchemeId,
                SchemeName = insuranceScheme.SchemeName,
                //DetailId = insuranceScheme.DetailId,
                PlanId = insuranceScheme.PlanId,
                //Contacts = user.Contacts
            };
        }
        private InsuranceScheme ConvertToModel(InsuranceSchemeDto insuranceSchemeDto)
        {
            return new InsuranceScheme()
            {
                SchemeId = insuranceSchemeDto.SchemeId,
                SchemeName = insuranceSchemeDto.SchemeName,
                //DetailId = insuranceSchemeDto.DetailId,
                PlanId = insuranceSchemeDto.PlanId,
                IsActive = true,
                //Contacts = userDto.Contacts
            };
        }
    }
}
