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
    public partial class Personal_Info : Form
    {
        
        private User user;
        private bool newPhoto;
        private byte[] imageArray;
        
        public Personal_Info(User user)
        {
            this.user = user;

            InitializeComponent();
            textBox_login.Text = user.Login;
            textBox_credit.Text = user.CreditCard;
            dateTimePicker1.Value = (dateTimePicker1.MinDate > user.BirthDay) ? DateTime.Today : user.BirthDay;
            pictureBox1.Image = user.Photo ?? Properties.Resources.Person_img;
            
            newPhoto = false;

            

            this.ShowDialog();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string errorMsg = "";

            if (user.Password != textBox_old_pass.Text && textBox_old_pass.Text.Length > 0)
            {
                // TBD bug with wrong textbox
                Form_Logon.textBoxInvalid(textBox_old_pass, toolTip1, "password mismatch");
                return;
            }

            if(!User.VerifyPassword(textBox_new_pass.Text, out errorMsg) && textBox_new_pass.Text.Length > 0)
            {
                Form_Logon.textBoxInvalid(textBox_new_pass, toolTip1, errorMsg);
                return;
            }

            if (!User.CheckCreditCard(textBox_credit.Text) && textBox_credit.Text.Length > 0)
            {
                Form_Logon.textBoxInvalid(textBox_login, toolTip1, "bad format");
                return;
            }

            if (textBox_new_pass.Text.Length > 0)
                user.Password = textBox_new_pass.Text;

            if (textBox_credit.Text.Length > 0)
                user.CreditCard = textBox_credit.Text;

            // BUG
            user.BirthDay = dateTimePicker1.Value;

            if (newPhoto)
                user.ImageArray = imageArray;

            Program.LogonForm.UserManager.WriteUserList();

            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button_photo_Click(object sender, EventArgs e)
        {
            Stream stream;

            openPhotoDialog.Filter = "Image Files(*.JPG;)|*.JPG;";
            openPhotoDialog.FilterIndex = 1;
            openPhotoDialog.RestoreDirectory = true;

            if (openPhotoDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openPhotoDialog.OpenFile()) != null)
                        using (stream)
                        {
                            // BUG - no validating of size and type
                            pictureBox1.Image = new Bitmap(stream);
                            stream.Position = 0;
                            using (BinaryReader br = new BinaryReader(stream))
                            {
                                imageArray = br.ReadBytes((int)stream.Length);
                            }                            
                            newPhoto = true;
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Form_Logon.textBoxValid((TextBox)sender, toolTip1);
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
