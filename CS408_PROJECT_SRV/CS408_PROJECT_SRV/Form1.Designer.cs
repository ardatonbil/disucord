namespace CS408_PROJECT_SRV
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
            this.textbox_action = new System.Windows.Forms.RichTextBox();
            this.textbox_client = new System.Windows.Forms.RichTextBox();
            this.textbox_if100 = new System.Windows.Forms.RichTextBox();
            this.textbox_sps101 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_listen = new System.Windows.Forms.Button();
            this.textbox_port = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textbox_action
            // 
            this.textbox_action.Location = new System.Drawing.Point(316, 107);
            this.textbox_action.Name = "textbox_action";
            this.textbox_action.Size = new System.Drawing.Size(211, 328);
            this.textbox_action.TabIndex = 0;
            this.textbox_action.Text = "";
            // 
            // textbox_client
            // 
            this.textbox_client.Location = new System.Drawing.Point(610, 107);
            this.textbox_client.Name = "textbox_client";
            this.textbox_client.Size = new System.Drawing.Size(211, 328);
            this.textbox_client.TabIndex = 1;
            this.textbox_client.Text = "";
            // 
            // textbox_if100
            // 
            this.textbox_if100.Location = new System.Drawing.Point(894, 107);
            this.textbox_if100.Name = "textbox_if100";
            this.textbox_if100.Size = new System.Drawing.Size(211, 328);
            this.textbox_if100.TabIndex = 2;
            this.textbox_if100.Text = "";
            // 
            // textbox_sps101
            // 
            this.textbox_sps101.Location = new System.Drawing.Point(1169, 107);
            this.textbox_sps101.Name = "textbox_sps101";
            this.textbox_sps101.Size = new System.Drawing.Size(211, 328);
            this.textbox_sps101.TabIndex = 3;
            this.textbox_sps101.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 13.00001F);
            this.label1.Location = new System.Drawing.Point(605, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connected Clients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft New Tai Lue", 13.00001F);
            this.label2.Location = new System.Drawing.Point(311, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Actions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft New Tai Lue", 13.00001F);
            this.label3.Location = new System.Drawing.Point(889, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "IF100 Subscribers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft New Tai Lue", 13.00001F);
            this.label4.Location = new System.Drawing.Point(1164, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "SPS101 Subscribers";
            // 
            // button_listen
            // 
            this.button_listen.Location = new System.Drawing.Point(50, 205);
            this.button_listen.Name = "button_listen";
            this.button_listen.Size = new System.Drawing.Size(180, 31);
            this.button_listen.TabIndex = 8;
            this.button_listen.Text = "Listen to DiSUcord";
            this.button_listen.UseVisualStyleBackColor = true;
            this.button_listen.Click += new System.EventHandler(this.button_listen_Click);
            // 
            // textbox_port
            // 
            this.textbox_port.Location = new System.Drawing.Point(82, 158);
            this.textbox_port.Name = "textbox_port";
            this.textbox_port.Size = new System.Drawing.Size(177, 22);
            this.textbox_port.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Port: ";
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(50, 242);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(180, 31);
            this.button_stop.TabIndex = 11;
            this.button_stop.Text = "Stop Listening";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 499);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textbox_port);
            this.Controls.Add(this.button_listen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_sps101);
            this.Controls.Add(this.textbox_if100);
            this.Controls.Add(this.textbox_client);
            this.Controls.Add(this.textbox_action);
            this.Name = "Form1";
            this.Text = "DiSUcord Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textbox_action;
        private System.Windows.Forms.RichTextBox textbox_client;
        private System.Windows.Forms.RichTextBox textbox_if100;
        private System.Windows.Forms.RichTextBox textbox_sps101;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_listen;
        private System.Windows.Forms.TextBox textbox_port;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_stop;
    }
}

