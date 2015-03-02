namespace TicketApp
{
    partial class Personal_Info
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.textBox_old_pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_new_pass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button_photo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_credit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openPhotoDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(205, 221);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(63, 23);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(274, 221);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(69, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(12, 28);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.ReadOnly = true;
            this.textBox_login.Size = new System.Drawing.Size(145, 20);
            this.textBox_login.TabIndex = 3;
            // 
            // textBox_old_pass
            // 
            this.textBox_old_pass.Location = new System.Drawing.Point(12, 67);
            this.textBox_old_pass.Name = "textBox_old_pass";
            this.textBox_old_pass.Size = new System.Drawing.Size(145, 20);
            this.textBox_old_pass.TabIndex = 5;
            this.textBox_old_pass.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Old Password";
            // 
            // textBox_new_pass
            // 
            this.textBox_new_pass.Location = new System.Drawing.Point(12, 107);
            this.textBox_new_pass.Name = "textBox_new_pass";
            this.textBox_new_pass.Size = new System.Drawing.Size(145, 20);
            this.textBox_new_pass.TabIndex = 7;
            this.textBox_new_pass.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "New Password";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(205, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(138, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Date of Birth";
            // 
            // button_photo
            // 
            this.button_photo.Location = new System.Drawing.Point(205, 188);
            this.button_photo.Name = "button_photo";
            this.button_photo.Size = new System.Drawing.Size(138, 23);
            this.button_photo.TabIndex = 10;
            this.button_photo.Text = "Upload Photo";
            this.button_photo.UseVisualStyleBackColor = true;
            this.button_photo.Click += new System.EventHandler(this.button_photo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TicketApp.Properties.Resources.Person_img;
            this.pictureBox1.Location = new System.Drawing.Point(205, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_credit
            // 
            this.textBox_credit.Location = new System.Drawing.Point(12, 162);
            this.textBox_credit.Name = "textBox_credit";
            this.textBox_credit.Size = new System.Drawing.Size(145, 20);
            this.textBox_credit.TabIndex = 13;
            this.textBox_credit.TextChanged += new System.EventHandler(this.textBox_credit_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Credit Card #";
            // 
            // openPhotoDialog
            // 
            this.openPhotoDialog.FileName = "openFileDialog1";
            // 
            // Personal_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 256);
            this.Controls.Add(this.textBox_credit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_photo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox_new_pass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_old_pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Personal_Info";
            this.Text = "Personal Info";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.TextBox textBox_old_pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_new_pass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_photo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_credit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openPhotoDialog;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}