using System;
using System.Collections.Generic;

namespace Requirement_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number of vehicles");
                int n = int.Parse(Console.ReadLine());
                List<Vehicle> vehicleList = new List<Vehicle>();

                for (int i = 0; i < n; i++)
                {
                    Vehicle v = Vehicle.CreateVehicle(Console.ReadLine());
                    if (v != null)
                    {
                        vehicleList.Add(v);
                    }
                }
        
                SortedDictionary<string, int> res = Vehicle.TypeWiseCount(vehicleList);

                Console.WriteLine("{0,-15} {1}", "Type", "No. of Vehicles");

                foreach (var item in res)
                {
                    Console.WriteLine("{0,-15} {1}", item.Key, item.Value);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}