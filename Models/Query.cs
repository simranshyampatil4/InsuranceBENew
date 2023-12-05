using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceApp.Models
{
    public class Query
    {
        public int QueryId { get; set; }
        public string QueryTitle { get; set; }
        public string QueryMessage { get; set; }
        public DateTime QueryDate { get; set; }
        public string? Reply { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public bool IsActive { get; set; }
    }
}
