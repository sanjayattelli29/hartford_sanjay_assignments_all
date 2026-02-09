using System;
using System.Collections.Generic;

namespace Requirement_5
{
    // implements IComparable so we can sort vehicles by weight
    class Vehicle : IComparable<Vehicle>
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

        private double _weight;
        public double Weight
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

        public Vehicle(string registrationNo, string name,
                       string type, double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        public Vehicle() { }

        // breaks apart comma separated string into vehicle parts
        public static Vehicle CreateVehicle(string detail)
        {
            string[] data = detail.Split(',');

            // make ticket from pieces 4,5,6
            Ticket ticket = new Ticket(
                data[4].Trim(),
                DateTime.ParseExact(data[5].Trim(), "dd-MM-yyyy HH:mm:ss", null),
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

        // compares this vehicle weight to another for sorting
        public int CompareTo(Vehicle other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return string.Format("{0,-15}{1,-10}{2,-12}{3,-7}{4}",
                RegistrationNo,
                Name,
                Type,
                Weight.ToString("F1"),
                Ticket.TicketNo);
        }
    }
}