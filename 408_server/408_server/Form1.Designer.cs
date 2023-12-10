namespace server
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
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_if100 = new System.Windows.Forms.TextBox();
            this.textBox_sps101 = new System.Windows.Forms.TextBox();
            this.button_sps101 = new System.Windows.Forms.Button();
            this.button_if100 = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(224, 86);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(183, 22);
            this.textBox_port.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(428, 83);
            this.button_listen.Margin = new System.Windows.Forms.Padding(2);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(74, 28);
            this.button_listen.TabIndex = 2;
            this.button_listen.Text = "Listen";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(53, 384);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(124, 17);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "General Message:";
            // 
            // textBox_message
            // 
            this.textBox_message.Enabled = false;
            this.textBox_message.Location = new System.Drawing.Point(215, 381);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(287, 22);
            this.textBox_message.TabIndex = 5;
            // 
            // button_send
            // 
            this.button_send.Enabled = false;
            this.button_send.Location = new System.Drawing.Point(531, 375);
            this.button_send.Margin = new System.Windows.Forms.Padding(2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(79, 34);
            this.button_send.TabIndex = 6;
            this.button_send.Text = "send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 470);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Message to SPS101:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 427);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Message to IF100:";
            // 
            // textBox_if100
            // 
            this.textBox_if100.Enabled = false;
            this.textBox_if100.Location = new System.Drawing.Point(215, 424);
            this.textBox_if100.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_if100.Name = "textBox_if100";
            this.textBox_if100.Size = new System.Drawing.Size(287, 22);
            this.textBox_if100.TabIndex = 9;
            // 
            // textBox_sps101
            // 
            this.textBox_sps101.Enabled = false;
            this.textBox_sps101.Location = new System.Drawing.Point(215, 467);
            this.textBox_sps101.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_sps101.Name = "textBox_sps101";
            this.textBox_sps101.Size = new System.Drawing.Size(287, 22);
            this.textBox_sps101.TabIndex = 10;
            // 
            // button_sps101
            // 
            this.button_sps101.Enabled = false;
            this.button_sps101.Location = new System.Drawing.Point(531, 461);
            this.button_sps101.Margin = new System.Windows.Forms.Padding(2);
            this.button_sps101.Name = "button_sps101";
            this.button_sps101.Size = new System.Drawing.Size(79, 34);
            this.button_sps101.TabIndex = 11;
            this.button_sps101.Text = "send";
            this.button_sps101.UseVisualStyleBackColor = true;
            this.button_sps101.Click += new System.EventHandler(this.button_sps101_Click);
            // 
            // button_if100
            // 
            this.button_if100.Enabled = false;
            this.button_if100.Location = new System.Drawing.Point(531, 418);
            this.button_if100.Margin = new System.Windows.Forms.Padding(2);
            this.button_if100.Name = "button_if100";
            this.button_if100.Size = new System.Drawing.Size(79, 34);
            this.button_if100.TabIndex = 12;
            this.button_if100.Text = "send";
            this.button_if100.UseVisualStyleBackColor = true;
            this.button_if100.Click += new System.EventHandler(this.button_if100_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(56, 136);
            this.logs.Name = "logs";
            this.logs.ReadOnly = true;
            this.logs.Size = new System.Drawing.Size(553, 224);
            this.logs.TabIndex = 13;
            this.logs.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 519);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_if100);
            this.Controls.Add(this.button_sps101);
            this.Controls.Add(this.textBox_sps101);
            this.Controls.Add(this.textBox_if100);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_port);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "DiSUcord Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_if100;
        private System.Windows.Forms.TextBox textBox_sps101;
        private System.Windows.Forms.Button button_sps101;
        private System.Windows.Forms.Button button_if100;
        private System.Windows.Forms.RichTextBox logs;
    }
}

