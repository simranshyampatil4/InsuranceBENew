using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace InsuranceApp.Models
{
    public class Customer
    {
        [Key]
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

        [Required(ErrorMessage = "Agent is required.")]
        public Agent Agent { get; set; }

        [ForeignKey("Agent")]
        public int AgentId { get; set; }

        [Required(ErrorMessage = "User is required.")]
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public List<InsurancePolicy> InsurancePolicies { get; set; }

        public List<Document> Documents { get; set; }

        [Required(ErrorMessage = "Customer status is required.")]
        public bool IsActive { get; set; }
    }
}