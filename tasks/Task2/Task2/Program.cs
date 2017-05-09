using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Ticket>
            {
                new Ticket("Carlos", "Description 1"),
                new Ticket(DateTime.Now, "Harald"),
                new Ticket(DateTime.Now, "Tayel", "Description 2")
            };

            foreach (var ticket in list)
                for (var i = 0; i < 5; i++)
                    ticket.AddLogEntry($"Logentry{i} for Ticket {ticket.Ticketnumber}");
                
            foreach (var ticket in list)
                ticket.PrintAllTicketInfo();

            Console.Read();
        }
    }
}
