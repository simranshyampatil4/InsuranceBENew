using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class CommissionWithdrawal
    {
        public int Id { get; set; }
        public DateTime WithdrawalDate { get; set; } = DateTime.Now;
        //public bool IsPaid {get; set;} 
        public double WithdrawalAmount { get; set; }
        //public double TotalWithdrawalAmount { get; set; }
        public bool? IsApproved { get; set; }
        public Agent Agent { get; set; }
        [ForeignKey("Agent")]
        public int AgentId { get; set; }
        public bool IsActive { get; set; }
    }
}
