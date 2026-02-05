using InsuranceLibrary.Models;
using System.Collections.Generic;

namespace InsuranceLibrary.Services
{
    public class PolicyService
    {
        private List<InsurancePolicy> insurancePolicies = new List<InsurancePolicy>();

        public bool AddPolicy(InsurancePolicy newPolicy)
        {
            foreach (var existingPolicy in insurancePolicies)
                if (existingPolicy.PolicyId == newPolicy.PolicyId)
                    return false;

            insurancePolicies.Add(newPolicy);
            return true;
        }

        public List<InsurancePolicy> GetAllPolicies()
        {
            return insurancePolicies;
        }

        public InsurancePolicy GetPolicyById(int policyId)
        {
            foreach (var policy in insurancePolicies)
                if (policy.PolicyId == policyId)
                    return policy;

            return null;
        }

        public bool UpdatePolicy(int policyId, decimal newPremiumAmount, int newPolicyTerm)
        {
            var policyToUpdate = GetPolicyById(policyId);
            if (policyToUpdate == null) return false;

            policyToUpdate.PremiumAmount = newPremiumAmount;
            policyToUpdate.PolicyTerm = newPolicyTerm;
            return true;
        }

        public bool DeletePolicy(int policyId)
        {
            var policyToDelete = GetPolicyById(policyId);
            if (policyToDelete == null) return false;

            insurancePolicies.Remove(policyToDelete);
            return true;
        }
    }
}
