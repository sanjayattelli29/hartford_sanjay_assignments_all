using System;
using System.Text;

namespace Day_3
{
    public class HelloWorld
    {
        // Value Parameter
        static void AddValue(int a, int b)
        {
            int sum = a + b;
            Console.WriteLine("Value Type: {0}", sum);
        }

        // Reference Parameter
        static void AddRef(ref int a, int b)
        {
            a = a + b;
        }

        // Out Parameter
        static void AddOut(int a, int b, out int sum)
        {
            sum = a + b;
        }

        // Return Type
        static int AddReturn(int a, int b)
        {
            return a + b;
        }

        static void Main()
        {
            Console.WriteLine("WEEK 5 - C# BASIC ASSIGNMENT");
            Console.WriteLine("1. Exercise-1");
            Console.WriteLine("2. Exercise-2");
            Console.WriteLine("3. Exercise-3");
            Console.WriteLine("4. Exercise-4");
            Console.WriteLine("5. Exercise-5");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                int x = 10, y = 20;

                AddValue(x, y);

                AddRef(ref x, y);
                Console.WriteLine("Reference Type: {0}", x);

                AddOut(x, y, out int res);
                Console.WriteLine("Out Parameter: {0}", res);

                int r = AddReturn(x, y);
                Console.WriteLine("Return Parameter: {0}", r);
            }
            else if (choice == 2)
            {
                int a = 10;
                double b = a;
                Console.WriteLine("Implicit Type: {0}", b);
                double x = 12.75;
                int y = (int)x;
                Console.WriteLine("Explicit Type: {0}", y);
            }
            else if (choice == 3)
            {
                //1.Parse
                int a = int.Parse("100");
                //2. TryParse
                int.TryParse("200", out int b);
                //3. Convert 
                int c = Convert.ToInt32("300");
                //4. ToString
                string s = a.ToString();
                //5. Implicit
                double d = a;
                //6. Explicit
                int e = (int)d;
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
                Console.WriteLine(d);
                Console.WriteLine(e);
                Console.WriteLine(s);

            }
            else if (choice == 4)
            {
                StringBuilder sb = new StringBuilder("Hello ");

                sb.Append("World");
                sb.AppendLine(" Welcome");

                sb.Insert(6, "C# ");
                sb.Replace("Welcome", "Everyone");
                sb.Remove(0, 5);

                Console.WriteLine(sb);

                Console.WriteLine("Length: " + sb.Length);

                sb[0] = 'h';
                Console.WriteLine("Indexer: " + sb);

                string result = sb.ToString();
                Console.WriteLine("ToString: " + result);

                sb.Clear();
                Console.WriteLine("Cleared: " + sb);
            }
            else if (choice == 5)
            {
                int n = 25;
                double d = 123.456;
                int i = 32;

                // Decimal
                Console.WriteLine($"{n:D}");
                Console.WriteLine($"{n:D5}");

                // Exponential
                Console.WriteLine($"{d:E}");
                Console.WriteLine($"{d:e}");

                // Fixed point
                Console.WriteLine($"{d:F2}");

                // General
                Console.WriteLine($"{d:G}");

                // Number
                Console.WriteLine($"{d:N2}");

                // Percentage
                Console.WriteLine($"{0.85:P}");

                // Hexadecimal
                Console.WriteLine($"{i:X}");
                Console.WriteLine($"{i:x}");
            }
        }
    }

}