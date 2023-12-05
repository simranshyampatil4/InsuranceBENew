namespace InsuranceApp.DTO
{
    public class CommissionDto
    {
        public int CommissionId { get; set; }
        public int PolicyNo { get; set; }
        public int AgentId { get; set; }
        public int CustomerId { get; set; }
        public double CommissionAmount { get; set; }
    }
}
