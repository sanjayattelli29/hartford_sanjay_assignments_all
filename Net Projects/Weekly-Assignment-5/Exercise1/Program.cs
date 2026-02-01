namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" number of matches:");
            int count = Convert.ToInt32(Console.ReadLine());
            int result = 0;
            for(int index = 1; index <= count; index++)
            {
                result = index * (index - 1) * (index + 1);
                Console.Write(result + " ");
            }
        }
    }
}
