using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [StringLength(50, ErrorMessage = "Role name must be no more than 50 characters.")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Role status is required.")]
        public bool IsActive { get; set; }
    }
}

