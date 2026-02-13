1. Inner Exception (Arithmetic Example)
using System;

class Program
{
    static void Division(int a, int b)
    {
        try
        {
            int result = a / b;
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            throw new Exception("Calculation fails", ex);
        }
    }

    static void Main(string[] args)
    {
        try
        {
            Division(10, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.InnerException.Message);
        }
    }
}

2. Custom Exception (Age Validation)
using System;

class AgeException : Exception
{
    public int ErrorCode { get; }

    public AgeException(int errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter age:");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age < 18)
            {
                throw new AgeException(1001, "Access denied");
            }

            Console.WriteLine("Age is valid");
        }
        catch (AgeException ex)
        {
            Console.WriteLine(ex.ErrorCode);
            Console.WriteLine(ex.Message);
        }
    }
}

3. Multiple Catch Blocks + Finally

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string s = null;
            Console.WriteLine(s.Length);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Finally block runs");
        }
    }
}
4. Nested Try–Catch

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            try
            {
                int a = 10;
                int b = 0;
                Console.WriteLine(a / b);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Initial catch");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Secondary catch");
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Finally runs");
        }
    }
}

5. Non-Exception Catch Block (Generic Catch)
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int a = 20;
            int b = 0;
            Console.WriteLine(a / b);
        }
        catch
        {
            Console.WriteLine("Error detected");
        }
    }
}

6. Indexer Example

using System;

class Program
{
    int[] data = new int[3] { 1, 2, 3 };

    public int this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }
}

class Final
{
    public static void Main(string[] args)
    {
        Program obj = new Program();
        obj[0] = 4;
        Console.WriteLine(obj[2]);
    }
}