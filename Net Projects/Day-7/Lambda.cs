// using System;
// class Program
// {
//     static void Add(int i , int j)
//     {
//         Console.WriteLine(i+j);
//     }
//     static void Sub(int i , int j)
//     {
//         Console.WriteLine(i-j);
//     }
//     public delegate void RefToMethod(int i , int j);
//     static void Main(string[] args)
//     {
//         RefToMethod r1 = Add;
//         r1(10,20);
        
//         RefToMethod r2 = Sub;
//         r2(40,30);
        
//         r2.Invoke(70,40);
//     }
// }

// using System;
// class Program
// {
//     static void Add(int i ,int j)
//     {
//         Console.WriteLine(i+j);
//     }
//     static void Sub(int i , int j)
//     {
//         Console.WriteLine(i-j);
//     }
//     public delegate void RefToMethod(int i , int j);
//     static void Main(string[] args)
//     {
//         RefToMethod multicast = Add;
//         multicast += Sub;
//         multicast(20,30);
//     }
// }

// using System;
// class Program
// {
//     static void Add(int i ,int j)
//     {
//         Console.WriteLine(i+j);
//     }
//     static void Sub(int i , int j)
//     {
//         Console.WriteLine(i-j);
//     }
//     static void Mul(int i , int j)
//     {
//         Console.WriteLine(i*j);
//     }
//     public delegate void RefToMethod(int i , int j);
//     static void Main(string[] args)
//     {
//         RefToMethod multicast = Add;
//         multicast += Sub;
//         multicast += Mul;
//         multicast(20,30);
        
//         Console.WriteLine("After removing");
//         multicast -= Sub;
//         multicast(20,10);
//     }
// }

// using System;
// delegate void Print();
// class Money
// {
//     protected int note;
//     protected int coin;
//     public Money(int n, int c)
//     {
//       note = n;
//       coin = c;
//     }
// }
// class Rupee : Money
// {
//     public Rupee(int rupees, int paise) :base(rupees, paise)
//     {}
//     public void Display()
//     {
//         Console.WriteLine("Rs. {0}.{1}",note , coin);
//     }
// }

// class Dollar : Money
// {
//     public Dollar(int dollar, int cent) :base(dollar,cent)
//     {}
//     public void Info()
//     {
//         Console.WriteLine("Rs. {0}.{1}",note , coin);
//     }
// }

// class Test
// {
//     static void Main()
//     {
//         Rupee m1 = new Rupee(1000,75);
//         Dollar m2 = new Dollar(100,75);
//         Print[] p = new Print[2];
//         p[0] = new Print(m1.Display);
//         p[1] = new Print(m2.Info);
//         write(p);
//     }
//     static void write(Print[] p)
//     {
//         p[0]();
//         p[1]();
//     }
// }

// using System;
// class Test
// {
//     delegate string Cat(string[] s);
//     public static void Main()
//     {
//         Cat c = delegate(string[] s)
//         {
//             string c1 = "";
//             foreach(string s1 in s)
//                 c1 = c1 + s1;
//             return c1;
//         };
//         string[] ss = {"C#","VB","F#"};
//         Console.WriteLine(c(ss));
//     }
// }

// using System;
// delegate int CountIt(int end);
// class AnonymousMethod
// {
//     static void Main()
//     {
//         int res;
//         CountIt c = delegate(int end)
//         {
//             int sum = 0;
//             for(int i = 0; i<= end ; i++)
//             {
//                 Console.WriteLine(i);
//                 sum += i;
//             }
//             return sum;
//         };
//         res = c(3);
//         Console.WriteLine(res);
//     }
// }
// using System;
// class Program
// {
//     delegate double CalArea(double r);
//     static void Main(string[] args)
//     {
//         CalArea del = r => 3.14*r*r;
//         double area = del(5.5);
//         Console.WriteLine(area);
//     }
// }

// using System;
// class Program
// {
//     static void Main(string[] args)
//     {
//         Predicate<string> check = x => x.Length > 8;
//         Console.WriteLine(check("Hello0000"));
//     }
// }

// using System;
// class Program
// {
//     static void Main(string[] args)
//     {
//         Action<string> mymsg = n => Console.WriteLine(n);
//         mymsg("India is great");
//     }
// }