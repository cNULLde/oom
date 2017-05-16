using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public Person()
            : this("firstName", "lastName") { }

        public Person(string firstName, string lastName)
        {
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

        #endregion
    }
}
