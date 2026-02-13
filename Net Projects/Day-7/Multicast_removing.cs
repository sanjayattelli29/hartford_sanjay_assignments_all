using System;
class Program
{
    static void Add(int i ,int j)
    {
        Console.WriteLine(i+j);
    }
    static void Sub(int i , int j)
    {
        Console.WriteLine(i-j);
    }
    static void Mul(int i , int j)
    {
        Console.WriteLine(i*j);
    }
    public delegate void RefToMethod(int i , int j);
    static void Main(string[] args)
    {
        RefToMethod multicast = Add;
        multicast += Sub;
        multicast += Mul;
        multicast(20,30);
        
        Console.WriteLine("After removing");
        multicast -= Sub;
        multicast(20,10);
    }
}