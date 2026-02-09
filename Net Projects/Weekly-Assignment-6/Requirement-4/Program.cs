using System;
using System.Collections.Generic;

namespace Requirement_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // user tells how many vehicles theyre gonna enter
                Console.WriteLine("Enter the number of vehicles");
                int n = int.Parse(Console.ReadLine());

                List<Vehicle> vehiclelist = new List<Vehicle>();

                // loop n times and create vehicles from what they type
                for (int i = 0; i < n; i++)
                {
                    vehiclelist.Add(Vehicle.CreateVehicle(Console.ReadLine()));
                }

                // ask them how they wanna search through the vehicles
                Console.WriteLine("Enter a search type:");
                Console.WriteLine("1.By type");
                Console.WriteLine("2.By parked time");
                int choice = int.Parse(Console.ReadLine());

                // business object handles the search logic
                VehicleBO vehicleBO = new VehicleBO();
                List<Vehicle> result = new List<Vehicle>();

                // option 1 searches by vehicle type like car or bike
                if (choice == 1)
                {
                    Console.WriteLine("Enter the vehicle type");
                    string type = Console.ReadLine();
                    result = vehicleBO.FindVehicle(vehiclelist, type);
                }
                // option 2 searches by when it got parked
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the parked time:");
                    DateTime parkedTime = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy HH:mm:ss", null);
                    result = vehicleBO.FindVehicle(vehiclelist, parkedTime);
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    return;
                }

                // show results or tell them nothing matched their search
                if (result.Count == 0)
                {
                    Console.WriteLine("No such vehicle is present");
                }
                else
                {
                    Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                        "Registration No", "Name", "Type", "Weight", "Ticket No");

                    foreach (Vehicle v in result)
                    {
                        Console.WriteLine(v);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}