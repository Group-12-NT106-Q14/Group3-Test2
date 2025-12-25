using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Group3_Test2
{
    public partial class server : Form
    {
        TcpListener listener;
        bool running = false;

        List<TcpClient> clients = new List<TcpClient>();

        public server()
        {
            InitializeComponent();
        }

        private void server_Load(object sender, EventArgs e)
        {

            listener = new TcpListener(IPAddress.Any, 9999);
            listener.Start();
            running = true;

            Log("Server đang chạy tại port 9999");

            Thread acceptThread = new Thread(AcceptClient);
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }

        private void AcceptClient()
        {
            while (running)
            {
                TcpClient client = listener.AcceptTcpClient();
                clients.Add(client);

                string clientIP = client.Client.RemoteEndPoint.ToString();

                Invoke(new Action(() =>
                {
                    lstBclient.Items.Add(clientIP);
                    Log("Client kết nối: " + clientIP);
                }));

                Thread t = new Thread(() => ReceiveData(client));
                t.IsBackground = true;
                t.Start();
            }
        }

        private void ReceiveData(TcpClient client)
        {
            byte[] buffer = new byte[1024];
            NetworkStream stream = client.GetStream();

            try
            {
                while (true)
                {
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    if (bytes == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes);
                    Log("Client: " + msg);
                }
            }
            catch { }
            finally
            {
                string ip = client.Client.RemoteEndPoint.ToString();
                Invoke(new Action(() =>
                {
                    lstBclient.Items.Remove(ip);
                    Log("Client ngắt kết nối: " + ip);
                }));

                clients.Remove(client);
                client.Close();
            }
        }


        private void btnMessage_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (msg == "") return;

            Broadcast(msg);
            Log("Broadcast: " + msg);
            txtMessage.Clear();
        }

        private void Broadcast(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            foreach (TcpClient client in clients)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                }
                catch { }
            }
        }

        private void Log(string text)
        {
            txtEvent.AppendText($"{DateTime.Now:HH:mm:ss} | {text}\r\n");
        }

        private void Message_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (msg == "") return;

            Broadcast(msg);
            Log("Broadcast: " + msg);
            txtMessage.Clear();
        }
    }
}
