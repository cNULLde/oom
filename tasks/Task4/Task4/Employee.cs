using System;

namespace Task4
{
    class Employee : Person
    {
        private static int _employeeID = 0;

        public Employee(string firstName, string lastName)
            : base(firstName, lastName)
        {
            EmployeeID = _employeeID++;
        }

        public int EmployeeID { get; }


        #region IPerson
        public override void PrintPersonData()
        {
            Console.Out.WriteLine("{0}: {1} {2}", EmployeeID, FirstName, LastName);
        } 
        #endregion
    }
}
