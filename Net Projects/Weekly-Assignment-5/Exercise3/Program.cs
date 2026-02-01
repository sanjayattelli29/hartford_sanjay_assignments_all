using SalaryCalculator;

namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get employee details
                Console.WriteLine(" Employee Name:");
                string employeeName = Console.ReadLine();

                Console.WriteLine(" Employee ID:");
                string employeeId = Console.ReadLine();

                Console.WriteLine(" Basic Salary:");
                string salaryInput = Console.ReadLine();
                double basicSalary = Convert.ToDouble(salaryInput);

                // Calculate net salary using library
                double netSalary = SalaryCalculator.CalculateNetSalary(basicSalary);

                // Display results
                Console.WriteLine("\nEmployee Salary Detail");
                Console.WriteLine("Employee ID : " + employeeId);
                Console.WriteLine("Employee Name : " + employeeName);
                Console.WriteLine("Basic Salary : " + basicSalary);
                Console.WriteLine("Net Salary : " + netSalary);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
