using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class SchemeDetailsDto
    {
        public int DetailId { get; set; }
        public string SchemeImage { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description must be no more than 500 characters.")]
        public string Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Minimum amount must be a non-negative value.")]
        public double MinAmount { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Maximum amount must be a non-negative value.")]
        public double MaxAmount { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Minimum investment time must be a non-negative value.")]
        public int MinInvestmentTime { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Maximum investment time must be a non-negative value.")]
        public int MaxInvestmentTime { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Minimum age must be a non-negative value.")]
        public int MinAge { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Maximum age must be a non-negative value.")]
        public int MaxAge { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Profit ratio must be a non-negative value.")]
        public double ProfitRatio { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Registration commission ratio must be a non-negative value.")]
        public double RegistrationCommRatio { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Installment commission ratio must be a non-negative value.")]
        public double InstallmentCommRatio { get; set; }
        public int SchemeId { get; set; }
    }
}