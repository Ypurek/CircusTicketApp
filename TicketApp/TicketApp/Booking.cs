using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

namespace TicketApp
{

    [Serializable]
    public class Ticket
    {
        private static Random r = new Random();

        const int bookingTimeout = 5;
        
        private int id;
        private DateTime date;
        private int time;
        private string program;
        private TicketStatus status;
        private DateTime bookingTime;
        private string bookingUser;

        public string Pet = "";
        public bool Snack = false;

        public DateTime Date { get { return date; } }
        public int Time { get { return time; } }
        public TicketStatus Status { get { return status; }}
        public string ID { get { return id.ToString(); } }
        public string Program { get { return program; } }

        public Ticket()
        {
            id = r.Next(10000000, 99999999);
            status = TicketStatus.Available;
        }

        public Ticket(string program) : this()
        {
            this.program = program;
        }

        public Ticket(string program, DateTime date, int time)
            : this(program)
        {
            this.date = date;
            this.time = time;
        }

        
        public void Book(User user)
        {
            status = TicketStatus.Book;
            bookingTime = DateTime.Now;
            bookingUser = user.Login;
        }

        public void Buy()
        {
            status = TicketStatus.Buy;
        }

        /// <summary>
        /// returns false if user cannot buy ticket
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool BuyBack(User user)
        {
            if (bookingUser != user.Login)
                return false;

            if ((DateTime.Now - bookingTime).TotalMinutes > bookingTimeout)
                return false;

            status = TicketStatus.Buy;
            return true;
        }

        public void Unbook()
        {
            if ((status == TicketStatus.Book) && (DateTime.Now - bookingTime).TotalMinutes > bookingTimeout)
                status = TicketStatus.Available;
        }
    }

    public class TicketManager
    {
        private List<Ticket> ticketList;
        private string fileName;
        private Timer timer;

        public TicketManager(string fileName)
        {
            this.fileName = fileName;
            readTicketsDB();
            timer = new Timer(1 * 60 * 1000); // once a minute
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Refresh();
        }

        public void writeTicketsDB()
        {
            writeTicketsDB(ticketList, fileName);
        }
        
        public void writeTicketsDB(List<Ticket> TicketList, string fileName)
        {
            // work with files. try-catch for noobs
            FileStream stream = File.Create(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, TicketList);
            stream.Close();
        }

        public void readTicketsDB()
        {
            ticketList = readTicketsDB(fileName);
        }
        
        public List<Ticket> readTicketsDB(string fileName)
        {
            if (!File.Exists(fileName))
                return null;

            List<Ticket> TicketList;

            // work with files. try-catch for noobs
            FileStream stream = File.OpenRead(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            TicketList = (List<Ticket>)formatter.Deserialize(stream);
            stream.Close();

            foreach (Ticket t in TicketList)
            {
                if (t.Date < DateTime.Today)
                {
                    t.Buy();
                    continue;
                }
                if (t.Time < DateTime.Now.Hour && t.Date == DateTime.Today)
                    t.Buy();
            }

            return TicketList;
        }

        public List<Ticket> GetTicketsByDate(DateTime date)
        {
            return ticketList.FindAll(x =>
                   x.Date.Day == date.Day &&
                   x.Date.Month == date.Month &&
                   x.Date.Year == date.Year);
        }

        public List<Ticket> GetAvailableTicketsByDateTime(DateTime date, int time)
        {
            List<Ticket> list = GetTicketsByDate(date);
            return list.FindAll(x => x.Time == time && x.Status == TicketStatus.Available);
        }

        public Ticket Book(DateTime date, int time, User user)
        {
            Ticket t = null;
            
            List<Ticket> list = GetAvailableTicketsByDateTime(date, time);
            if (list.Count > 0)
                (t = list[0]).Book(user);

            writeTicketsDB();
            return t;
        }

        public void Refresh()
        {
            foreach (Ticket t in ticketList)
                t.Unbook();
            
            writeTicketsDB();
        }

        public Ticket GetBookedTicketByID(string id)
        {
            return ticketList.Find(x => x.ID == id && x.Status == TicketStatus.Book);
        }
    }

    public enum TicketStatus
    {
        Available = 0,
        Book = 1,
        Buy = 2
    }

    
}
