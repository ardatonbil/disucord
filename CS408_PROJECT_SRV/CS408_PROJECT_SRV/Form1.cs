using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CS408_PROJECT_SRV
{
    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //socket opened
        List<Socket> clientSockets = new List<Socket>();  //new socket list
        bool terminating = false;   //currently no termination
        bool listening = false;     // not listening
        
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_Form1Closing);  
            InitializeComponent();
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;
            if (Int32.TryParse(textbox_port.Text, out serverPort))    //if input value in port textbox is valid
            {
                //port geçersiz olduğundaki durumu da yazsak fena olmaz
                //bu yorumu sil tabi hehe
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);  //problemli kısım burası, porta bağlandıktan sonra durup yeniden bağlanınca sorun oluyor
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;   //listening button is disabled as it is already listening
                button_stop.Enabled = true;      //stop button is enabled

                Thread acceptThread = new Thread(Accept);  //accept function started on a new thread
                acceptThread.Start();  //accepting messages from clients

                textbox_action.AppendText("Started listening on port: " + serverPort + "\n"); 

            }

        }
        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();   
                    clientSockets.Add(newClient);  
                    textbox_action.AppendText("A client is connected.\n");

                    Thread receiveThread = new Thread(() => Receive(newClient));  //open to receive messages
                    receiveThread.Start();
                }
                catch
                {
                    if (terminating)  //if terminating variable is true
                    {
                        listening = false;
                    }
                    else
                    {
                        textbox_action.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }
        
        private void Receive(Socket thisClient) 
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];  
                    thisClient.Receive(buffer);   //receive messages from clients as byte arrays

                    string incomingMessage = Encoding.Default.GetString(buffer);   //array to string
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    textbox_action.AppendText("Client: " + incomingMessage + "\n");  //append to textbox
                }
                catch
                {
                    if (!terminating)
                    {
                        textbox_action.AppendText("A client has disconnected\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);  //socket removal
                    connected = false;
                }
            }
        }

        private void button_stop_Click(object sender, EventArgs e)  //does not terminate whole process, just stops listening
        {
            listening = false;
            terminating = true;
            button_stop.Enabled = false;
            button_listen.Enabled = true;
            serverSocket.Close();
            textbox_action.AppendText("Listening ended.\n");
        }
        private void Form1_Form1Closing(object sender, System.ComponentModel.CancelEventArgs e)  //shuts the whole process
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }
    }
}
