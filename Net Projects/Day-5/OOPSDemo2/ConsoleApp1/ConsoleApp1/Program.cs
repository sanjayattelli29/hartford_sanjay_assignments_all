using System;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();
            myList.Add(1);
            myList.Add("two");
            myList.Add(3.0);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Generic CounterPart");
            List<object> myGenericList = new List<object>();
            myGenericList.Add(1);
            myGenericList.Add("two");
            myGenericList.Add(3.0);
            foreach (var item in myGenericList)
            {
                Console.WriteLine(item);
            }
        }
    }

}
