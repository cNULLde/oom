using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var empA = new Employee("Emp", "A");
            var empB = new Employee("Emp", "B");
            var empC = new Employee("Emp", "C");
            var empD = new Employee("Emp", "D");

            var list = new List<Ticket>
            {
                new Ticket(empA, "Description 1"),
                new Ticket(DateTime.Now, empB),
                new Ticket(DateTime.Now, empC, "Description 2")
            };

            foreach (var ticket in list)
                for (var i = 0; i < 5; i++)
                    ticket.AddLogEntry($"Logentry{i} for Ticket {ticket.Ticketnumber}", empD);
                
            foreach (var ticket in list)
                ticket.PrintAllTicketInfo();


            var personList = new List<IPerson>
            {
                empA, empB, empC,
                new Customer("Customer", "A")
            };


            foreach (var person in personList)
            {
                Console.Out.Write(person.GetType().ToString().Split('.')[1] + ": ");
                person.PrintPersonData();
            }
            Console.Read();
        }
    }
}
