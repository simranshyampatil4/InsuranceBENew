using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(50, ErrorMessage = "User name must be no more than 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "User status is required.")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public Role Role { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Agent Agent { get; set; }
        public Admin Admin { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}
