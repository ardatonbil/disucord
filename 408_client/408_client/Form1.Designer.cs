namespace client
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_send = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_if100 = new System.Windows.Forms.Button();
            this.button_sps101 = new System.Windows.Forms.Button();
            this.textbox_if100 = new System.Windows.Forms.RichTextBox();
            this.textbox_sps101 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_msg_if100 = new System.Windows.Forms.TextBox();
            this.textBox_msg_sps101 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_send_sps101 = new System.Windows.Forms.Button();
            this.button_send_if100 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(123, 64);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(116, 22);
            this.textBox_ip.TabIndex = 2;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(89, 205);
            this.button_connect.Margin = new System.Windows.Forms.Padding(2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(93, 28);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_message
            // 
            this.textBox_message.Enabled = false;
            this.textBox_message.Location = new System.Drawing.Point(395, 404);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(185, 22);
            this.textBox_message.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 407);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message:";
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(493, 446);
            this.button_send.Margin = new System.Windows.Forms.Padding(2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(87, 32);
            this.button_send.TabIndex = 8;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(215, 205);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(93, 28);
            this.button_disconnect.TabIndex = 9;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // button_if100
            // 
            this.button_if100.Enabled = false;
            this.button_if100.Location = new System.Drawing.Point(89, 256);
            this.button_if100.Name = "button_if100";
            this.button_if100.Size = new System.Drawing.Size(182, 29);
            this.button_if100.TabIndex = 12;
            this.button_if100.Text = "Subscribe IF100";
            this.button_if100.UseVisualStyleBackColor = true;
            this.button_if100.Click += new System.EventHandler(this.button_if100_Click);
            // 
            // button_sps101
            // 
            this.button_sps101.Enabled = false;
            this.button_sps101.Location = new System.Drawing.Point(89, 291);
            this.button_sps101.Name = "button_sps101";
            this.button_sps101.Size = new System.Drawing.Size(182, 29);
            this.button_sps101.TabIndex = 13;
            this.button_sps101.Text = "Subscribe SPS101";
            this.button_sps101.UseVisualStyleBackColor = true;
            this.button_sps101.Click += new System.EventHandler(this.button_sps101_Click);
            // 
            // textbox_if100
            // 
            this.textbox_if100.Location = new System.Drawing.Point(647, 62);
            this.textbox_if100.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_if100.Name = "textbox_if100";
            this.textbox_if100.ReadOnly = true;
            this.textbox_if100.Size = new System.Drawing.Size(255, 320);
            this.textbox_if100.TabIndex = 14;
            this.textbox_if100.Text = "";
            // 
            // textbox_sps101
            // 
            this.textbox_sps101.Location = new System.Drawing.Point(964, 62);
            this.textbox_sps101.Margin = new System.Windows.Forms.Padding(2);
            this.textbox_sps101.Name = "textbox_sps101";
            this.textbox_sps101.ReadOnly = true;
            this.textbox_sps101.Size = new System.Drawing.Size(255, 320);
            this.textbox_sps101.TabIndex = 15;
            this.textbox_sps101.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "General";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(754, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "IF100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1063, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "SPS101";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Username:";
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(325, 62);
            this.logs.Margin = new System.Windows.Forms.Padding(2);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(255, 320);
            this.logs.TabIndex = 20;
            this.logs.Text = "";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(123, 100);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(116, 22);
            this.textBox_port.TabIndex = 21;
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(123, 136);
            this.textBox_username.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(116, 22);
            this.textBox_username.TabIndex = 22;
            // 
            // textBox_msg_if100
            // 
            this.textBox_msg_if100.Enabled = false;
            this.textBox_msg_if100.Location = new System.Drawing.Point(717, 404);
            this.textBox_msg_if100.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_msg_if100.Name = "textBox_msg_if100";
            this.textBox_msg_if100.Size = new System.Drawing.Size(185, 22);
            this.textBox_msg_if100.TabIndex = 23;
            // 
            // textBox_msg_sps101
            // 
            this.textBox_msg_sps101.Enabled = false;
            this.textBox_msg_sps101.Location = new System.Drawing.Point(1034, 404);
            this.textBox_msg_sps101.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_msg_sps101.Name = "textBox_msg_sps101";
            this.textBox_msg_sps101.Size = new System.Drawing.Size(185, 22);
            this.textBox_msg_sps101.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(644, 407);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Message:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(961, 407);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Message:";
            // 
            // button_send_sps101
            // 
            this.button_send_sps101.Enabled = false;
            this.button_send_sps101.Location = new System.Drawing.Point(1132, 446);
            this.button_send_sps101.Margin = new System.Windows.Forms.Padding(2);
            this.button_send_sps101.Name = "button_send_sps101";
            this.button_send_sps101.Size = new System.Drawing.Size(87, 32);
            this.button_send_sps101.TabIndex = 27;
            this.button_send_sps101.Text = "Send";
            this.button_send_sps101.UseVisualStyleBackColor = true;
            this.button_send_sps101.Click += new System.EventHandler(this.button_send_sps101_Click);
            // 
            // button_send_if100
            // 
            this.button_send_if100.Enabled = false;
            this.button_send_if100.Location = new System.Drawing.Point(815, 446);
            this.button_send_if100.Margin = new System.Windows.Forms.Padding(2);
            this.button_send_if100.Name = "button_send_if100";
            this.button_send_if100.Size = new System.Drawing.Size(87, 32);
            this.button_send_if100.TabIndex = 28;
            this.button_send_if100.Text = "Send";
            this.button_send_if100.UseVisualStyleBackColor = true;
            this.button_send_if100.Click += new System.EventHandler(this.button_send_if100_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 543);
            this.Controls.Add(this.button_send_if100);
            this.Controls.Add(this.button_send_sps101);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_msg_sps101);
            this.Controls.Add(this.textBox_msg_if100);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textbox_sps101);
            this.Controls.Add(this.textbox_if100);
            this.Controls.Add(this.button_sps101);
            this.Controls.Add(this.button_if100);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "DiSUcord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_if100;
        private System.Windows.Forms.Button button_sps101;
        private System.Windows.Forms.RichTextBox textbox_if100;
        private System.Windows.Forms.RichTextBox textbox_sps101;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_msg_if100;
        private System.Windows.Forms.TextBox textBox_msg_sps101;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_send_sps101;
        private System.Windows.Forms.Button button_send_if100;
    }
}

