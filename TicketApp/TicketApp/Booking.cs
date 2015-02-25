using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TicketApp
{

    [Serializable]
    public class Ticket
    {
        const int bookingTimeout = 5;
        
        private Guid id;
        private DateTime date;
        private int time;
        private string program;
        private TicketStatus status;
        private DateTime bookingTime;
        private string bookingUser;

        public string ID { get { return id.ToString().Remove(9); } }
        public string Program { get { return program; } }

        public Ticket()
        {
            id = new Guid();
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

    public enum TicketStatus
    {
        Available = 0,
        Book = 1,
        Buy = 2
    }

    
}
