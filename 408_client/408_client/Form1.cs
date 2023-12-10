using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;   //initialization by lab scripts
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
            button_disconnect.Enabled = false; //false at beginning
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //open the socket
            string IP = textBox_ip.Text;
            int portNum;

            if (Int32.TryParse(textBox_port.Text, out portNum))  //if the port is valid
            {
                try
                {
                    
                    clientSocket.Connect(IP, portNum);
                    //setting GUI appropriately
                    button_connect.Enabled = false;
                    textBox_message.Enabled = true;
                    button_send.Enabled = true;
                    button_disconnect.Enabled = true;
                    button_if100.Enabled = true;
                    button_sps101.Enabled = true;
                    connected = true;
                    textBox_ip.Enabled = false;
                    textBox_port.Enabled = false;
                    textBox_username.Enabled = false;
                    button_if100.Text = "Subscribe IF100";
                    button_sps101.Text = "Subscribe SPS101";
                    logs.AppendText("Connected to the server!\n");

                    // Send username to the server
                    string username = textBox_username.Text;
                    Byte[] buffer = Encoding.Default.GetBytes(username);
                    clientSocket.Send(buffer);

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();
                }
                catch
                {
                    logs.AppendText("Could not connect to the server!\n");
                }
            }
            else //port is invalid
            {
                logs.AppendText("Check the port\n");
            }
        }

        private void Receive()
        {
            while (connected)
            {
                try
                {
                    //take messages from the server
                    Byte[] buffer = new Byte[64];
                    int recv = clientSocket.Receive(buffer);

                    if (recv <= 0)
                    {
                        throw new SocketException();
                    }
                    
                    string incomingMessage = Encoding.Default.GetString(buffer);

                    // Check if the server sent a disconnection message
                    if (incomingMessage.Substring(0,24) == "Username already in use.")
                    {
                        logs.AppendText("Disconnecting due to username conflict.\n");
                        textBox_port.Enabled = true;
                        textBox_username.Enabled = true;
                        textBox_ip.Enabled = true;
                        button_if100.Enabled = false;
                        button_sps101.Enabled = false;
                        button_connect.Enabled = true;
                        button_disconnect.Enabled = false;
                        textBox_message.Enabled = false;
                        button_send.Enabled = false;
                        
                        break; // Exit the loop and handle disconnection
                    }
                    else if (incomingMessage == "The server has been shut down.")
                    {
                        throw new SocketException(); //goes into catch block for disconnection handling
                    }
                    else if (incomingMessage.Substring(0,9) == "__IF100__")  //token to determine that the message is for IF100 channel only
                    {
                        if (incomingMessage.Contains("*.*")) //username separator  ("__IF100____username__"."actualmsg\0")
                        {
                            int sep_index = incomingMessage.IndexOf("*.*");
                            string username = incomingMessage.Substring(11, (sep_index-13));
                            string actual_message = incomingMessage.Substring((sep_index+3));  
                            //separating the actual message from raw message (actual + token + sender + \0)
                            actual_message = actual_message.Replace("\0", "");
                            textbox_if100.AppendText(username + ": " + actual_message.Substring(9) + "\n");
                        }
                        else //no username part
                        {
                            incomingMessage = incomingMessage.Replace("\0", "");
                            textbox_if100.AppendText("Server: " + incomingMessage.Substring(9) + "\n");  
                        } 
                    }
                    else if (incomingMessage.Substring(0, 10) == "__SPS101__")  //same thing with IF100 except token is SPS101
                    {
                        if (incomingMessage.Contains("*.*"))
                        {
                            int sep_index = incomingMessage.IndexOf("*.*");
                            string username = incomingMessage.Substring(12, (sep_index - 14));
                            string actual_message = incomingMessage.Substring((sep_index + 3));
                            actual_message = actual_message.Replace("\0", "");
                            textbox_sps101.AppendText(username + ": " + actual_message.Substring(10) + "\n");
                        }
                        else
                        {
                            incomingMessage = incomingMessage.Replace("\0", "");
                            textbox_sps101.AppendText("Server: " + incomingMessage.Substring(10) + "\n");
                        }
                    }
                    else  //no token means general chat
                    {
                        if (incomingMessage.Contains("*.*"))
                        {
                            int sep_index = incomingMessage.IndexOf("*.*");
                            string username = incomingMessage.Substring(2, (sep_index-4));
                            string actual_message = incomingMessage.Substring((sep_index + 3));
                            actual_message = actual_message.Replace("\0", "");
                            string token = "__" + username + "__*.*";
                            if (actual_message.Contains(token))
                            {
                                actual_message = actual_message.Replace(token, "");
                            }
                            logs.AppendText(username + ": " + actual_message + "\n");
                        }
                        else
                        {
                            incomingMessage = incomingMessage.Replace("\0", "");
                            logs.AppendText("Server: " + incomingMessage + "\n");
                        }
                    }
                    
                }
                catch
                {
                    if (!terminating)  //if whole window is not shut, GUI should be set in a unintended disconnection
                    {
                        
                        button_connect.Enabled = true;
                        textBox_message.Enabled = false;
                        button_send.Enabled = false;
                        button_disconnect.Enabled = false;
                        textBox_ip.Enabled = true;
                        textBox_port.Enabled = true;
                        textBox_username.Enabled = true;
                        
                        textBox_msg_if100.Enabled = false;
                        textBox_msg_sps101.Enabled = false;
                        button_send_if100.Enabled = false;
                        button_send_sps101.Enabled = false;
                        button_if100.Text = "Subscribe IF100";
                        button_sps101.Text = "Subscribe SPS101";
                        button_if100.Enabled = false;
                        button_sps101.Enabled = false;

                    }
                    logs.AppendText("The server has disconnected.\n");
                    clientSocket.Close();
                    connected = false;
                    break; // Exit the loop
                }
            }
        }


        private void button_disconnect_Click(object sender, EventArgs e)  //setting GUI in an intentional disconnection
        {
            if (connected)
            {
                connected = false;
                terminating = true;
                clientSocket.Close();
                button_connect.Enabled = true;
                textBox_message.Enabled = false;
                button_send.Enabled = false;
                button_disconnect.Enabled = false;
                button_if100.Enabled = false;
                button_sps101.Enabled = false;
                textbox_if100.Enabled = false;
                textbox_sps101.Enabled = false;
                button_send_if100.Enabled = false;
                button_send_sps101.Enabled = false;
                textBox_port.Enabled = true;
                textBox_ip.Enabled = true;
                textBox_username.Enabled = true;
                logs.AppendText("Disconnected from the server.\n");
                
            }
        }

        private void button_send_Click(object sender, EventArgs e)  //sending msg to general chat
        {
            string message = textBox_message.Text;

            if (message != "" && message.Length <= 64)
            {
                try
                {
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    
                }
                catch
                {
                    logs.AppendText("Message could not be sent.\n");
                }
                
            }
        }

        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)  //closing the window
        {
            connected = false;
            terminating = true;
            if (clientSocket != null)
            {
                clientSocket.Close();
            }
            Environment.Exit(0); //threads are shut
        }

        

        private void button_if100_Click(object sender, EventArgs e)  //sub or unsub by same button to IF100
        {
            if (button_if100.Text == "Unsubscribe IF100")
            {
                
                try
                {
                    string message = "IF100_UNSUBSCRIBE";  //unsub token
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    button_if100.Text = "Subscribe IF100";

                    textBox_msg_if100.Enabled = false;  //send button to IF100 and textbox are off 
                    button_send_if100.Enabled = false;
                }
                catch
                {
                    logs.AppendText("Could not unsubscribe IF100.\n");
                }


            }

            else if (button_if100.Text == "Subscribe IF100") //opposite of unsub
            {
                string message = "IF100_SUBSCRIBE";
                
                
                try
                {
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    textbox_if100.AppendText("Welcome to IF100!\n");
                    button_if100.Text = "Unsubscribe IF100";
                    textBox_msg_if100.Enabled = true;
                    button_send_if100.Enabled = true;
                }
                catch
                {
                    logs.AppendText("Could not subscribe IF100.\n");
                }

            }

        }

        private void button_sps101_Click(object sender, EventArgs e)  //same with button_if100_click
        {
            
            if (button_sps101.Text == "Unsubscribe SPS101")
            {
                try
                {
                    string message = "SPS101_UNSUBSCRIBE";
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    button_sps101.Text = "Subscribe SPS101";
                    textBox_msg_sps101.Enabled = false;
                    button_send_sps101.Enabled = false;
                }
                
                catch
                {
                    logs.AppendText("Could not unsubscribe SPS101.\n");
                }


            }

            else if (button_sps101.Text == "Subscribe SPS101")
            {
                try
                {
                    string message = "SPS101_SUBSCRIBE";
                    Byte[] buffer = Encoding.Default.GetBytes(message);
                    clientSocket.Send(buffer);
                    textbox_sps101.AppendText("Welcome to SPS101!\n");
                    button_sps101.Text = "Unsubscribe SPS101";
                    textBox_msg_sps101.Enabled = true;
                    button_send_sps101.Enabled = true;
                }
                catch
                {
                    logs.AppendText("Could not subscribe SPS101.\n");
                }
                
            }
        }

        private void button_send_if100_Click(object sender, EventArgs e)  //sending message with __IF100__ token
        {
            
            
            try
            {
                string message_if100 = "__IF100__" + textBox_msg_if100.Text;
                Byte[] buffer_if100 = Encoding.Default.GetBytes(message_if100);
                clientSocket.Send(buffer_if100);
                
                
            }
            catch
            {
                logs.AppendText("Message could not be sent.\n");
            }
        }

        private void button_send_sps101_Click(object sender, EventArgs e) //sending msg with __SPS101__token
        {
            

            try
            {
                string message_sps101 = "__SPS101__" + textBox_msg_sps101.Text;
                Byte[] buffer_sps101 = Encoding.Default.GetBytes(message_sps101);
                clientSocket.Send(buffer_sps101);
                
            }
            catch
            {
                logs.AppendText("Message could not be sent.\n");
            }
        }
    }
}
