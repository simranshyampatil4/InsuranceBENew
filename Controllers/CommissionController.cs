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
    public class CommissionController : ControllerBase
    {
        private ICommissionService _commissionService;
        public CommissionController(ICommissionService commissionService)
        {
            _commissionService = commissionService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var commissionDto = new List<CommissionDto>();
            var commissions = _commissionService.GetAll();
            if (commissions.Count > 0)
            {
                foreach (var commission in commissions)
                {
                    commissionDto.Add(ConvertToDto(commission));
                }
                return Ok(commissionDto);
            }
            throw new EntityNotFoundError("Commision not found");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var commission = _commissionService.Get(id);
            if (commission == null)
            {
                throw new EntityNotFoundError("Commision not found");
            }
            return Ok(ConvertToDto(commission));
        }
        [HttpPost]
        public IActionResult Add(CommissionDto commissionDto)
        {
            var commission = ConvertToModel(commissionDto);
            var commissionId = _commissionService.Add(commission);
            if (commissionId == null)
                throw new EntityInsertError("Some errors Occurred");
            return Ok(commissionId);
        }
        [HttpPut]
        public IActionResult Update(CommissionDto commissionDto)
        {
            var commissionDtoToUpdate = _commissionService.Check(commissionDto.CommissionId);
            if (commissionDtoToUpdate != null)
            {
                var updatedCommission = ConvertToModel(commissionDto);
                var modifiedCommission = _commissionService.Update(updatedCommission);
                return Ok(ConvertToDto(modifiedCommission));
            }
            throw new EntityNotFoundError("No Commision found to update");
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var commission = _commissionService.Get(id);
            if (commission != null)
            {
                _commissionService.Delete(commission);
                return Ok(id);
            }
            throw new EntityNotFoundError("No Commision found to delete");
        }
        private Commission ConvertToModel(CommissionDto commissionDto)
        {
            return new Commission()
            {
                CommissionId = commissionDto.CommissionId,
                AgentId = commissionDto.AgentId,
                PolicyNo = commissionDto.PolicyNo,
                CustomerId = commissionDto.CustomerId,
                CommissionAmount = commissionDto.CommissionAmount,
                IsActive = true

            };
        }
        private CommissionDto ConvertToDto(Commission commission)
        {
            return new CommissionDto()
            {
                CommissionId = commission.CommissionId,
                PolicyNo = commission.PolicyNo,
                AgentId = commission.AgentId,
                CustomerId = commission.CustomerId,
                CommissionAmount = commission.CommissionAmount,

            };
        }
    }
}
