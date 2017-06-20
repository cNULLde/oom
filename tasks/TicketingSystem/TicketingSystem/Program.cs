using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Console;

namespace TicketingSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            //TicketSpamming();
            TaskRun();
            
        }

        static void TicketPrinting()
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
        }

        static void SerializeListOfIPerson()
        {
            var persons = new List<IPerson>
            {
                new Employee("listemp1", "listemp1"),
                new Customer("listcus1", "listcus1"),
                new Employee("listemp2", "listemp2"),
                new Customer("listcus2", "listcus2"),
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
        }

        #region OldTicketSpamming

        static IEnumerable<Ticket> EndlessBarrageOfTickets()
        {
            var emps = new List<Employee>()
            {
                new Employee("emp0", "emp0"),
                new Employee("emp1", "emp1"),
                new Employee("emp2", "emp2")
            };

            var random = new Random();

            for (;;)
            {
                // Return tickets opened by random employees at random intervals
                yield return new Ticket(emps[random.Next(emps.Count)], "totally useful description");
                Thread.Sleep(random.Next(500));
            }
        }

        static void TicketSpam()
        {
            var myInbox = EndlessBarrageOfTickets().ToObservable();
            var getNewTicketsEveryThreeSeconds = myInbox.Buffer(TimeSpan.FromSeconds(3));

            getNewTicketsEveryThreeSeconds.Subscribe(tickets =>
            {
                Console.WriteLine("You've got {0} new tickets! Here they are!", tickets.Count());
                foreach (var ticket in tickets)
                {
                    Console.WriteLine("> {0}", ticket.Ticketnumber);
                }
                Console.WriteLine();
            });

            Console.ReadKey();

        }

        #endregion

        static void TicketSpamming()
        {
            var source = new Subject<Ticket>();

            source
                .Sample(TimeSpan.FromSeconds(1.0)) // check latest ticket every 1 sec
                .Subscribe(x => Console.WriteLine($"last ticket received: {x.Ticketnumber} by {x.OpenedBy.GetFullName()}"))
                ;

            var t = new Thread(() =>
            {
                var i = 0;
                while (true)
                {
                    Thread.Sleep(500);
                    var tick = new Ticket(new Employee($"firstName{i}", $"lastName{i}"), $"description {i}");
                    source.OnNext(tick);
                    Console.WriteLine($"sent {tick.Ticketnumber} by {tick.OpenedBy.FirstName}");
                    i++;
                }                
            });
            t.Start();
        }

        #region Task

        public static void TaskRun()
        {
            var random = new Random();

            var emp0 = new Employee("emp0","emp0");

            var xs = new List<Ticket> ();

            for (int i = 0; i < 5; i++)
                xs.Add(new Ticket(emp0, "ticket" + i));
            
            var tasks = new List<Task<Ticket>>();

            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {
                    WriteLine("changing ticket description");
                    Task.Delay(TimeSpan.FromSeconds(5.0 + random.Next(10))).Wait();
                    x.UpdateDescription("new description");
                    return x;
                });

                tasks.Add(task);
            }

            WriteLine("doing something else ...");

            var tasks2 = new List<Task<Ticket>>();
            foreach (var task in tasks)
            {
                tasks2.Add(
                    task.ContinueWith(t => { WriteLine($"new description for {t.Result.Ticketnumber} is {t.Result.Description}"); return t.Result; })
                );
            }

            var cts = new CancellationTokenSource();
            var primeTask = ComputePrimes(cts.Token, xs);

            ReadLine();
            cts.Cancel();
            WriteLine("canceled ComputePrimes");
            ReadLine();
        }

        public static Task<bool> IsPrime(int x, CancellationToken ct)
        {
            return Task.Run(() =>
            {
                for (var i = 2; i < x - 1; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    if (x % i == 0) return false;
                }
                return true;
            }, ct);
        }

        public static async Task ComputePrimes(CancellationToken ct, List<Ticket> tickets )
        {
            foreach (var t in tickets)
            {
                ct.ThrowIfCancellationRequested();
                if (await IsPrime(t.Ticketnumber, ct)) WriteLine($"Ticket {t.Ticketnumber} is a primenumber");
            }
        }

        #endregion
    }
}