using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class AdminDto
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be no more than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be no more than 50 characters.")]
        public string LastName { get; set; }
        //public bool IsActive { get; set; }
        //[Required(ErrorMessage = "Username is required.")]
        [StringLength(10, ErrorMessage = "Username must be no more than 10 characters.")]
        public string? UserName { get; set; }
        //[Required(ErrorMessage = "Password is required.")]
        [StringLength(10, ErrorMessage = "Password must be no more than 10 characters.")]
        public string? Password { get; set; }
        public int UserId { get; set; } // User reference ID
    }
}
