using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class Form_Tickets : Form
    {
        private User currentUser;
        
        public Form_Tickets()
        {
            InitializeComponent();
            currentUser = new User("Anonymous", "");
            linkLabel1.Text = currentUser.Login;
        }

        public Form_Tickets(User user)
        {
            InitializeComponent();
            currentUser = user;
            linkLabel1.Text = currentUser.Login;
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


    }
}
