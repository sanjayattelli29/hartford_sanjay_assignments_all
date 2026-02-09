using Requirement_2;
using System;
using System.Collections.Generic;

namespace ParkingLotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ask user to type parking lot name, whatever they type goes into name variable
            Console.WriteLine("Enter the name of the Parking Lot:");
            string name = Console.ReadLine();

            // make new parking lot with that name, starts with empty list
            ParkingLot parkingLot = new ParkingLot(name, new List<Vehicle>());

            // keep looping till user picks exit option
            while (true)
            {
                Console.WriteLine("1.Add Vehicle");
                Console.WriteLine("2.Delete Vehicle");
                Console.WriteLine("3.Display Vehicles");
                Console.WriteLine("4.Exit");
                Console.WriteLine("Enter your choice:");
                // whatever number user types becomes choice
                int choice = int.Parse(Console.ReadLine());

                // if user picked 1, take their input and make a vehicle from it
                if (choice == 1)
                {
                    Vehicle vehicle =
                        Vehicle.CreateVehicle(Console.ReadLine());
                    parkingLot.AddVehicleToParkingLot(vehicle);
                    // tell them it worked
                    Console.WriteLine("Vehicle successfully added");
                }
                // if user picked 2, ask them which vehicle to delete by reg number
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the registration number of the vehicle to be deleted:");
                    string regNo = Console.ReadLine();

                    bool removed =
                        parkingLot.RemoveVehicleFromParkingLot(regNo);

                    // tell them if we deleted it or couldnt find it
                    if (removed)
                        Console.WriteLine("Vehicle successfully deleted");
                    else
                        Console.WriteLine("Vehicle not found in parkinglot");
                }
                // choice 3 shows all vehicles in the lot
                else if (choice == 3)
                {
                    parkingLot.DisplayVehicles();
                }
                // choice 4 breaks the loop so program ends
                else if (choice == 4)
                {
                    break;
                }
            }
        }
    }
}