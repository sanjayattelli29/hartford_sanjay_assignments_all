using SalaryCalculator;

namespace SalaryDisplay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write(" Employee Name: ");
                string workerName = Console.ReadLine();
                Console.Write(" Basic Salary: ");
                if (!double.TryParse(Console.ReadLine(), out double basePay))
                {
                    throw new FormatException("Please  a valid numeric salary.");
                }
                double finalPay = PayProcessor.ComputeFinalPay(basePay);
                Console.WriteLine("\n Employee Details Salary");
                Console.WriteLine($"Employee Name : {workerName}");
                Console.WriteLine($"Basic Salary  : {basePay:F2}");
                Console.WriteLine($"Net Salary    : {finalPay:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
