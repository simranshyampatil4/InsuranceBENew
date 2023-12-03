using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class InsurancePlan
    {
        [Key]
        public int PlanId { get; set; }

        [Required(ErrorMessage = "Plan name is required.")]
        [StringLength(50, ErrorMessage = "Plan name must be no more than 50 characters.")]
        public string PlanName { get; set; }

        [Required(ErrorMessage = "Plan status is required.")]
        public bool IsActive { get; set; }

        // Assuming a one-to-many relationship with InsuranceSchemes
        public List<InsuranceScheme> InsuranceSchemes { get; set; }

        // Assuming a one-to-one relationship with InsurancePolicy
        //[Required(ErrorMessage = "Insurance policy is required.")]
        //public InsurancePolicy InsurancePolicy { get; set; }
        //public InsuranceScheme InsuranceScheme { get; set; }//one to one relationship between insurance plan and scheme
        //[ForeignKey("InsuranceScheme")]
        //public int SchemeId { get; set; }


    }
}
