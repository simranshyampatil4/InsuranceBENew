using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Payment type is required.")]
        [StringLength(50, ErrorMessage = "Payment type must be no more than 50 characters.")]
        public string PaymentType { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative value.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Tax must be a non-negative value.")]
        public double Tax { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total payment must be a non-negative value.")]
        public double TotalPayment { get; set; }
        public int CustomerId { get; set; }
        public int PolicyNo { get; set; }
    }
};