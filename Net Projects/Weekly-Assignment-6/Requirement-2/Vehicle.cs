using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    class Vehicle
    {
        private string _registrationNo;
        public string RegistrationNo
        {
            get { return _registrationNo; }
            set { _registrationNo = value; }
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
            set { _type = value; }
        }

        private Double _weight;
        public Double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private Ticket _ticket;
        public Ticket Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        public Vehicle() { }

        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }
        
        public static Vehicle CreateVehicle(string detail)
        {
            string[] data = detail.Split(',');
            Ticket ticket = new Ticket(
                data[4].Trim(),
                DateTime.ParseExact(
                    data[5].Trim(),
                    "dd-MM-yyyy HH:mm:ss", null),
                     double.Parse(data[6].Trim())
                );
            return new Vehicle(
                data[0].Trim(),
                data[1].Trim(),
                data[2].Trim(),
                double.Parse(data[3].Trim()),
                ticket
                );
        }

        public override string ToString() {
            return string.Format("{0,-15} {1,-10} {2,-12} {3,-7} {4}", RegistrationNo, Name, Type, Weight.ToString("F1"), Ticket.TicketNo);
        }
    }
}
