using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class Commission
    {
        public int CommissionId { get; set; }
        public InsurancePolicy? InsurancePolicy { get; set; }
        [ForeignKey("InsurancePolicy")]
        public int PolicyNo { get; set; } //InsuranceNumber
        public Agent? Agent { get; set; }
        [ForeignKey("Agent")]
        public int AgentId { get; set; }
        //public DateTime CommisionDate { get; } = DateTime.Now;
        public Customer? Customer { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public double CommisionAmount { get; set; }

        public bool IsActive { get; set; }
    }
}
