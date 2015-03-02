using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketApp;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TicketGenerator
{
    class Program
    {
        static string help =
        @"TICKET GENERATOR
        app created to perform testing of Ticket App
        creates DB of tickets
        
HOW TO USE

TicketGenerator.exe [StartDate] [EndDate] [StartTime] [EndTime] [TicketNumber] [Program] [key]
        StartDate - 1st day to buy ticket in app. Format dd-mm-yyyy
        EndDate -  last day to buy ticket in app. Format dd-mm-yyyy
        StartTime - earliest time to book/buy ticket every day. from 10 to 21
        EndTime - lates time to book/buy ticket every day. from 11 to 22
        TicketNumber - number of available tickets to each performance. from 1 to 3
        Program of performance - text. set -R to make random generated programs;
        Key : -create - creates/overwrites tickets DB
              -add - adds new records to tickets DB";

        const int variants = 4;
        static string[] programs = new string[variants]
        {
            "Увидеть живого белого слона и всемирно известный аттракцион иллюзий, который объездил почти весь мир. Насладиться полетами призеров Международного фестиваля воздушных гимнастов. Стать свидетелями сенсационного представления от лучшего жонглера мира, а также вас ждут выступления фокусников, клоунов, глотателей огня... и буря незабываемых эмоций!",
            "Бурые медведи на велосипедах, прыгающие сквозь огонь собаки, трюки без страховки прямо под куполом цирка от призеров крупнейших фестивалей цирка, захватывающие дух акробатические номера и чудесные перевоплощения, выступление талантливого итальянского укротителя Эммануэля Фарины с львами и тиграми…",
            "Аргонавты\" - яркое и красочное театрально-цирковое шоу по мотивам знаменитой древнегреческой легенды о путешествии мореплавателей корабля \"Арго\" за золотым руном. Предводимые мужественным Ясоном, аргонавты должны возвратить в Грецию священную реликвию. На пути героям встречаются прекрасные женщины, мудрые кентавры, огненные быки и полчища врагов. В программе шоу: воздушные гимнасты, вравщающиеся на огненных кубах, акробаты, выполняющие трюки на высоте 15 метров, хореографические сцены с участием профессиональных танцоров знаменитых школ \"Тодес\" и \"Дункан\".",
            "Сегодня и только сегодня можно увидеть танцующего слона под самым куполом цирка. Насладиться fireshow от лучших мировых артистов. Также в программе смертельнве трюки гимнастов на ремнях, где нельзя ошибится. И конечно же весёлый клоун, который не оставит равнодушным ни единого ребёнка и взрослого!"
        };

        static void Main(string[] args)
        {
            //string text = "";
            //Random rr = new Random(7);

            //for (int i = 0; i < 20; i++ )
            //    text += rr.Next(10000000, 99999999).ToString() + Environment.NewLine;


            //File.WriteAllText("coupons.txt", text);

            //return;
            
            ////------------------------------------------

            if (args == null)
            {
                Console.Write(help);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return;
            }

            if (args.Length != 7)
            {
                Console.WriteLine("Bad number of arguments");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return;
            }

            DateTime StartDate;
            DateTime EndDate;
            int StartTime;
            int EndTime;
            int TicketNumber;
            string Program;
            bool key = false;

            if (args.Length == 7)
            {
                int[] x = ParseDate(args[0]);
                StartDate = new DateTime(x[2], x[1], x[0]);

                x = ParseDate(args[1]);
                EndDate = new DateTime(x[2], x[1], x[0]);

                StartTime = int.Parse(args[2]);
                if(StartTime >21 && StartTime < 10)
                {
                    Console.WriteLine("Bad StartTime argument");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    return;
                }

                EndTime = int.Parse(args[3]);
                if (EndTime > 22 && EndTime < 11)
                {
                    Console.WriteLine("Bad EndTime argument");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    return;
                }

                TicketNumber = int.Parse(args[4]);
                if (EndTime > 3 && EndTime < 1)
                {
                    Console.WriteLine("Bad TicketNumber argument");
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey();
                    return;
                }

 

                switch(args[6])
                {
                    case "-add": key = true; break;
                    case "-create": key = false; break;
                    default: 
                        Console.WriteLine("Bad key argument");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey(); return;
                }

                if(key)
                {
                    List<Ticket> tickets = readTicketsDB("ticketsDB.dat");
                    tickets = GenerateTickets(tickets, StartDate, EndDate, StartTime, EndTime, TicketNumber, "");
                    writeTicketsDB(tickets, "ticketsDB.dat");
                }
                else
                {
                    List<Ticket> tickets = GenerateTickets(StartDate, EndDate, StartTime, EndTime, TicketNumber, "");
                    writeTicketsDB(tickets, "ticketsDB.dat");
                }


                Console.WriteLine("DB created");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();

            }
        }

        static int[] ParseDate(string date)
        {
            int[] dates = new int[3];
            int i = 0;
            foreach(string str in date.Split('-'))
                dates[i++] = int.Parse(str);
            
            return dates;
        }

        static string GenerateProgram(Random r)
        {
            return programs[r.Next(0, variants)];
        }

        static void GenerateTicket(string program, DateTime date, int time)
        {
            Ticket t = new Ticket(program, date, time);
        }

        static List<Ticket> GenerateTickets(DateTime StartDate, DateTime EndDate, int StartTime, int EndTime, int TicketNumber, string Program)
        {
            return GenerateTickets(new List<Ticket>(), StartDate, EndDate, StartTime, EndTime, TicketNumber, Program);
        }

        static List<Ticket> GenerateTickets(List<Ticket> TicketList, DateTime StartDate, DateTime EndDate, int StartTime, int EndTime, int TicketNumber, string Program)
        {
            int x = (int)(EndDate - StartDate).TotalDays;
            int y = EndTime - StartTime;

            Random r = new Random(8);

            string program111 = "";

            DateTime f = StartDate + new TimeSpan(1, 0, 0, 0);

            for(int i = 0; i < x; i++)
            {
                program111 = GenerateProgram(r);
                for(int j = 0; j < y; j++)
                {
                    for (int h = 0; h < TicketNumber; h++)
                        TicketList.Add(new Ticket(program111,
                                                  StartDate + new TimeSpan(i, 0, 0, 0),
                                                  StartTime + j));
                }
            }

            return TicketList;
        }

        static void writeTicketsDB(List<Ticket> TicketList, string fileName)
        {
            // work with files. try-catch for noobs
            FileStream stream = File.Create(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, TicketList);
            stream.Close();
        }

        static List<Ticket> readTicketsDB(string fileName)
        {
            if (!File.Exists(fileName))
                return null;

            List<Ticket> TicketList;

            // work with files. try-catch for noobs
            FileStream stream = File.OpenRead(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            TicketList = (List<Ticket>)formatter.Deserialize(stream);
            stream.Close();

            return TicketList;
        }
    }
}
