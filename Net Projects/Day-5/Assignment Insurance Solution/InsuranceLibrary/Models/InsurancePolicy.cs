namespace InsuranceLibrary.Models
{
    public class InsurancePolicy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public string PolicyType { get; set; }
        public decimal PremiumAmount { get; set; }
        public int PolicyTerm { get; set; }
        public bool IsActive { get; set; }

        public InsurancePolicy()
        {
            IsActive = true;
        }

        public InsurancePolicy(int policyId, string policyHolderName, string policyType, decimal premiumAmount, int policyTerm)
        {
            PolicyId = policyId;
            PolicyHolderName = policyHolderName;
            PolicyType = policyType;
            PremiumAmount = premiumAmount;
            PolicyTerm = policyTerm;
            IsActive = true;
        }

        public override string ToString()
        {
            return $"ID:{PolicyId}, Name:{PolicyHolderName}, Type:{PolicyType}, Premium:{PremiumAmount}, Term:{PolicyTerm}, Active:{IsActive}";
        }
    }
}
