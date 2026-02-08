using System;
using System.Collections.Generic;

namespace Requirement_5
{
    class ParkedTimeComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle v1, Vehicle v2)
        {
            try
            {
                return v1.Ticket.ParkedTime.CompareTo(v2.Ticket.ParkedTime);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}