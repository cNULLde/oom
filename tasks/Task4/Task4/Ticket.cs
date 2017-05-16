using System;
using System.Collections.Generic;

namespace Task2
{
    public enum OpeningChannel
    {
        Call, CallPersonal,
        Mail, MailPersonal,
        Chat, ChatPersonal,
        Online, Proactive
    }

    class TicketLog
    {
        public DateTime LogDateTime { get; set; }
        public string LogData { get; set; }
        public Employee Author { get; set; }

        public TicketLog(DateTime logDateTime, string logData, Employee author)
        {
            LogDateTime = logDateTime;
            LogData = logData;
            Author = author;
        }


        public void PrintTicketLog()
        {
            Console.WriteLine("Date: {0}, Author: {1}, LogData: {2}", LogDateTime, Author.GetFullName(), LogData);
        }
    }

    class Ticket
    {
        #region Fields
        private static int _runningTicketnumber = 0;
        private readonly SortedList<int, TicketLog> _ticketLog;
        private int _ticketLogIndex = 0;
        #endregion


        #region Constructors
        private Ticket(DateTime openDate, Employee openedBy)
        {
            Ticketnumber = _runningTicketnumber++;
            _ticketLog = new SortedList<int, TicketLog>();

            OpenDate = openDate;
            OpenedBy = openedBy;
        }

        private Ticket(DateTime openDate, Employee openedBy, string description)
            : this(openDate, openedBy) { Description = description; }
        

        public Ticket(Employee openedBy, string description)
            : this(DateTime.Now, openedBy, description) { }
        #endregion

        
        #region Properties
        public int Ticketnumber { get; set; }
        public DateTime OpenDate { get; set; }
        public Employee OpenedBy { get; set; }
        public OpeningChannel OpeningChannel { get; set; }
        public string Description { get; private set; }
        public SortedList<int, TicketLog> TicketLog => _ticketLog;
        #endregion
        

        #region Methods
        public void UpdateDescription(string description)
        {
            Description = description;
        }

        public void AddLogEntry(string logData, Employee author)
        {
            var entry = new TicketLog(DateTime.Now, logData, author);
            _ticketLog.Add(_ticketLogIndex++, entry);
        }

        public void AddLogEntry(DateTime dateTime, string logData, Employee author)
        {
            var entry = new TicketLog(dateTime, logData, author);
            _ticketLog.Add(_ticketLogIndex++, entry);
        }

        public void PrintTicketLog()
        {
            foreach (var entry in _ticketLog)
                entry.Value.PrintTicketLog();
        }

        public void PrintAllTicketInfo()
        {
            Console.WriteLine("####################");
            Console.WriteLine("### Ticket {0}", Ticketnumber);
            Console.WriteLine("##########");
            Console.WriteLine("### Opened by {0} on {1}", OpenedBy.GetFullName(), OpenDate);
            Console.WriteLine("##########");
            Console.WriteLine("### Description: {0}", Description);
            Console.WriteLine("##########");
            Console.WriteLine("### Ticketlog entries:");
            Console.WriteLine("##########");
            foreach (var entry in _ticketLog)
            {
                entry.Value.PrintTicketLog();
            }
            Console.WriteLine("####################");
        } 
        #endregion
    }
}