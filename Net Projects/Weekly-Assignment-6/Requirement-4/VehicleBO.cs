using System;
using System.Collections.Generic;

namespace Requirement_4
{
    class VehicleBO
    {
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            try
            {
                List<Vehicle> result = new List<Vehicle>();

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

        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            try
            {
                List<Vehicle> result = new List<Vehicle>();

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