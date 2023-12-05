using InsuranceApp.DTO;
using InsuranceApp.Exceptions;
using InsuranceApp.Models;
using InsuranceApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InsuranceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionWithdrawalController : ControllerBase
    {
        private ICommissionWithdrawalService _commissionWithdrawalService;
        private ICommissionService _commissionService;

        public CommissionWithdrawalController(ICommissionWithdrawalService commissionWithdrawalService, ICommissionService commissionService)
        {
            _commissionWithdrawalService = commissionWithdrawalService;
            _commissionService = commissionService;
        }

        //[HttpGet, Authorize(Roles = "Agent")]
        [HttpGet]
        public IActionResult Get()
        {
            var commissionWithdrawalDto = new List<CommissionWithdrawalDto>();
            var commissionWithdrawals = _commissionWithdrawalService.GetAll();
            if (commissionWithdrawals.Count > 0)
            {
                foreach (var withdrawal in commissionWithdrawals)
                {
                    commissionWithdrawalDto.Add(ConvertToDto(withdrawal));
                }
                return Ok(commissionWithdrawalDto);
            }
            throw new EntityNotFoundError("CommissionWithdrawal not found");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var commissionWithdrawal = _commissionWithdrawalService.Get(id);
            if (commissionWithdrawal == null)
            {
                throw new EntityNotFoundError("CommissionWithdrawal not found");
            }
            return Ok(ConvertToDto(commissionWithdrawal));
        }

        [HttpPost]
        public IActionResult Add(CommissionWithdrawalDto commissionWithdrawalDto)
        {
            var commissionData = _commissionService.GetAll();
            var amount = commissionWithdrawalDto.WithdrawalAmount;
            if (commissionData != null)
            {
                foreach (var commission in commissionData)
                {
                    if (amount <= commission.CommissionAmount)
                        commission.CommissionAmount = commission.CommissionAmount - amount;
                    else
                    {
                        amount = amount - commission.CommissionAmount;
                        commission.CommissionAmount = 0;
                    }
                    _commissionService.Update(commission);
                }
                //commissionWithdrawalDto.WithdrawalDate = DateOnly.FromDateTime(DateTime.Now);
                var commissionWithdrawal = ConvertToModel(commissionWithdrawalDto);
                var CommissionWithdrawalId = _commissionWithdrawalService.Add(commissionWithdrawal);
                if (CommissionWithdrawalId == null)
                    throw new EntityInsertError("Some errors occurred");
                return Ok(CommissionWithdrawalId);
            }
            return BadRequest("No commission found");
        }

        [HttpPut]
        public IActionResult Update(CommissionWithdrawalDto commissionWithdrawalDto)
        {
            var commissionWithdrawalDTOToUpdate = _commissionWithdrawalService.Check(commissionWithdrawalDto.Id);
            if (commissionWithdrawalDTOToUpdate != null)
            {
                var updatedCommissionWithdrawal = ConvertToModel(commissionWithdrawalDto);
                var modifiedCommissionWithdrawal = _commissionWithdrawalService.Update(updatedCommissionWithdrawal);
                return Ok(ConvertToDto(modifiedCommissionWithdrawal));
            }
            throw new EntityNotFoundError("No CommissionWithdrawal found to update");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var commissionWithdrawal = _commissionWithdrawalService.Get(id);
            if (commissionWithdrawal != null)
            {
                _commissionWithdrawalService.Delete(commissionWithdrawal);
                return Ok(id);
            }
            throw new EntityNotFoundError("No CommissionWithdrawal found to delete");
        }

        private CommissionWithdrawal ConvertToModel(CommissionWithdrawalDto commissionWithdrawalDto)
        {
            return new CommissionWithdrawal()
            {
                Id = commissionWithdrawalDto.Id,
                //WithdrawalDate = commissionWithdrawalDto.WithdrawalDate.ToDateTime(TimeOnly.Parse("10:00 PM")),
                WithdrawalDate = commissionWithdrawalDto.WithdrawalDate,
                WithdrawalAmount = commissionWithdrawalDto.WithdrawalAmount,
                //IsApproved = false,
                AgentId = commissionWithdrawalDto.AgentId,
                IsActive = true,
            };
        }

        private CommissionWithdrawalDto ConvertToDto(CommissionWithdrawal commissionWithdrawal)
        {
            return new CommissionWithdrawalDto()
            {
                Id = commissionWithdrawal.Id,
                //WithdrawalDate = DateOnly.FromDateTime(commissionWithdrawal.WithdrawalDate),
                WithdrawalAmount = commissionWithdrawal.WithdrawalAmount,
                AgentId = commissionWithdrawal.AgentId,
                //IsApproved = commissionWithdrawal.IsApproved,
                requestDate = DateOnly.FromDateTime(commissionWithdrawal.WithdrawalDate)
            };
        }
    }
}
