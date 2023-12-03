using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class InsurancePlanDto
    {
        public int PlanId { get; set; }
        [Required(ErrorMessage = "Plan name is required.")]
        [StringLength(50, ErrorMessage = "Plan name must be no more than 50 characters.")]
        public string PlanName { get; set; }
        //public int SchemeId { get; set; }
    }
}