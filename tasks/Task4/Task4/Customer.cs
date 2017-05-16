using System;

namespace Task2
{
    class Customer : Person
    {
        private static int _customerID = 0;

        public Customer(string firstName, string lastName)
            : base(firstName, lastName)
        {
            CustomerID = _customerID++;
        }


        public int CustomerID { get; }

        #region IPerson

        public override void PrintPersonData()
        {
            Console.Out.WriteLine("{0}: {1} {2}", CustomerID, FirstName, LastName);
        }

        #endregion
    }
}