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
    public class ClaimController : ControllerBase
    {
        private IClaimService _claimService;
        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<ClaimDto> claimDtos = new List<ClaimDto>();
            var claims = _claimService.GetAll();
            if (claims.Count > 0)
            {
                foreach (var claim in claims)
                    claimDtos.Add(ConvertToDto(claim));
                return Ok(claimDtos);
            }
            throw new EntityNotFoundError("No claims created");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var claim = _claimService.Get(id);
            if (claim != null)
                return Ok(ConvertToDto(claim));
            throw new EntityNotFoundError("No such Claim Found");
        }
        [HttpPost]
        public IActionResult Add(ClaimDto claimDto)
        {
            var claim = ConvertToModel(claimDto);
            int id = _claimService.Add(claim);
            if (id != null)
                return Ok(id);
            throw new EntityInsertError("Some issue while adding record");
        }
        [HttpPut]
        public IActionResult Update(ClaimDto claimDto)
        {
            var existingClaim = _claimService.Check(claimDto.ClaimId);
            if (existingClaim != null)
            {
                var claim = ConvertToModel(claimDto);
                var modifiedClaim = _claimService.Update(claim);
                return Ok(ConvertToDto(modifiedClaim));
            }
            throw new EntityNotFoundError("No such record exists");
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteById(int id)
        {
            var claimToDelete = _claimService.Check(id);
            if (claimToDelete != null)
            {
                _claimService.Delete(claimToDelete);
                return Ok(claimToDelete.ClaimId);
            }
            throw new EntityNotFoundError("No such record exists");
        }
        private ClaimDto ConvertToDto(Claim claim)
        {
            return new ClaimDto()
            {
                ClaimId = claim.ClaimId,
                ClaimAmount = claim.ClaimAmount,
                BankAccountNumber = claim.BankAccountNumber,
                BankIfscCode = claim.BankIfscCode,
                Date=claim.Date,
                Status=claim.Status,
                PolicyNo=claim.PolicyNo,
                CustomerId=claim.CustomerId,
                //Contacts = user.Contacts
            };
        }
        private Claim ConvertToModel(ClaimDto claimDto)
        {
            return new Claim()
            {
                ClaimId = claimDto.ClaimId,
                ClaimAmount = claimDto.ClaimAmount,
                BankAccountNumber = claimDto.BankAccountNumber,
                BankIfscCode = claimDto.BankIfscCode,
                Date=claimDto.Date,
                Status=claimDto.Status,
                PolicyNo=claimDto.PolicyNo,
                CustomerId=claimDto.CustomerId,
                IsActive = true,
                //Contacts = userDto.Contacts
            };
        }
    }
}
