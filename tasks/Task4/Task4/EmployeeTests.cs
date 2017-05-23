using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    class EmployeeTests
    {

        [Test]
        public void CanCreateEmployee()
        {
            var e1 = new Employee("Test", "Employee");
            Assert.IsTrue( e1.FirstName == "Test");
            Assert.IsTrue( e1.LastName == "Employee");
        }

        [Test]
        public void TicketDontHaveSameNumber()
        {
            var e1 = new Employee("Test", "Employee");
            var e2 = new Employee("Test", "Employee");

            Assert.AreNotEqual(e1.EmployeeID, e2.EmployeeID);
        }

        [Test]
        public void CannotCreateEmployeeWithoutFirstName()
        {
            Assert.Catch(() =>
            {
                var t = new Employee(null, "only last name");
            });
        }

        [Test]
        public void CannotCreateEmployeeWithoutLastName()
        {
            Assert.Catch(() =>
            {
                var t = new Employee("only first name", null);
            });
        }
    }
}
