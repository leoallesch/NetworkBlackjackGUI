using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

using Blackjack;

namespace Network 
{
    public class Client
    {
        private Game g;
        private int port;
        private IPAddress ip;
        private bool connected;
        private TcpClient client;
        private Stream strm;

        public Client(string i, int p)
        {
            connected = false;
            ip = IPAddress.Parse(i);
            port = p;
            client = new TcpClient();

            g = new Game(false);
        }

        public void Connect()
        {
            Console.WriteLine("Connecting.....");
            client.Connect(ip, port);
            Console.WriteLine("Connected");
            strm = client.GetStream();
            connected = true;
        }

        public void Disconnect()
        {
            if (connected)
                client.Close();
        }

        public string Receive()
        {
            if (connected)
            {
                byte[] bb = new byte[100];
                int k = strm.Read(bb, 0, 100);
                string sent = "";

                for (int i = 0; i < k; i++)
                    sent += Convert.ToChar(bb[i]);
                return sent;
            }
            return "NULL";

        }

        public void Send(string str)
        {
            if (connected)
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                strm.Write(ba, 0, ba.Length);
            }

        }

        public Game getGame() { return g; }

    }

        /*
        public void recieveHit(List<Card> hand)
        {
            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);
            string sent = "";

            for (int i = 0; i < k; i++)
                sent += Convert.ToChar(bb[i]);

            Console.WriteLine(sent);

            if (!sent.Equals(""))
                g.Hit(hand, new Card(sent));
        }

        public bool recieveCheck()
        {
            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 30);
            string sent = "";

            for (int i = 0; i < k; i++)
                sent += Convert.ToChar(bb[i]);

            if (sent.Equals("True"))
                return true;
            else
                return false;
        }
    }
        */
}