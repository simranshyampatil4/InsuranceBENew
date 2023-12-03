using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class AgentDto
    {
        public int AgentId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be no more than 50 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be no more than 50 characters.")]
        public string LastName { get; set; }
        [StringLength(100, ErrorMessage = "Qualification must be no more than 100 characters.")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid mobile number format.")]
        public string MobileNo { get; set; }
        public int UserId { get; set; }
        //[Required(ErrorMessage = "Username is required.")]
        [StringLength(10, ErrorMessage = "Username must be no more than 10 characters.")]
        public string? UserName { get; set; }
        //[Required(ErrorMessage = "Password is required.")]
        [StringLength(10, ErrorMessage = "Password must be no more than 10 characters.")]
        public string? Password { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Commission earned must be a non-negative value.")]
        public double CommissionEarned { get; set; }
        //public bool IsActive { get; set; }
    }
}