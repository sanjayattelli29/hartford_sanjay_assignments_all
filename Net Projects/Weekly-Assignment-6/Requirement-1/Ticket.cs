using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_1
{
    public class Ticket
    {
        private string _ticketNo;
        public string TicketNo
        {
            get { return _ticketNo; }
            set { _ticketNo = value; }
        }

        private DateTime _parked_Time;
        public DateTime ParkedTime
        {
            get { return _parked_Time; }
            set { _parked_Time = value; }
        }

        private double _cost;
        public double Cost
        {
            get { return _cost; }
            set {_cost = value; }
        }

        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            _ticketNo = ticketNo;
            _parked_Time = parkedTime;
            _cost = cost;
        }

        public Ticket() { }
    }
}
