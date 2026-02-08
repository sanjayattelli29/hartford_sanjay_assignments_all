using System;
using System.Collections.Generic;

namespace Requirement_5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the number of vehicles");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the detail of vehicles");
                List<Vehicle> vehicleList = new List<Vehicle>();

                for (int i = 0; i < n; i++)
                {
                    vehicleList.Add(Vehicle.CreateVehicle(Console.ReadLine()));
                }

                Console.WriteLine("Enter the type of sort you require");
                Console.WriteLine("1. Sort by weight");
                Console.WriteLine("2. Sort by parked time");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    vehicleList.Sort();
                }
                else if (choice == 2)
                {
                    vehicleList.Sort(new ParkedTimeComparer());
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    return;
                }

                Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                    "Registration No", "Name", "Type", "Weight", "Ticket No");

                foreach (Vehicle v in vehicleList)
                {
                    Console.WriteLine(v);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}