using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TicketApp
{
    class Booking
    {
        // private string 
        
        public void Bookong()
        {

        }

        public void ReadProgram(string filepath)
        {
            StreamReader stream = null;
            if (File.Exists(filepath))
            {
                stream = File.OpenText(filepath);
                return;
            }

            
            // expected structure
            // 
            // date; set of performance times; text of program
            //
            while (!stream.EndOfStream)
            {
                stream.ReadLine().Split(new char[1]{';'});
            }


            
            
            //MemoryMappedFile.CreateFromFile(filepath, System.IO.FileMode.Open);
        }
    }

    [Serializable]
    public class User
    {
        private string login;
        private string password;
        private string creditCard;
        private DateTime birthDay;
        private System.Drawing.Image photo;

        public string Login { get { return login; } }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public System.Drawing.Image Photo { get { return this.photo; } }
        public string CreditCard { get { return this.creditCard; } }
        public DateTime BirthDay { get { return this.birthDay; } }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            this.photo = null;
            this.creditCard = "";
            this.birthDay = new DateTime();
        }

        public void SetPhoto(System.Drawing.Image photo)
        {
            this.photo = photo;
        }
    }

    [Serializable]
    public class Ticket
    {
        private Guid id;
        private DateTime date;
        private int time;
        private string program;
        private TicketStatus status;
        private DateTime bookingTimeout;

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

        public void Book()
        {
            status = TicketStatus.Book;
            bookingTimeout = DateTime.Now;
        }

        public void Buy()
        {
            status = TicketStatus.Buy;
        }
    }

    public enum TicketStatus
    {
        Available = 0,
        Book = 1,
        Buy = 2
    }

    
}
