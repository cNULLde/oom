using System;
using NUnit.Framework;

namespace TicketingSystem
{
    class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
            : this("firstName", "lastName") { }

        public Person(string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(firstName))
                throw new ArgumentException("Employee can't have no firsts name", nameof(firstName));
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentException("Employee can't have no last name", nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }
        
        
        #region IPerson

        public virtual void PrintPersonData()
        {
            Console.Out.WriteLine("{0} {1}", FirstName, LastName);
        }

        public void PrintFullName()
        {
            Console.Out.WriteLine("{0} {1}", FirstName, LastName);
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        #endregion
    }
}
