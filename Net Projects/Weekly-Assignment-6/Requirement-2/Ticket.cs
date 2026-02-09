using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_2
{
    // ticket holds parking info for each vehicle
    class Ticket
    {
        //private fields and public properties
        private string _ticketNo;
        public string TicketNo
        {
            get { return _ticketNo; }
            set { _ticketNo = value; }
        }

        private DateTime _parkedTime;
        public DateTime ParkedTime
        {
            get { return _parkedTime; }
            set { _parkedTime = value; }
        }

        private Double _cost;
        public Double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        //default constructor
        public Ticket() { }

        // takes ticket number, time parked, and cost then saves them
        //parameterized constructor
        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            _ticketNo = ticketNo;
            _parkedTime = parkedTime;
            _cost = cost;
        }
    }
}