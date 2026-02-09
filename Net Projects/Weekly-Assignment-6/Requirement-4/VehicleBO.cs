using System;
using System.Collections.Generic;

namespace Requirement_4
{
    // business logic for searching vehicles different ways
    class VehicleBO
    {
        // finds all vehicles matching the type you give it
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            try
            {
                List<Vehicle> result = new List<Vehicle>();

                // go through all vehicles and grab ones that match type ignoring case
                foreach (Vehicle v in vehicleList)
                {
                    if (v.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(v);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return new List<Vehicle>();
            }
        }

        // overloaded method finds vehicles by parking time instead
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            try
            {
                List<Vehicle> result = new List<Vehicle>();

                // loop and match exact parking time from ticket
                foreach (Vehicle v in vehicleList)
                {
                    if (v.Ticket.ParkedTime == parkedTime)
                    {
                        result.Add(v);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return new List<Vehicle>();
            }
        }
    }
}