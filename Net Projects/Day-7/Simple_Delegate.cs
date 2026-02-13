using System;
class Program
{
    static void Add(int i , int j)
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
        RefToMethod r1 = Add;
        r1(10,20);
        
        RefToMethod r2 = Sub;
        r2(40,30);
        
        r2.Invoke(70,40);
    }
}