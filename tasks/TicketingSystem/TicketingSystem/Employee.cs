using System;
using Newtonsoft.Json;

namespace TicketingSystem
{
    class Employee : Person
    {
        private static int _employeeID = 0;

        public Employee(string firstName, string lastName)
            : base(firstName, lastName)
        {
            EmployeeID = _employeeID++;
        }

        [JsonConstructor]
        public Employee(string firstName, string lastName, int employeeID) : base(firstName, lastName)
        {
            EmployeeID = employeeID;
        }

        public int EmployeeID { get; }


        #region IPerson
        public override void PrintPersonData()
        {
            Console.Out.WriteLine("EmpID {0}: {1} {2}", EmployeeID, FirstName, LastName);
        } 
        #endregion
    }
}
