using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be no more than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be no more than 50 characters.")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "User status is required.")]
        public bool IsActive { get; set; }

     //   [Required(ErrorMessage = "User is required.")]
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }

}

