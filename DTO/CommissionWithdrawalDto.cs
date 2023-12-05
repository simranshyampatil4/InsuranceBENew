using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class CommissionWithdrawalDto
    {
        public int Id { get; set; }

        public DateTime WithdrawalDate { get; set; }
        public DateOnly? requestDate { get; set; }
        //public DateOnly? WithdrawalDate { get; set; }
        [Required(ErrorMessage = "WithdrawalAmount is Required.")]
        public double WithdrawalAmount { get; set; }
        //public double TotalWithdrawalAmount { get; set; }
        public int AgentId { get; set; }
        //public bool? IsApproved { get; set; }
    }
}
