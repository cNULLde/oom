using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task4;

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

            //#region SingleObjectSerialisation
            //Console.WriteLine("Serializing ....");
            //string s = JsonConvert.SerializeObject(list.First());
            //File.WriteAllText(@"F:\Projects\Git\oom\tasks\Task4\Task4\ticket.json", s);
            //string newTick = File.ReadAllText(@"F:\Projects\Git\oom\tasks\Task4\Task4\ticket.json");
            //Ticket x = JsonConvert.DeserializeObject<Ticket>(newTick);
            //Console.WriteLine("Deserializing ....");

            //x.PrintAllTicketInfo();
            //#endregion


            #region SerializeListOfIPerson
            var persons = new List<IPerson>
            {
                new Employee("listemp1","listemp1"),
                new Customer("listcus1","listcus1"),
                new Employee("listemp2","listemp2"),
                new Customer("listcus2","listcus2"),
            };

            var personsJson = JsonConvert.SerializeObject(persons, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });

            File.WriteAllText(@"F:\Projects\Git\oom\tasks\Task4\Task4\persons.json", personsJson);
            var newPersonJson = File.ReadAllText(@"F:\Projects\Git\oom\tasks\Task4\Task4\persons.json");

            var newPersons = JsonConvert.DeserializeObject<List<IPerson>>(newPersonJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });

            foreach (var person in newPersons)
                person.PrintPersonData();
            #endregion

        }
    }
}
