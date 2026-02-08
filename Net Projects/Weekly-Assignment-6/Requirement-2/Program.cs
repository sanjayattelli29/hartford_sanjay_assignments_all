using Requirement_2;
using System;
using System.Collections.Generic;

namespace ParkingLotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the Parking Lot:");
            string name = Console.ReadLine();

            ParkingLot parkingLot = new ParkingLot(name, new List<Vehicle>());

            while (true)
            {
                Console.WriteLine("1.Add Vehicle");
                Console.WriteLine("2.Delete Vehicle");
                Console.WriteLine("3.Display Vehicles");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Vehicle vehicle = Vehicle.CreateVehicle(Console.ReadLine());
                    parkingLot.AddVehicleToParkingLot(vehicle);
                    Console.WriteLine("Vehicle successfully added");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the registration number of the vehicle to be deleted:");
                    string regNo = Console.ReadLine();

                    bool removed = parkingLot.RemoveVehicleFromParkingLot(regNo);

                    if (removed)
                        Console.WriteLine("Vehicle successfully deleted");
                    else
                        Console.WriteLine("Vehicle not found in parkinglot");
                }
                else if (choice == 3)
                {
                    parkingLot.DisplayVehicles();
                }
                else if (choice == 4)
                {
                    break;
                }
            }
        }
    }
}