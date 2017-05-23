using System;
using Newtonsoft.Json;

namespace Task4
{
    class Customer : Person
    {
        private static int _customerID = 0;

        public Customer(string firstName, string lastName)
            : base(firstName, lastName)
        {
            CustomerID = _customerID++;
        }

        [JsonConstructor]
        public Customer(string firstName, string lastName, int customerID) : base(firstName, lastName)
        {
            CustomerID = customerID;
        }


        public int CustomerID { get; }

        #region IPerson

        public override void PrintPersonData()
        {
            Console.Out.WriteLine("CustID {0}: {1} {2}", CustomerID, FirstName, LastName);
        }

        #endregion
    }
}