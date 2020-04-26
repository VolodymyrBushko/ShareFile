using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientServerDll;

namespace Client
{
    public partial class ClientForm : Form
    {
        private Socket clientSocket;
        private List<NetworkElement> elements;
        private static int packetSize = 707;

        public ClientForm()
        {
            InitializeComponent();
            elements = new List<NetworkElement>();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(IPAddress.Parse("192.168.0.104"), 22000);
            }
            catch { MessageBox.Show("Could not find server..."); Close(); }
        }

        private void buttonSendPath_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxPath.Text))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(textBoxPath.Text);
                clientSocket.Send(buffer, buffer.Length, SocketFlags.None);
                Task.Run(() => ReceivePacketsFromServer(clientSocket));
            }
            else
                MessageBox.Show("Bad path...");
        }

        private void ReceivePacketsFromServer(Socket clientSocket)
        {
            elements.Clear();
            while (true)
            {
                byte[] buffer = new byte[packetSize];
                int nCount = clientSocket.Receive(buffer, packetSize, SocketFlags.None);
                elements.Add(Converter.FromByteArray<NetworkElement>(buffer));
                buttonGetFile.Invoke(new Action(() => { buttonGetFile.ForeColor = Color.Green; }));
            }
        }

        private void buttonGetFile_Click(object sender, EventArgs e)
        {
            elements.Sort();
            byte[] file = new byte[0];
            elements.ForEach(element => file = file.Concat(element.Buffer).ToArray());

            try
            {
                File.WriteAllBytes(textBoxNewPath.Text, file);
                MessageBox.Show($"File received!\tBytes : {file.Length}");
            }
            catch { MessageBox.Show("Bad new path..."); }
            buttonGetFile.ForeColor = Color.Black;
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e) => clientSocket.Close();
    }
}