namespace PoliciesCrudApi.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public string Description { get; set; }
        public double PremiumAmount { get; set; }
    }
}
