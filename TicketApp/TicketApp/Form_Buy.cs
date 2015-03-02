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

namespace TicketApp
{
    public partial class Form_Buy : Form
    {
        // bug can be here
        static Random r = new Random();
        
        const int TicketPrice = 100;
        const int SnakPrice = 10;
        const int PetPrice = 50;

        const double customerD = 0.97;
        const double couponD = 0.95;
        const double addD10 = -0.01;

        Form_Tickets form;
        List<string> coupons;
        Ticket ticket;
        User user;
        int Captcha;

        string fileName = TicketApp.Properties.Settings.Default.CouponDB;

        double FinalPrice;

        public Form_Buy(Form_Tickets form, User user)
        {
            this.form = form;
            this.user = user;
            this.ticket = null;

            InitializeComponent();
            Captcha = SetCaptcha();

            //textBox_ticket.ReadOnly = true;
            //textBox_ticket.Text = ticket.ID;
            if (user.CreditCard.Length != 0)
                textBox_credit.Text = user.CreditCard;

            //FinalPrice = getFinalPrice(ticket);
            label_price.Text = "-";

            getCoupons();

            if (user.Login == "Anonymous")
            {
                pictureBox1.Enabled = true;
                textBox_captcha.Enabled = true;
            }
            else
            {
                pictureBox1.Enabled = false;
                textBox_captcha.Enabled = false;
            }
        }
        
        public Form_Buy(Form_Tickets form, User user, Ticket ticket): this(form, user)
        {
            textBox_ticket.ReadOnly = true;
            textBox_ticket.Text = ticket.ID;

            FinalPrice = getFinalPrice(ticket);
            label_price.Text = FinalPrice.ToString();

            this.ticket = ticket;
        }


        public int SetCaptcha()
        {
            
            int captcha = r.Next(1, 5);
            
            // stupid resources
            switch (captcha)
            {
                case 1: pictureBox1.Image = TicketApp.Properties.Resources.cats_1; break;
                case 2: pictureBox1.Image = TicketApp.Properties.Resources.cats_2; break;
                case 3: pictureBox1.Image = TicketApp.Properties.Resources.cats_3; break;
                case 4: pictureBox1.Image = TicketApp.Properties.Resources.cats_4; break;
                case 5: pictureBox1.Image = TicketApp.Properties.Resources.cats; break;
            }

            return captcha;
        }

        public int getFinalPrice(Ticket t)
        {
            int final = TicketPrice;
            if (t.Snack) final += SnakPrice;
            if (t.Pet.Length > 0) final += PetPrice;

            return final;
        }

        public List<string> getCoupons()
        {
            string[] text = File.ReadAllLines(fileName);
            coupons = text.ToList<string>();
            return coupons;
        }

        public bool RemoveCoupon(string coupon)
        {
            if (coupons.Contains(coupon))
            {
                coupons.Remove(coupon);
                File.WriteAllLines(fileName, coupons.ToArray<string>());
                return true;
            }
            return false;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Close();
        }

        private void button_buy_Click(object sender, EventArgs e)
        {
            if (!User.CheckCreditCard(textBox_credit.Text) && textBox_credit.Text.Length > 0)
            {
                Form_Logon.textBoxInvalid(textBox_credit, toolTip1, "bad format");
                return;
            }

            int temp;
            if (!int.TryParse(textBox_ticket.Text, out temp) && textBox_ticket.Text.Length != 8)
            {
                Form_Logon.textBoxInvalid(textBox_ticket, toolTip1, "bad format");
                return;
            }

            if (!int.TryParse(textBox_coupon.Text, out temp) && textBox_coupon.Text.Length != 8 && textBox_coupon.Text.Length > 0)
            {
                Form_Logon.textBoxInvalid(textBox_coupon, toolTip1, "bad format");
                return;
            }

            if (!int.TryParse(textBox_captcha.Text, out temp) && textBox_captcha.Text.Length != 1 && textBox_captcha.Text.Length > 0 && user.Login == "Anonymous")
            {
                Form_Logon.textBoxInvalid(textBox_captcha, toolTip1, "bad format");
                return;
            }

            if (temp != Captcha && user.Login == "Anonymous")
            {
                Form_Logon.textBoxInvalid(textBox_captcha, toolTip1, "wrong captcha");
                Captcha = SetCaptcha();
                return;
            }

            if (this.ticket == null)
            {
                if ((this.ticket = this.form.TManager.GetTicketByID(textBox_ticket.Text)) != null)
                {
                    FinalPrice = TicketPrice;
                    if (ticket.Snack) FinalPrice += SnakPrice;
                    if (ticket.Pet.Length != 0) FinalPrice += PetPrice;
                }
                else
                {
                    Form_Logon.textBoxInvalid(textBox_ticket, toolTip1, "ticketID not found");
                    return;
                }
            }

            if (!coupons.Contains(textBox_coupon.Text) && textBox_coupon.Text.Length > 0)
            {
                Form_Logon.textBoxInvalid(textBox_coupon, toolTip1, "coupon not found");
                return;
            }
            else
            {
                FinalPrice *= couponD;
                RemoveCoupon(textBox_coupon.Text);
            }

            if (user.Login != "Anonymous" && textBox_coupon.Text.Length == 0)
                FinalPrice *= customerD;

            // BUG 1% does not count
            //TicketApp.Properties.Settings.Default.BuyCount += 1;
            ticket.Buy();
            form.TManager.Refresh();
            
            MessageBox.Show(String.Format("Ticket {0} is bought{1}Amount {2} is requested from bank",
                ticket.ID,
                Environment.NewLine,
                FinalPrice),
                "Congratulations!");
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Form_Logon.textBoxValid((TextBox)sender, toolTip1);
        }

        private void Form_Buy_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }

        private void textBox_credit_TextChanged(object sender, EventArgs e)
        {
            // BUG - delete code blocks
            
            textBox_TextChanged(sender, e);

            if (textBox_credit.Text.Length < 4)
                return;
                
            string card = textBox_credit.Text.Replace("-", "");

            int i = 0;
            string result = "";
            foreach (char c in card)
            {
                result += c;
                if (++i % 4 == 0 && i >= 3)
                    result += '-';
            }

            int maxlength = (result.Length < 19) ? result.Length : 19;
            textBox_credit.Text = result.Substring(0, maxlength);
            textBox_credit.SelectionStart = textBox_credit.Text.Length;
        }

    }
}
