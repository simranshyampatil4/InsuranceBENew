using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class InsurancePolicyDto
    {
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
        public string Status { get; set; }
        //public int PlanId { get; set; }
        //public int ClaimId { get; set; }
        //public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public int SchemeId { get; set; }
    }
}