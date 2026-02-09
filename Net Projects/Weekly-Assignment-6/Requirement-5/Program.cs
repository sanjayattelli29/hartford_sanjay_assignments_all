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
                // grab how many vehicles theyre gonna input
                Console.WriteLine("Enter the number of vehicles");
                int n = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the detail of vehicles");
                List<Vehicle> vehicleList = new List<Vehicle>();

                // take input n times and build list of vehicles
                for (int i = 0; i < n; i++)
                {
                    vehicleList.Add(Vehicle.CreateVehicle(Console.ReadLine()));
                }

                // ask which way they want stuff sorted
                Console.WriteLine("Enter the type of sort you require");
                Console.WriteLine("1. Sort by weight");
                Console.WriteLine("2. Sort by parked time");
                int choice = int.Parse(Console.ReadLine());

                // choice 1 uses default sort which is by weight
                if (choice == 1)
                {
                    vehicleList.Sort();
                }
                // choice 2 uses custom comparer for sorting by time
                else if (choice == 2)
                {
                    vehicleList.Sort(new ParkedTimeComparer());
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    return;
                }

                // print header then show all sorted vehicles
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