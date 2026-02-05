using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSDemo2
{
    public class DeptwiseComparer : IComparer<Emp>
    {
        public int Compare(Emp? x, Emp? y)
        {
            return x.EmpDept.CompareTo(y.EmpDept);
        }
    }

}
