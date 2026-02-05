namespace OOPSDemo2
{
    public class Emp : IComparable<Emp>
    {
        private int empId;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
        private string empName;

        public string EmpName
        {
            get { return empName; }
            set { empName = value; }
        }
        private string empDept;

        public string EmpDept
        {
            get { return empDept; }
            set { empDept = value; }
        }


        private decimal empSalary;

        public decimal EmpSalary
        {
            get { return empSalary; }
            set { empSalary = value; }
        }

       

        public Emp()
        {

        }
        public Emp(int empid, string empname, string empdept, decimal empsalary)
        {
            EmpId = empid;
            EmpName = empname;
            EmpDept = empdept;
            EmpSalary = empsalary;
        }
        public override bool Equals(object? obj)
        {
            Emp e = obj as Emp;

            return this.EmpId.Equals(e.EmpId);
        }

        public override int GetHashCode()
        {
            return this.EmpId.GetHashCode();
        }

        override public string ToString()
        {
            return $"EmpId: {EmpId}, EmpName: {EmpName}, EmpDept: {EmpDept}, EmpSalary: {EmpSalary}";
        }

        public int CompareTo(Emp? other)
        {
            return this.EmpSalary.CompareTo(other.EmpSalary);
        }
    }

}


/*
Emp e1 = new Emp { EmpName = "John", EmpId = 101, EmpDept = "IT", EmpSalary = 50000 };
            List<Emp> elist = new List<Emp> { 
                e1,
                new Emp { EmpName = "Jane", EmpId = 102, EmpDept = "HR", EmpSalary = 60000 },
                new Emp { EmpName = "Mike", EmpId = 103, EmpDept = "Finance", EmpSalary = 70000 }
            };

 * */