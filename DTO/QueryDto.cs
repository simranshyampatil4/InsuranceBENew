using System.ComponentModel.DataAnnotations;

namespace InsuranceApp.DTO
{
    public class QueryDto
    {
        public int QueryId { get; set; }
        [Required(ErrorMessage = "QueryTitle is Required.")]
        public string QueryTitle { get; set; }
        [Required(ErrorMessage = "QueryMessage is Required.")]
        public string QueryMessage { get; set; }
        public DateTime QueryDate { get; set; }
        public string? Reply { get; set; }
        public int? CustomerId { get; set; }
    }
}
