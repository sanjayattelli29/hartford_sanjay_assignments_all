using System;

namespace ConsoleAppAll
{
    // 1.  addition
    class Addition
    {
        public static void Run()
        {
            int a = 5, b = 7;
            Console.WriteLine("add: " + (a + b));
        }
    }

    // 2. multiplication Table
    class MultiplicationTable
    {
        public static void Run()
        {
            int num = 3;
            Console.WriteLine($"Multiplication Table  {num}:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} x {i} = {num * i}");
            }
        }
    }

    // 3. Even/Odd
    class EvenOdd
    {
        public static void Run()
        {
            int num = 8;
            Console.WriteLine(num % 2 == 0 ? $"{num} is Even" : $"{num} is Odd");
        }
    }

    // 4. array Sum
    class ArraySum
    {
        public static void Run()
        {
            int[] arr = { 10, 20, 30, 40, 50 };
            int sum = 0;
            foreach (int n in arr) sum += n;
            Console.WriteLine("array sum = " + sum);
        }
    }

    // 5. stringreverse
    class StringReverse
    {
        public static void Run()
        {
            string str = "Hello";
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine("ans = " + new string(arr));
        }
    }

    // 6. Factorial
    class Factorial
    {
        public static void Run()
        {
            int num = 5;
            int fact = 1;
            for (int i = 1; i <= num; i++) fact *= i;
            Console.WriteLine($"Factorial  {num} = {fact}");
        }
    }

    // 7. Simple Calc
    class Calculator
    {
        public static void Run()
        {
            double a = 12, b = 4;
            char op = '*';

            switch (op)
            {
                case '+': Console.WriteLine(" Result = " + (a + b)); break;
                case '-': Console.WriteLine(" Result = " + (a - b)); break;
                case '*': Console.WriteLine(" Result = " + (a * b)); break;
                case '/': Console.WriteLine(" Result = " + (a / b)); break;
                default: Console.WriteLine("Invalid "); break;
            }
        }
    }

    // Main Program
    internal class Program
    {
        static void Main(string[] args)
        {

            Addition.Run();
            MultiplicationTable.Run();
            EvenOdd.Run();
            ArraySum.Run();
            StringReverse.Run();
            Factorial.Run();
            Calculator.Run();
        }
    }
}