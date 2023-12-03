using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class Claim
    {
        [Key]
        public int ClaimId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Claim amount must be a non-negative value.")]
        public double ClaimAmount { get; set; }

        [Required(ErrorMessage = "Bank account number is required.")]
        [RegularExpression(@"^[0-9]{1,20}$", ErrorMessage = "Invalid bank account number format.")]
        public double BankAccountNumber { get; set; }

        [Required(ErrorMessage = "Bank IFSC code is required.")]
        [StringLength(11, ErrorMessage = "IFSC code must be 11 characters.")]
        public string BankIfscCode { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Insurance policy is required.")]
        public InsurancePolicy InsurancePolicy { get; set; }

        [ForeignKey("InsurancePolicy")]
        public int PolicyNo { get; set; }

        [Required(ErrorMessage = "Claim status is required.")]
        public bool IsActive { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    }
}
