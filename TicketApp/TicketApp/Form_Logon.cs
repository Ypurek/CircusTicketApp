using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TicketApp
{
    public partial class Form_Logon : Form
    {
        public UserManagement UserManager;
        
        public Form_Logon()
        {
            InitializeComponent();
            UserManager = new UserManagement(TicketApp.Properties.Settings.Default.UserDB);
        }

        public new void Show()
        {
            textBox_login.Clear();
            textBox_pass.Clear();
            base.Show();
        }

        public static void textBoxValid(TextBox tb, ToolTip tt)
        {
            tb.BackColor = Color.White;
            tt.Hide(tb);
        }

        public static void textBoxInvalid(TextBox tb, ToolTip tt, string message)
        {
            tb.BackColor = Color.Coral;
            tt.Show(message, tb);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string errorMsg;

            if (!User.VerifyLogin(textBox_login.Text, out errorMsg))
            {
                textBoxInvalid(textBox_login, toolTip1, errorMsg);
                return;
            }

            if (!UserManager.verifyUserExists(textBox_login.Text))
            {
                textBoxInvalid(textBox_login, toolTip1, "user does not exist");
                return;
            }

            if (!User.VerifyPassword(textBox_pass.Text, out errorMsg))
            {
                textBoxInvalid(textBox_pass, toolTip1, errorMsg);
                return;
            }

            User user = UserManager.GetUserByName(textBox_login.Text);

            if (user.Password != textBox_pass.Text)
            {
                textBoxInvalid(textBox_pass, toolTip1, "bad password");
                return;
            }

            Form_Tickets TicketForm = new Form_Tickets(user);
            this.Hide();
            TicketForm.Show();
        }
 
        private void button_register_Click(object sender, EventArgs e)
        {
            string errorMsg;

            if (!User.VerifyLogin(textBox_login.Text, out errorMsg))
            {
                textBoxInvalid(textBox_login, toolTip1, errorMsg);
                return;
            }

            if (UserManager.verifyUserExists(textBox_login.Text))
            {
                textBoxInvalid(textBox_login, toolTip1, "user exists");
                return;
            }

            if (!User.VerifyPassword(textBox_pass.Text, out errorMsg))
            {
                textBoxInvalid(textBox_pass, toolTip1, errorMsg);
                return;
            }

            User user = new User(textBox_login.Text, //login
                                  textBox_pass.Text); //pass
            
            UserManager.AddUser(user);

            Form_Tickets TicketForm = new Form_Tickets(user);
            this.Hide();
            TicketForm.Show();
        }

        private void button_anon_Click(object sender, EventArgs e)
        {
            Form_Tickets TicketForm = new Form_Tickets();
            this.Hide();
            TicketForm.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            textBoxValid((TextBox)sender, toolTip1);
        }

    }
}
