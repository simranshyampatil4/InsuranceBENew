using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace InsuranceApp.Models
{
    public class InsurancePolicy
    {
        [Key]
        public int PolicyNo { get; set; }

        [Required(ErrorMessage = "Issue date is required.")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Maturity date is required.")]
        [DataType(DataType.Date)]
        public DateTime MaturityDate { get; set; }

        [Required(ErrorMessage = "Premium type is required.")]
        public string PremiumType { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Premium amount must be a non-negative value.")]
        public double PremiumAmount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Sum assured must be a non-negative value.")]
        public double SumAssured { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Policy status is required.")]
        public bool IsActive { get; set; }

        //[Required(ErrorMessage = "Insurance plan is required.")]
        //public InsurancePlan InsurancePlan { get; set; }

        //[ForeignKey("InsurancePlan")]
        //public int PlanId { get; set; }

        // Nullable Claims
        public List<Claim>? Claims { get; set; }

        //[Required(ErrorMessage = "Payment is required.")]
        //public Payment Payment { get; set; }

        //[ForeignKey("Payment")]
        //public int PaymentId { get; set; }

        [Required(ErrorMessage = "Customer is required.")]
        public Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "InsuranceScheme is required.")]
        public InsuranceScheme InsuranceScheme { get; set; }

        [ForeignKey("InsuranceScheme")]
        public int SchemeId { get; set; }
        //public Payment Payment { get; set; }
        public List<Payment>? Payments { get; set; }
        //public Claim Claim { get; set; }
        //public List<Claim>? Claims { get; set; }
    }
}