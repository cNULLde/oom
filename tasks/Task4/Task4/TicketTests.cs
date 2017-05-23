using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4;

namespace Task4
{
    [TestFixture]
    class TicketTests
    {
        [Test]
        public void CanCreateTicket()
        {
            var emp = new Employee("Test", "Employee");
            var t1 = new Ticket(emp, "Something's wrong");

            Assert.IsTrue( t1.Description == "Something's wrong");
            Assert.IsTrue( t1.OpenedBy.FirstName == emp.FirstName);
            Assert.IsTrue( t1.OpenedBy.LastName == emp.LastName);
            Assert.AreSame(t1.OpenedBy, emp);
        }

        [Test]
        public void CannotCreateTicketWithoutOpener()
        {
            Assert.Catch(() =>
            {
                var t = new Ticket(null, "No emp created this :O");
            });
        }

        [Test]
        public void CannotCreateTicketWithoutDescription()
        {
            var emp = new Employee("Test", "Employee");
            Assert.Catch(() =>
            {
                var t = new Ticket(emp, null);
            });
        }

        [Test]
        public void CanCreateTicketWithoutDescription()
        {           
            var emp = new Employee("Test", "Employee");
            var t1 = new Ticket(emp, "");

            Assert.IsTrue( t1.Description == "");
            Assert.IsTrue( t1.OpenedBy.FirstName == emp.FirstName);
            Assert.IsTrue( t1.OpenedBy.LastName == emp.LastName);
            Assert.AreSame(t1.OpenedBy, emp);
        }

        [Test]
        public void TicketDontHaveSameNumber()
        {
            var emp = new Employee("Test", "Employee");
            var t1 = new Ticket(emp, "Something's wrong");
            var t2 = new Ticket(emp, "Something's fuckey");

            Assert.AreNotEqual(t1.Ticketnumber, t2.Ticketnumber);
        }

    }
}