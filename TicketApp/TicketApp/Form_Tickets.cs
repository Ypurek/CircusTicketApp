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
        }

        public Form_Tickets(User user) : this()
        {
            currentUser = user;
            linkLabel1.Text = user.Login;
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


    }
}
