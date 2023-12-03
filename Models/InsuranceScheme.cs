using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class InsuranceScheme
    {
        [Key]
        public int SchemeId { get; set; }

        [Required(ErrorMessage = "Scheme name is required.")]
        [StringLength(50, ErrorMessage = "Scheme name must be no more than 50 characters.")]
        public string SchemeName { get; set; }

        [Required(ErrorMessage = "Scheme status is required.")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Scheme details are required.")]
        public SchemeDetails SchemeDetails { get; set; }

        //[ForeignKey("SchemeDetails")]
        //public int DetailId { get; set; }

        // Assuming a one-to-many relationship with InsurancePolicies
        public List<InsurancePolicy> Policies { get; set; }

        [Required(ErrorMessage = "Insurance plan is required.")]
        public InsurancePlan InsurancePlan { get; set; }

        [ForeignKey("InsurancePlan")]
        public int PlanId { get; set; }
    }
}

