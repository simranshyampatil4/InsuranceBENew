using InsuranceApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.DTO
{
    public class ClaimDto
    {
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

        public string Status { get; set; }

        public int PolicyNo { get; set; }
        public int CustomerId { get; set; }
    }
}