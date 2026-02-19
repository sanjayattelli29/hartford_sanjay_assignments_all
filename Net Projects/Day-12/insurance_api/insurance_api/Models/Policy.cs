namespace insurance_api.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public string Provider { get; set; }
        public decimal Premium { get; set; }
        public decimal CoverageAmount { get; set; }
    }
}
