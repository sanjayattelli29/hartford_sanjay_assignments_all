using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Requirement_1
{
    public class Vehicle
    {
        private string _registration_no;
        public string Registration_No
        {
            get { return _registration_no; }
            set { _registration_no = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set {  _type = value; }
        }

        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set { _weight= value; }
        }

        private Ticket _ticket;
        public Ticket Ticket
        { 
            get { return _ticket; } 
            set { _ticket = value; } 
        }

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            _registration_no = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        public override string ToString()
        {
            return "Registration No:" + Registration_No + "\n" + "Name:" + Name + "\n" + "Type:" + Type +"\n" + "Weight:" + Weight.ToString("F1") + "\n" + "Ticket No:" + Ticket.TicketNo;
        }

        public override bool Equals(object obj)
        {
            Vehicle vehicle = obj as Vehicle;
            if (vehicle == null)
            {
                return false;
            }

            return Registration_No.Equals(vehicle.Registration_No,
                        StringComparison.OrdinalIgnoreCase)
                && Name.Equals(vehicle.Name,
                        StringComparison.OrdinalIgnoreCase);
        }
    }
}
