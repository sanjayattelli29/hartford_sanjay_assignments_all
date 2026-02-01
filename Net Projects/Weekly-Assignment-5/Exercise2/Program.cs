namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1, y1, r1, x2, y2, r2;
            Console.WriteLine(" Circle A c :");
            x1 = Convert.ToDouble(Console.ReadLine());
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(" Circle A radius :");
            r1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(" Circle B c :");
            x2 = Convert.ToDouble(Console.ReadLine());
            y2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(" Circle B radius :");
            r2 = Convert.ToDouble(Console.ReadLine());
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            if (distance + r2 < r1)
                Console.WriteLine("B is in A");
            else if (distance + r1 < r2)
                Console.WriteLine("A is in B");
            else if (distance < r1 + r2)
                Console.WriteLine("A and B intersect");
            else
                Console.WriteLine("A and B do not intersect");
        }
    }
}
