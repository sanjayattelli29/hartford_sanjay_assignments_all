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
    public delegate void RefToMethod(int i , int j);
    static void Main(string[] args)
    {
        RefToMethod multicast = Add;
        multicast += Sub;
        multicast(20,30);
    }
}