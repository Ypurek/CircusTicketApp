using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TicketApp
{
    public class UserManagement
    {
        private List<User> userList;
        private string fileName;

        public UserManagement(string fileName)
        {
            this.fileName = fileName;
            userList = new List<User>();
            ReadUserList(fileName);
        }
        
        public void AddUser(User user)
        {
            if (!verifyUserExists(user.Login))
            {
                userList.Add(user);
                WriteUserList(this.fileName);
            }
        }

        public void ReadUserList()
        {
            ReadUserList(fileName);
        }

        public void ReadUserList(string fileName)
        {
            userList.Clear();

            if (!File.Exists(TicketApp.Properties.Settings.Default.UserDB))
                return;

            // work with files. try-catch for noobs
            FileStream stream = File.OpenRead(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            userList = (List<User>)formatter.Deserialize(stream);
            stream.Close();
        }

        public void WriteUserList()
        {
            WriteUserList(fileName);
        }

        public void WriteUserList(string fileName)
        {
            // work with files. try-catch for noobs
            FileStream stream = File.Create(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, userList);
            stream.Close();
        }

        public bool verifyUserExists(string login)
        {
            return userList.Exists(x => x.Login == login);
        }

        public User GetUserByName(string login)
        {
            return userList.Find(x => x.Login == login);
        }
    }

    [Serializable]
    public class User
    {
        private string login;
        private string password;
        private string creditCard;
        private DateTime birthDay;

        // rewrite!
        public byte[] ImageArray;
        public string Login { get { return login; } }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public System.Drawing.Image Photo
        {
            get
            {
                if (ImageArray == null)
                    return null;
                return ByteToImage();
            }
        }
        public string CreditCard
        {
            get { return this.creditCard; }
            set
            { 
                if (CheckCreditCard(value))
                    this.creditCard = value;
            }
        }
        public DateTime BirthDay
        { 
            get { return this.birthDay; }
            set { this.birthDay = value; }
        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
            this.creditCard = "";
            this.birthDay = new DateTime();
        }

        public static bool VerifyLogin(string login, out string errorMsg)
        {
            errorMsg = "";

            if (login.Length < 1 || login.Length > 8)
            {
                errorMsg = "length is not valid";
                return false;
            }

            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[a-zA-Z]{1,8}$");
            if (!reg.IsMatch(login))
            {
                errorMsg = "contains invalid symbols";
                return false;
            }

            return true;
        }

        public static bool VerifyPassword(string pass, out string errorMsg)
        {
            errorMsg = "";
            if (pass.Length < 1 || pass.Length > 8)
            {
                errorMsg = "length is not valid";
                return false;
            }
            return true;
        }

        public static bool CheckCreditCard(string card)
        {
            int x = 0;
            string[] blocks = card.Split('-');
            if (blocks == null)
                return false;

            foreach (string s in blocks)
                if (!int.TryParse(s, out x))
                    return false;

            return true;
        }

        private System.Drawing.Image ByteToImage()
        {

            if (ImageArray == null)
                throw new ArgumentNullException("imageString");

            System.Drawing.Image image = System.Drawing.Image.FromStream(new MemoryStream(ImageArray));

            return image;

        }
    }
}
