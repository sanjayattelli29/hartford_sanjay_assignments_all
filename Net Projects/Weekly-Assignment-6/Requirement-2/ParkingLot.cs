using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    class ParkingLot
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private List<Vehicle> _vehicleList;
        public List<Vehicle> VehicleList
        {
            get { return _vehicleList; }
            set { _vehicleList = value; }
        }
        public ParkingLot()
        {
            _vehicleList = new List<Vehicle>();
        }
        // creates parking lot with name, starts with empty vehicle list
        public ParkingLot(string name,List<Vehicle> vehicleList)
        {
            _name = name;
            _vehicleList = new List<Vehicle>();
        }

        // takes a vehicle and adds it to the list
        //Add Vehicle
        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            _vehicleList.Add(vehicle);
        }
        // looks for vehicle by registration number and removes it if found
        //Remove Vehicle
        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            // check each vehicle till we find matching registration
            foreach(Vehicle v in _vehicleList)
            {
                if(v.RegistrationNo == registrationNo)
                {
                    _vehicleList.Remove(v);
                    return true;
                }
            }
            // didnt find it so return false
            return false;
        }

        // shows all vehicles or says none if list is empty
        //Displays vehicles
        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
            }
            else
            {
                // print header then loop through and print each vehicle
                Console.WriteLine("Vehicles in" + _name);
                Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}", "Registration No", "Name", "Type", "Weight", "Ticket no");
                foreach (Vehicle v in _vehicleList)
                {
                    Console.WriteLine(v);
                }

            }
        }
    }
}