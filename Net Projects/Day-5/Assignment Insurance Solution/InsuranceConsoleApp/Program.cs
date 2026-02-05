using System;
using InsuranceLibrary.Models;
using InsuranceLibrary.Services;

namespace InsuranceConsoleApp
{
    class Program
    {
        static PolicyService policyService = new PolicyService();

        static void Main(string[] args)
        {
            policyService.AddPolicy(new InsurancePolicy(1, "Ravi", "Health", 5000, 10));
            policyService.AddPolicy(new InsurancePolicy(2, "Sita", "Life", 8000, 15));
            int userChoice;

            do
            {
                Console.WriteLine("Insurance Management");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View All Policies");
                Console.WriteLine("3. Search Policy by ID");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                int.TryParse(Console.ReadLine(), out userChoice);

                switch (userChoice)
                {
                    case 1:
                        AddPolicy();
                        break;

                    case 2:
                        ViewAllPolicies();
                        break;

                    case 3:
                        SearchPolicyById();
                        break;

                    case 4:
                        UpdatePolicyDetails();
                        break;

                    case 5:
                        DeletePolicyById();
                        break;

                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (userChoice != 0);
        }

        static void AddPolicy()
        {
            Console.Write("Policy ID: ");
            int policyId = int.Parse(Console.ReadLine());

            Console.Write("Policy Holder Name: ");
            string policyHolderName = Console.ReadLine();

            Console.Write("Policy Type (Health/Life/Vehicle): ");
            string policyType = Console.ReadLine();

            Console.Write("Premium Amount: ");
            decimal premiumAmount = decimal.Parse(Console.ReadLine());

            Console.Write("Policy Term (years): ");
            int policyTerm = int.Parse(Console.ReadLine());

            InsurancePolicy newPolicy = new InsurancePolicy(policyId, policyHolderName, policyType, premiumAmount, policyTerm);

            if (policyService.AddPolicy(newPolicy))
                Console.WriteLine("Policy added successfully");
            else
                Console.WriteLine("Policy ID already exists");
        }

        static void ViewAllPolicies()
        {
            var allPolicies = policyService.GetAllPolicies();

            if (allPolicies.Count == 0)
            {
                Console.WriteLine("No policies found");
                return;
            }

            Console.WriteLine("\n--- Policy List ---");
            foreach (var policy in allPolicies)
            {
                Console.WriteLine(policy);
            }
        }

        static void SearchPolicyById()
        {
            Console.Write("Enter Policy ID: ");
            int policyId = int.Parse(Console.ReadLine());

            var foundPolicy = policyService.GetPolicyById(policyId);

            if (foundPolicy != null)
                Console.WriteLine(foundPolicy);
            else
                Console.WriteLine("Policy not found");
        }

        static void UpdatePolicyDetails()
        {
            Console.Write("Enter Policy ID: ");
            int policyId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Premium Amount: ");
            decimal newPremiumAmount = decimal.Parse(Console.ReadLine());

            Console.Write("Enter New Policy Term: ");
            int newPolicyTerm = int.Parse(Console.ReadLine());

            if (policyService.UpdatePolicy(policyId, newPremiumAmount, newPolicyTerm))
                Console.WriteLine("Policy updated successfully");
            else
                Console.WriteLine("Policy not found");
        }

        static void DeletePolicyById()
        {
            Console.Write("Enter Policy ID: ");
            int policyId = int.Parse(Console.ReadLine());

            if (policyService.DeletePolicy(policyId))
                Console.WriteLine("Policy deleted successfully");
            else
                Console.WriteLine("Policy not found");
        }
    }
}
