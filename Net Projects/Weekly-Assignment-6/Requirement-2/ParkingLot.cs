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

        public ParkingLot(string name,List<Vehicle> vehicleList)
        {
            _name = name;
            _vehicleList = new List<Vehicle>();
        }

        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            _vehicleList.Add(vehicle);
        }

        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            foreach(Vehicle v in _vehicleList)
            {
                if(v.RegistrationNo == registrationNo)
                {
                    _vehicleList.Remove(v);
                    return true;
                }
            }
            return false;
        }

        public void DisplayVehicles()
        {
            if (_vehicleList.Count == 0)
            {
                Console.WriteLine("No vehicles to show");
            }
            else
            {
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
