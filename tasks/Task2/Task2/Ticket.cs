using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public enum OpeningChannel
    {
        Call, CallPersonal,
        Mail, MailPersonal,
        Chat, ChatPersonal,
        Online,
        Proactive
    }

    struct TicketLog
    {
        public DateTime dateTime;
        public string logData;

        public TicketLog(DateTime dateTime, string logData)
        {
            this.dateTime = dateTime;
            this.logData = logData;
        }
    }

    class Ticket
    {
        /* fields */
        private static int runningTicketnumber = 0;
        private int ticketnumber;
        private DateTime openDate;
        private string openedBy;
        private OpeningChannel openingChannel;
        private string description;
        private readonly SortedList<int, TicketLog> ticketLog;
        private int ticketLogIndex = 0;


        /* constructors */
        public Ticket(DateTime openDate, string openedBy)
        {
            ticketnumber = runningTicketnumber++;
            ticketLog = new SortedList<int, TicketLog>();

            this.openDate = openDate;
            this.openedBy = openedBy;
        }

        public Ticket()
            : this(DateTime.Now, string.Empty) { }

        public Ticket(string openedBy)
            : this(DateTime.Now, openedBy) { }

        public Ticket(string openedBy, string description)
            : this(DateTime.Now, openedBy, description) { }

        public Ticket(DateTime openDate, string openedBy, string description)
            : this(DateTime.Now, openedBy)
        { this.description = description; }


        /* properties */
        public int Ticketnumber {
            get { return ticketnumber; }
        }

        public DateTime OpenDate {
            get { return openDate; }
        }

        public string OpenedBy
        {
            get { return openedBy; }
            set { openedBy = value; }
        }

        public OpeningChannel OpeningChannel
        {
            get { return openingChannel; }
            set { openingChannel = value; }
        }

        public string Description
        {
            get { return description; }
        }

        public SortedList<int, TicketLog> TicketLog
        {
            get { return this.ticketLog; }
        }
        

        /* methods */
        public void UpdateDescription(string description)
        {
            this.description = description;
        }

        public void AddLogEntry(string logData)
        {
            var entry = new TicketLog(DateTime.Now, logData);
            ticketLog.Add(this.ticketLogIndex++, entry);
        }

        public void AddLogEntry(DateTime dateTime, string logData)
        {
            var entry = new TicketLog(dateTime, logData);
            ticketLog.Add(this.ticketLogIndex++, entry);
        }

        public void PrintTicketLog()
        {
            foreach (var entry in ticketLog)
            {
                Console.Out.WriteLine("Entry {0}: {1} {2}", entry.Key ,entry.Value.dateTime, entry.Value.logData);
            }
        }

        public void PrintAllTicketInfo()
        {
            Console.Out.WriteLine("##########");
            Console.Out.WriteLine("### Ticket {0}", ticketnumber);
            Console.Out.WriteLine("##########");
            Console.Out.WriteLine("### Opened by {0} on {1}", openedBy, openDate);
            Console.Out.WriteLine("##########");
            Console.Out.WriteLine("### Description: {0}", description);
            Console.Out.WriteLine("##########");
            Console.Out.WriteLine("### Ticketlog entries:");
            Console.Out.WriteLine("##########");
            foreach (var entry in ticketLog)
            {
                Console.Out.WriteLine("# Entry {0}: {1} {2}", entry.Key, entry.Value.dateTime, entry.Value.logData);
            }
            Console.Out.WriteLine("##########");
        }
    }

}