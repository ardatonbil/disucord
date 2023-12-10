using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();
        Dictionary<Socket, string> clientUsernames = new Dictionary<Socket, string>();   //initializing socket and client lists for channels and usernames
        List<Socket> channelIF100 = new List<Socket>();
        List<Socket> channelSPS101 = new List<Socket>();

        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox_port.Text, out serverPort))  //check if port is valid
            {
                try
                {
                    //connect
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                    serverSocket.Bind(endPoint);
                    serverSocket.Listen(3);


                    //set up GUI
                    listening = true;
                    
                    textBox_message.Enabled = true;
                    textBox_if100.Enabled = true;
                    textBox_sps101.Enabled = true;
                    button_send.Enabled = true;
                    button_sps101.Enabled = true;
                    button_if100.Enabled = true;

                    Thread acceptThread = new Thread(Accept);
                    acceptThread.Start();

                    logs.AppendText("Started listening on port: " + serverPort + "\n");
                }
                catch
                {
                    logs.AppendText("Could not connect.\n");  //port is valid but still no connection
                }
                
            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }

        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    Thread receiveThread = new Thread(() => Receive(newClient));  //thread to listen
                    receiveThread.Start();
                }
                catch
                {
                    if (terminating)  //end of listening intentionally
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }
                }
            }
        }

        private void Receive(Socket thisClient)
        {
            bool connected = true;
            try
            {
                Byte[] buffer = new Byte[64];
                int rec = thisClient.Receive(buffer);

                if (rec <= 0)
                {
                    throw new SocketException();
                }

                string username = Encoding.Default.GetString(buffer).Substring(0, rec);
                if (clientUsernames.Values.Contains(username))
                {
                    // Username already exists, reject the connection
                    string rejectionMsg = "Username already in use.";
                    buffer = Encoding.Default.GetBytes(rejectionMsg);
                    thisClient.Send(buffer);
                    thisClient.Close(); // Close the socket
                    return; // Exit the method to prevent further processing
                }
                else
                {
                    clientUsernames.Add(thisClient, username);  //first entrance of user into disucord, added to lists
                    clientSockets.Add(thisClient);
                    string connection_string = username + " has connected.\n";
                    Byte[] connection_message = Encoding.Default.GetBytes(connection_string);
                    foreach(Socket client in clientSockets)
                    {
                        client.Send(connection_message);  //everyone is notified about the connection
                    }
                    logs.AppendText(connection_string);  //written onto server log

                    
                    while (connected && !terminating)
                    {
                        try
                        {
                            //starts to get and parse messages
                            buffer = new Byte[64];
                            rec = thisClient.Receive(buffer);

                            if (rec <= 0)
                            {
                                throw new SocketException();
                            }

                            string incomingMessage = Encoding.Default.GetString(buffer).Substring(0, rec); 
                            if (incomingMessage == "IF100_SUBSCRIBE") //Subscribe IF100 button is used
                            {
                                channelIF100.Add(thisClient);  //user added to channel member list
                                string subscribed = "__IF100__" + username + " successfully subscribed IF100.\n";
                                buffer = Encoding.Default.GetBytes(subscribed);
                                foreach (Socket client in channelIF100)
                                {
                                    client.Send(buffer); //others are notified
                                }

                                logs.AppendText(subscribed.Substring(9));  //server log
                            }
                            //other 3 sub/unsub conditions are same with IF100_SUBSCRIBE
                            else if (incomingMessage == "IF100_UNSUBSCRIBE") //Unsubscribe IF100 button is used
                            {
                                
                                channelIF100.Remove(thisClient);
                                string unsubscribed = "__IF100__"+username + " successfully unsubscribed IF100.\n";
                                buffer = Encoding.Default.GetBytes(unsubscribed);
                                foreach (Socket client in channelIF100)
                                {
                                    client.Send(buffer);
                                }
                                thisClient.Send(buffer);
                                logs.AppendText(unsubscribed.Substring(9));
                            }
                            else if (incomingMessage == "SPS101_SUBSCRIBE") //Subscribe SPS101 button is used
                            {
                                try
                                {
                                    
                                    channelSPS101.Add(thisClient);
                                    string subscribed = "__SPS101__"+username + " successfully subscribed SPS101.\n";
                                    buffer = Encoding.Default.GetBytes(subscribed);
                                    foreach (Socket client in channelSPS101)
                                    {
                                        client.Send(buffer);
                                    }
                                    logs.AppendText(subscribed.Substring(10));
                                }
                                catch
                                {
                                    string error = "Could not subscribe SPS101.";
                                    buffer = Encoding.Default.GetBytes(error);
                                    thisClient.Send(buffer);
                                }
                            }
                            
                            else if (incomingMessage == "SPS101_UNSUBSCRIBE") //Unsubscribe SPS101 button is used
                            {
                                try
                                {

                                    channelSPS101.Remove(thisClient);
                                    string unsubscribed = "__SPS101__"+username+" successfully unsubscribed SPS101.\n";
                                    buffer = Encoding.Default.GetBytes(unsubscribed);
                                    foreach (Socket client in channelSPS101)
                                    {
                                        client.Send(buffer);
                                    }
                                    thisClient.Send(buffer);
                                    logs.AppendText(unsubscribed.Substring(10));
                                }
                                catch
                                {
                                    string error = "Could not unsubscribe SPS101";
                                    buffer = Encoding.Default.GetBytes(error);
                                    thisClient.Send(buffer);
                                }
                            }
                            else if (incomingMessage.Length >= 10)  //there might be a token for channel-specific messages, it takes 10 chars at most
                            {
                                if ((incomingMessage.Substring(0, 9) == "__IF100__") && incomingMessage.Length >= 9)
                                {
                                    logs.AppendText(username + " to IF100: " + incomingMessage.Substring(9) + "\n");
                                    foreach (Socket client in channelIF100)
                                    {
                                        string msg_to_if100 = "__IF100__" + "__" + username + "__*.*" + incomingMessage; //tokenized and username added
                                        Byte[] back_to_clients = Encoding.Default.GetBytes(msg_to_if100);
                                        client.Send(back_to_clients);

                                    }
                                }
                                else if ((incomingMessage.Substring(0, 10) == "__SPS101__") && incomingMessage.Length >= 10)
                                {
                                    logs.AppendText(username + " to SPS101: " + incomingMessage.Substring(10) + "\n");
                                    foreach (Socket client in channelSPS101)
                                    {
                                        string msg_to_sps101 = "__SPS101__" + "__" + username + "__*.*" + incomingMessage;  //same with if100
                                        Byte[] back_to_clients = Encoding.Default.GetBytes(msg_to_sps101);
                                        client.Send(back_to_clients);

                                    }
                                }
                            }
                            
                            else  //general chat by a user
                            {
                                logs.AppendText(username + " to General: " + incomingMessage + "\n");  
                                foreach (Socket client in clientSockets)
                                {
                                    incomingMessage = "__" + username + "__*.*" + incomingMessage;  //username added into message
                                    Byte[] back_to_clients = Encoding.Default.GetBytes(incomingMessage);
                                    client.Send(back_to_clients);
                                }
                                
                            }
                        }
                        catch
                        {
                            if (!terminating)
                            {
                                string disconnection_msg = username + " has disconnected.\n";
                                logs.AppendText(disconnection_msg);
                                Byte[] disconnect_buff = Encoding.Default.GetBytes(disconnection_msg);
                                foreach (Socket client in clientSockets)
                                {
                                    client.Send(disconnect_buff); //others are notified for disconnection of a user
                                }
                                thisClient.Close();
                                clientSockets.Remove(thisClient);
                                clientUsernames.Remove(thisClient);

                                //removed from channels
                                if (channelIF100.Contains(thisClient))
                                {
                                    channelIF100.Remove(thisClient);
                                }
                                if (channelSPS101.Contains(thisClient))
                                {
                                    channelSPS101.Remove(thisClient);
                                }
                                connected = false;
                            }
                            
                        }
                    }
                }
            }
            catch  //error means some kind of a problem occurred in connection
            {
                
                thisClient.Close();
                clientSockets.Remove(thisClient);
                clientUsernames.Remove(thisClient);
                connected = false;
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e) //server GUI shut by clicking x
        {
            terminating = true;

            string shutoff = "The server has been shut down.";
            Byte[] disconnect_end = Encoding.Default.GetBytes(shutoff);
            foreach (Socket client in clientSockets)
            {
                client.Send(disconnect_end); //notification to others
                client.Close();
            }
            serverSocket.Close();
            Environment.Exit(0);  //end of threads
        }

        private void button_send_Click(object sender, EventArgs e)  //sending to general chat
        {
            string message = textBox_message.Text;
            if (message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                
                try
                {
                    foreach (Socket client in clientSockets)
                    {
                        client.Send(buffer);
                    }
                    logs.AppendText("Server: " + message + "\n");
                }
                catch  //error means a connection problem exists
                {
                    logs.AppendText("There is a problem! Check the connection...\n");
                    terminating = true;  //GUI setup
                    textBox_message.Enabled = false;
                    textBox_if100.Enabled = false;
                    button_if100.Enabled = false;
                    textBox_sps101.Enabled = false;
                    button_sps101.Enabled = false;
                    button_send.Enabled = false;
                    textBox_port.Enabled = true;
                    button_listen.Enabled = true;
                    serverSocket.Close();
                }
                
                
            }
        }

        //rest is same with general send button
        private void button_if100_Click(object sender, EventArgs e)
        {
            string message_to_if100 = "__IF100__"+ textBox_if100.Text;
            Byte[] buffer = Encoding.Default.GetBytes(message_to_if100);
            
            try
            {
                foreach (Socket client in channelIF100)
                {
                    client.Send(buffer);
                }
                logs.AppendText("Server to IF100: " + message_to_if100.Substring(9) + "\n");
            }
            catch
            {
                logs.AppendText("There is a problem! Check the connection...\n");
                terminating = true;
                textBox_message.Enabled = false;
                textBox_if100.Enabled = false;
                button_if100.Enabled = false;
                textBox_sps101.Enabled = false;
                button_sps101.Enabled = false;
                button_send.Enabled = false;
                textBox_port.Enabled = true;
                button_listen.Enabled = true;
                serverSocket.Close();
            }
            
        }

        private void button_sps101_Click(object sender, EventArgs e)
        {
            string message_to_sps101 = "__SPS101__"+textBox_sps101.Text;
            Byte[] buffer = Encoding.Default.GetBytes(message_to_sps101);
            
            try
            {
                foreach (Socket client in channelSPS101)
                {
                    client.Send(buffer);
                    
                }
                logs.AppendText("Server to SPS101: " + textBox_sps101.Text + "\n");
            }
            catch
            {
                logs.AppendText("There is a problem! Check the connection...\n");
                terminating = true;
                textBox_message.Enabled = false;
                textBox_if100.Enabled = false;
                button_if100.Enabled = false;
                textBox_sps101.Enabled = false;
                button_sps101.Enabled = false;
                button_send.Enabled = false;
                textBox_port.Enabled = true;
                button_listen.Enabled = true;
                serverSocket.Close();
            }
            
        }
    }
}
