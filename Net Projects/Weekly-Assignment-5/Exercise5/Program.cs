namespace Exercise5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boxerWeight;
            Console.WriteLine(" boxer's weight:");
            boxerWeight = Convert.ToInt32(Console.ReadLine());
            if (boxerWeight < 0 || boxerWeight > 120)
                Console.WriteLine("Invalid Input");
            else if (boxerWeight <= 48)
                Console.WriteLine("light fly");
            else if (boxerWeight <= 51)
                Console.WriteLine("fly");
            else if (boxerWeight <= 54)
                Console.WriteLine("bantam");
            else if (boxerWeight <= 57)
                Console.WriteLine("feather");
            else if (boxerWeight <= 60)
                Console.WriteLine("light");
            else if (boxerWeight <= 64)
                Console.WriteLine("light welter");
            else if (boxerWeight <= 69)
                Console.WriteLine("welter");
            else if (boxerWeight <= 75)
                Console.WriteLine("light middle");
            else if (boxerWeight <= 81)
                Console.WriteLine("middle");
            else if (boxerWeight <= 91)
                Console.WriteLine("light heavy");
            else
                Console.WriteLine("heavy");
        }
    }
}

