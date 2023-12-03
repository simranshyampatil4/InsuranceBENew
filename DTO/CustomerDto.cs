using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be no more than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be no more than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid mobile number format.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Nominee is required.")]
        public string Nominee { get; set; }

        [Required(ErrorMessage = "Nominee relation is required.")]
        public string NomineeRelation { get; set; }

        public int AgentId { get; set; }

        public int UserId { get; set; }

        //[Required(ErrorMessage = "Username is required.")]
        [StringLength(10, ErrorMessage = "Username must be no more than 10 characters.")]
        public string? UserName { get; set; }

        //[Required(ErrorMessage = "Password is required.")]
        [StringLength(10, ErrorMessage = "Password must be no more than 10 characters.")]
        public string? Password { get; set; }

        //public bool IsActive { get; set; }
    }
}