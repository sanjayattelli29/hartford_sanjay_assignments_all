using System;
using System.Collections.Generic;

namespace Requirement_5
{
    // custom comparer so we can sort vehicles by their parking time
    class ParkedTimeComparer : IComparer<Vehicle>
    {
        // compares parking times of two vehicles tickets
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