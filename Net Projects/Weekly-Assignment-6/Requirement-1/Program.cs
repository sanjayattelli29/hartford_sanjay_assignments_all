using System;

namespace Requirement_1
{
    class Program
    {
        static Vehicle CreateVehicle(string input)
        {
            try
            {
                string[] data = input.Split(',');

                Ticket ticket = new Ticket(
                    data[4],
                    DateTime.ParseExact(
                        data[5],
                        "dd-MM-yyyy HH:mm:ss",
                        null),
                    double.Parse(data[6])
                );

                return new Vehicle(
                    data[0],
                    data[1],
                    data[2],
                    double.Parse(data[3]),
                    ticket
                );
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
                return null;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Vehicle 1 details:");
                Vehicle vehicle1 = CreateVehicle(Console.ReadLine());

                Console.WriteLine("Enter Vehicle 2 details:");
                Vehicle vehicle2 = CreateVehicle(Console.ReadLine());

                if (vehicle1 == null || vehicle2 == null)
                {
                    Console.WriteLine("Vehicle creation failed");
                    return;
                }

                Console.WriteLine("\nVehicle 1\n");
                Console.WriteLine(vehicle1);

                Console.WriteLine("\nVehicle 2\n");
                Console.WriteLine(vehicle2);

                if (vehicle1.Equals(vehicle2))
                    Console.WriteLine("\nVehicle 1 is same as Vehicle 2");
                else
                    Console.WriteLine("\nVehicle 1 and Vehicle 2 are different");
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error occurred");
            }
        }
    }
}