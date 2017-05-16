using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Employee : Person
    {
        private static int runningEmployeeID = 0;

        public Employee(string firstName, string lastName)
            : base(firstName, lastName)
        {
            EmployeeID = runningEmployeeID++;
        }

        public int EmployeeID { get; }
    }
}
