namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oldReading, newReading, consumption;
            double charge = 0;
            string category;
            Console.WriteLine(" Customer Id:");
            string customerId = Console.ReadLine();
            Console.WriteLine(" Customer Name:");
            string customerName = Console.ReadLine();
            Console.WriteLine(" Customer Address:");
            string customerAddress = Console.ReadLine();
            Console.WriteLine(" Customer Phone Number:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine(" Customer Email Id:");
            string emailId = Console.ReadLine();
            Console.WriteLine(" Connection Type (Industrial/Business/Domestic/Agricultural):");
            category = Console.ReadLine();
            Console.WriteLine(" Previous Reading:");
            oldReading = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" Current Reading:");
            newReading = Convert.ToInt32(Console.ReadLine());
            consumption = newReading - oldReading;
            if (consumption <= 100)
                charge = consumption * 1.5;
            else if (consumption <= 250)
                charge = (100 * 1.5) + (consumption - 100) * 2.5;
            else if (consumption <= 550)
                charge = (100 * 1.5) + (150 * 2.5) + (consumption - 250) * 4.5;
            else
                charge = (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + (consumption - 550) * 7.5;
            int fixedCharge = 0;
            if (category == "Industrial")
                fixedCharge = 2500;
            else if (category == "Business")
                fixedCharge = 1500;
            else if (category == "Domestic")
                fixedCharge = 1000;
            else if (category == "Agricultural")
                fixedCharge = 0;
            double totalAmount = charge + fixedCharge;
            Console.WriteLine("\n \t Electricity Bill \n");
            Console.WriteLine("Customer ID : " + customerId);
            Console.WriteLine("Customer Name : " + customerName);
            Console.WriteLine("Customer Email : " + emailId);
            Console.WriteLine("Customer Phone : " + phoneNumber);
            Console.WriteLine("Customer Address : " + customerAddress);
            Console.WriteLine("Units Used    : " + consumption);
            Console.WriteLine("Bill Amount   : " + charge);
            Console.WriteLine("Meter Rent    : " + fixedCharge);
            Console.WriteLine("Total Amount  : " + totalAmount);

        }
    }
}