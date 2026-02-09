using System;
using System.Collections.Generic;

namespace Requirement_6
{
    class Vehicle
    {
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Vehicle(string registrationNo, string name, string type, double weight)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
        }

        // parse input string and make vehicle object from it
        public static Vehicle CreateVehicle(string detail)
        {
            try
            {
                string[] data = detail.Split(',');

                // create vehicle from the 4 comma separated values
                return new Vehicle(
                    data[0].Trim(),
                    data[1].Trim(),
                    data[2].Trim(),
                    double.Parse(data[3].Trim())
                );
            }
            catch (Exception)
            {
                // if parsing fails just return nothing
                Console.WriteLine("Invalid vehicle input");
                return null;
            }
        }

        // counts how many of each vehicle type exists
        public static SortedDictionary<string, int>
            TypeWiseCount(List<Vehicle> vehicleList)
        {
            try
            {
                SortedDictionary<string, int> result =
                    new SortedDictionary<string, int>();

                // loop through vehicles adding them to dictionary by type
                foreach (Vehicle v in vehicleList)
                {
                    // if type not seen before add it with count zero
                    if (!result.ContainsKey(v.Type))
                    {
                        result[v.Type] = 0;
                    }
                    // bump up the count for this type
                    result[v.Type]++;
                }
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine("Error while counting vehicles");
                return new SortedDictionary<string, int>();
            }
        }
    }
}