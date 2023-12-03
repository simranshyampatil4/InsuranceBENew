using InsuranceApp.Models;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class InsuranceSchemeDto
    {
        public int SchemeId { get; set; }

        [Required(ErrorMessage = "Scheme name is required.")]
        [StringLength(50, ErrorMessage = "Scheme name must be no more than 50 characters.")]
        public string SchemeName { get; set; }
        //public int DetailId { get; set; }
        public int PlanId { get; set; }
        //public List<InsurancePolicy> Policies { get; set; }
    }
}