using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientServerDll;

namespace Server
{
    public partial class ServerForm : Form
    {
        private Socket listenSocket;
        private static int senderBufferSize = 500;

        public ServerForm()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void ServerForm_Load(object sender, EventArgs e)
        {
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(Dns.Resolve(SystemInformation.ComputerName).AddressList[1], 22000));
            listenSocket.Listen(1);
            Task.Run(() => ListenMethod(listenSocket));
        }

        private void ListenMethod(Socket listenSocket)
        {
            while (true)
            {
                try
                {
                    Socket clientSocket = listenSocket.Accept();
                    Task.Run(() => ReadPathToFile(clientSocket));
                }
                catch { }
            }
        }

        private void ReadPathToFile(Socket clientSocket)
        {
            while (true)
            {
                byte[] buffer = new byte[256];
                int nCount = clientSocket.Receive(buffer);
                string pathToFile = Encoding.UTF8.GetString(buffer, 0, nCount);
                if (!File.Exists(pathToFile)) continue;
                Task.Run(() => SendPacketsToClient(pathToFile, clientSocket));
            }
        }

        private void SendPacketsToClient(string pathToFile, Socket clientSocket)
        {
            byte[] file = File.ReadAllBytes(pathToFile);

            if (file.Length <= senderBufferSize)
                clientSocket.Send(Converter.ToByteArray(new NetworkElement(0, file)));
            else
            {
                int remainder = file.Length % senderBufferSize, wholePacketsCount = (file.Length - remainder) / senderBufferSize, i = 0, position = 0;

                while (i < wholePacketsCount)
                {
                    clientSocket.Send(Converter.ToByteArray(new NetworkElement(i++, SubArray(file, position, senderBufferSize))));
                    position += senderBufferSize;
                }

                if (remainder > 0)
                    clientSocket.Send(Converter.ToByteArray(new NetworkElement(i, SubArray(file, position, remainder))));
            }
        }

        public T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e) => listenSocket.Close();
    }
}