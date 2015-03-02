namespace TicketApp
{
    partial class Form_Buy
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
            this.textBox_credit = new System.Windows.Forms.TextBox();
            this.textBox_ticket = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_coupon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_buy = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_price = new System.Windows.Forms.Label();
            this.textBox_captcha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credit Card #";
            // 
            // textBox_credit
            // 
            this.textBox_credit.Location = new System.Drawing.Point(12, 83);
            this.textBox_credit.Name = "textBox_credit";
            this.textBox_credit.Size = new System.Drawing.Size(141, 20);
            this.textBox_credit.TabIndex = 1;
            this.textBox_credit.TextChanged += new System.EventHandler(this.textBox_credit_TextChanged);
            // 
            // textBox_ticket
            // 
            this.textBox_ticket.Location = new System.Drawing.Point(12, 125);
            this.textBox_ticket.Name = "textBox_ticket";
            this.textBox_ticket.Size = new System.Drawing.Size(141, 20);
            this.textBox_ticket.TabIndex = 3;
            this.textBox_ticket.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TicketID";
            // 
            // textBox_coupon
            // 
            this.textBox_coupon.Location = new System.Drawing.Point(12, 167);
            this.textBox_coupon.Name = "textBox_coupon";
            this.textBox_coupon.Size = new System.Drawing.Size(141, 20);
            this.textBox_coupon.TabIndex = 5;
            this.textBox_coupon.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Coupon";
            // 
            // button_buy
            // 
            this.button_buy.Location = new System.Drawing.Point(12, 240);
            this.button_buy.Name = "button_buy";
            this.button_buy.Size = new System.Drawing.Size(75, 23);
            this.button_buy.TabIndex = 6;
            this.button_buy.Text = "Buy";
            this.button_buy.UseVisualStyleBackColor = true;
            this.button_buy.Click += new System.EventHandler(this.button_buy_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(93, 240);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(60, 23);
            this.button_back.TabIndex = 7;
            this.button_back.Text = "Back";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Captcha";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_price);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 50);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Final price";
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Location = new System.Drawing.Point(119, 20);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(39, 13);
            this.label_price.TabIndex = 0;
            this.label_price.Text = "PRICE";
            // 
            // textBox_captcha
            // 
            this.textBox_captcha.Location = new System.Drawing.Point(206, 206);
            this.textBox_captcha.Name = "textBox_captcha";
            this.textBox_captcha.Size = new System.Drawing.Size(96, 20);
            this.textBox_captcha.TabIndex = 11;
            this.textBox_captcha.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 26);
            this.label5.TabIndex = 12;
            this.label5.Text = "How many kittens do you\r\nsee?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TicketApp.Properties.Resources.cats_4;
            this.pictureBox1.Location = new System.Drawing.Point(180, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Buy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 275);
            this.Controls.Add(this.textBox_captcha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_buy);
            this.Controls.Add(this.textBox_coupon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_ticket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_credit);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Buy";
            this.Text = "Buy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Buy_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_credit;
        private System.Windows.Forms.TextBox textBox_ticket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_coupon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_buy;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_captcha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_price;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}