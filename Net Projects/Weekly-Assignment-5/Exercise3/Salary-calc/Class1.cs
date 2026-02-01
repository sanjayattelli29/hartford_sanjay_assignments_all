namespace SalaryCalculator
{
    public class SalaryCalculator
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            // Check if salary is valid
            if (basicSalary <= 0)
            {
                throw new Exception("Basic salary must be greater than zero.");
            }

            // Calculate HRA (20% of Basic)
            double hra = basicSalary * 0.20;

            // Calculate DA (10% of Basic)
            double da = basicSalary * 0.10;

            // Calculate PF (12% of Basic, but only if Basic >= 15000)
            double pf = 0;
            if (basicSalary >= 15000)
            {
                pf = basicSalary * 0.12;
            }

            // Calculate Net Salary = Basic + HRA + DA - PF
            double netSalary = basicSalary + hra + da - pf;

            return netSalary;
        }
    }
}
