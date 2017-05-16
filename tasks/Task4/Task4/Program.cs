using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task2;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var empA = new Employee("Emp", "A");
            var empB = new Employee("Emp", "B");

            var list = new List<Ticket>
            {
                new Ticket(empA, "Description 1"),
                new Ticket(empB, "Description 2")
            };

            foreach (var ticket in list)
                for (var i = 0; i < 5; i++)
                    ticket.AddLogEntry($"Logentry {i} for Ticket {ticket.Ticketnumber}", empB);

            foreach (var ticket in list)
                ticket.PrintAllTicketInfo();

           Console.WriteLine("Serializing ....");


            string s = JsonConvert.SerializeObject(list.First());

            //File.Create(@"F:\Projects\Git\oom\tasks\Task4\Task4\ticket.json");

            File.WriteAllText(@"F:\Projects\Git\oom\tasks\Task4\Task4\ticket.json", s);

            string newTick = File.ReadAllText(@"F:\Projects\Git\oom\tasks\Task4\Task4\ticket.json");

            Ticket x = JsonConvert.DeserializeObject<Ticket>(newTick);

            Console.WriteLine("Deserializing ....");

            x.PrintAllTicketInfo();
        }
    }
}
