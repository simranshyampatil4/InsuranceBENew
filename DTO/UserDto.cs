using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }

        [StringLength(50, ErrorMessage = "User name must be no more than 50 characters.")]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}