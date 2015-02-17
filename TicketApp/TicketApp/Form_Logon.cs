using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TicketApp
{
    public partial class Form_Logon : Form
    {
        public Form_Logon()
        {
            InitializeComponent();
            userList = new List<User>();
            readUserList(TicketApp.Properties.Resources.UserDB);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User("","");
            
            if (verifyUserExists(textBox1.Text))
            {
                foreach (User u in userList)
                    if (textBox1.Text == u.Login)
                        user = u;
            }

            if (user.Password != textBox2.Text)
            {
                textBoxInValid(textBox2, "bad password");
                return;
            }
            else
                textBoxValid(textBox2);

            Form_Tickets TicketForm = new Form_Tickets(user);
            this.Hide();
            TicketForm.Show();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "")
            {
                e.Cancel = false;
                return;
            }
            
            if (verifyUserNameValid(textBox1.Text))
            {
                textBoxInValid(textBox1, "pattern mismatch");
                e.Cancel = true;
            }
            else
            {
                textBoxValid(textBox1);
                e.Cancel = false;
            }
        }

        private List<User> userList;
        
        private void readUserList(string fileName)
        {
            userList.Clear();

            if (!File.Exists(TicketApp.Properties.Resources.UserDB))
                return;

            // work with files. try-catch for noobs
            FileStream stream = File.OpenRead(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            userList = (List<User>) formatter.Deserialize(stream);
            stream.Close();
        }

        private void writeUserList(string fileName)
        {
            // work with files. try-catch for noobs
            FileStream stream = File.Create(fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, userList);
            stream.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (verifyUserExists(textBox1.Text))
            {
                textBoxInValid(textBox1, "user exists");
                return;
            }
            else
                textBoxValid(textBox1);
            
            User user = new User(textBox1.Text, //login
                                  textBox2.Text); //pass
            userList.Add(user);

            writeUserList(TicketApp.Properties.Resources.UserDB);

            Form_Tickets TicketForm = new Form_Tickets(user);
            this.Hide();
            TicketForm.Show();
        }

        /// <summary>
        /// Checks if user name matches pattern
        /// returns true if no
        /// </summary>
        /// <param name="login"></param>
        private bool verifyUserNameValid(string login)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[a-zA-Z]{1,8}$");
            if (!reg.IsMatch(login))
                return true;
            return false;
        }

        /// <summary>
        /// Checks if user pass matches pattern
        /// returns true if no
        /// </summary>
        /// <param name="login"></param>
        private bool verifyUserPass(string pass)
        {
            if (pass.Length >= 1 && pass.Length <= 8)
                return false;
            return true;
        }

        /// <summary>
        /// Checks if user name already exists in DB
        /// returns true if username exist
        /// </summary>
        /// <param name="login"></param>
        private bool verifyUserExists(string login)
        {
            foreach (User user in userList)
            {
                if (user.Login == login)
                    return true;
            }
            return false;
        }

        private void textBoxValid(TextBox tb)
        {
            tb.BackColor = Color.White;
            toolTip1.Hide(tb);
        }

        private void textBoxInValid(TextBox tb, string message)
        {
            tb.BackColor = Color.Coral;
            toolTip1.Show(message, tb);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == "")
            {
                e.Cancel = false;
                return;
            }

            if (verifyUserPass(textBox2.Text))
            {
                textBoxInValid(textBox2, "pattern mismatch");
                e.Cancel = true;
            }
            else
            {
                textBoxValid(textBox2);
                e.Cancel = false;
            }
        }


    }
}
