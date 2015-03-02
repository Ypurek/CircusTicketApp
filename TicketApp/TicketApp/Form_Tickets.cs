using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class Form_Tickets : Form
    {
        private User currentUser;
        public TicketManager TManager;

        public Form_Tickets()
        {
            InitializeComponent();
            label3.Text = "Performance Time: " + get12hTime(trackBar1.Value);
            currentUser = new User("Anonymous", "");
            linkLabel1.Text = currentUser.Login;

            TManager = new TicketManager(TicketApp.Properties.Settings.Default.TicketDB);
            showProgram();
        }

        public Form_Tickets(User user) : this()
        {
            currentUser = user;
            linkLabel1.Text = currentUser.Login;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;

            button_book.Enabled = true;
            button_buyback.Enabled = true;

        }

        private void showProgram()
        {
            List<Ticket> list = TManager.GetAvailableTicketsByDateTime(dateTimePicker1.Value, trackBar1.Value);

            if (list == null)
            {
                textBox_program.Text = "SOLD OUT";
                return;
            }

            if (list.Count == 0)
            {
                textBox_program.Text = "SOLD OUT";
                return;
            }


            textBox_program.Clear();
            textBox_program.Text = list[0].Program;
            
            //int i = 0;
            //foreach(Ticket t in list)
            //{
            //    textBox_program.Text = String.Format("***** {2} PROGRAM FOR {0} :{1}", get12hTime(t.Time), Environment.NewLine, i++);
            //    textBox_program.Text += String.Format("{0}{1}", t.Program, Environment.NewLine);
            //}

        }

        private void Form_Tickets_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Program.LogonForm.Visible)
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.LogonForm.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled ^= true;
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                String.Format("Ticket App. Version {0}", ProductVersion.Remove(ProductVersion.LastIndexOf('.'))),
                "About",
                MessageBoxButtons.OK);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Performance Time: " + get12hTime(trackBar1.Value);
            showProgram();
        }

        private string get12hTime(int time)
        {
            int x = time % 12;
            if (x == 0)
                return time.ToString() + " a.m.";

            return x.ToString() + " p.m.";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Personal_Info PersonalInfo = new Personal_Info(currentUser);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).CalendarTitleBackColor = Color.White;
            toolTip1.Hide(((DateTimePicker)sender));

            showProgram();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personal_Info PersonalInfo = new Personal_Info(currentUser);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_book_Click(object sender, EventArgs e)
        {
            List<Ticket> list = TManager.GetAvailableTicketsByDateTime(dateTimePicker1.Value, trackBar1.Value);

            if (list.Count == 0)
            {
                dateTimePicker1.CalendarTitleBackColor = Color.Coral;
                toolTip1.Show("no tickets available", dateTimePicker1);
                return;
            }

            if (!checkPets(list[0].Program))
                return;

            Ticket t = TManager.Book(dateTimePicker1.Value, trackBar1.Value, currentUser);

            if (checkBox1.Checked)
                t.Pet = comboBox1.Text;
            t.Snack = checkBox2.Checked;

            MessageBox.Show(
                String.Format("Ticket {0} is booked for {1}{2}Booking will be keeped for 5 min", t.ID, currentUser.Login, Environment.NewLine),
                "Ticket Booked");

            showProgram();
        }



        private bool checkPets(string program)
        {
            if (!checkBox1.Checked)
                return true;
            else
                switch (comboBox1.Text)
                {
                    case "Cat": if (program.Contains("собак")) comboInvaild(); return false;
                    case "Mouse": if (program.Contains("слон")) comboInvaild(); return false;
                    default: comboBox1.BackColor = Color.White; toolTip1.Hide(comboBox1); break;
                }
            
            return true;
        }

        private void comboInvaild()
        {
            comboBox1.BackColor = Color.Coral;
            toolTip1.Show("cannot be taken", comboBox1);
        }

        private void button_buy_Click(object sender, EventArgs e)
        {
            List<Ticket> list = TManager.GetAvailableTicketsByDateTime(dateTimePicker1.Value, trackBar1.Value);

            if (list.Count == 0)
            {
                dateTimePicker1.CalendarTitleBackColor = Color.Coral;
                toolTip1.Show("no tickets available", dateTimePicker1);
                return;
            }

            if (!checkPets(list[0].Program))
                return;

            Ticket t = list[0];

            if (checkBox1.Checked)
                t.Pet = comboBox1.Text;
            t.Snack = checkBox2.Checked;

            if (currentUser.BirthDay.Day == DateTime.Today.Day &&
                currentUser.BirthDay.Month == DateTime.Today.Month &&
                currentUser.Photo != null)
            {
                Form_BDay bday = new Form_BDay(currentUser);
            }

            Form_Buy buyform = new Form_Buy(this, currentUser, t);
            buyform.Show();
            this.Hide();
        }

        public new void Show()
        {
            base.Show();
            showProgram();
        }

        private void button_buyback_Click(object sender, EventArgs e)
        {
            Form_Buy buyform = new Form_Buy(this, currentUser);
            buyform.Show();
            this.Hide();
        }

        private void f1HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help yourself :)", "help");
        }

    }
}
