using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Blackjack;

namespace Network
{
    public class Server
    {
        private Game g;
        public TcpListener listener;
        private int port;
        private IPAddress ip;

        public Socket s;
        public bool running;

        public Server(string i, int p)
        {
            running = false;
            g = new Game(true);
            port = p;
            ip = IPAddress.Parse(i);
            listener = new TcpListener(ip, port);
        }

        public void Start()
        {
            if (!running)
            {
                listener.Start();

                Console.WriteLine("The server is running at port " + port + "...");
                Console.WriteLine("The local End point is:  " + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
                running = true;
            }
        }

        public void Stop()
        {
            if (running)
            {
            s.Close();
            listener.Stop();

            running = false;

            Console.WriteLine("Server and connection closed");
            }    
        }

        public string Receive(Socket s)
        {
            string message = "";
            if (running)
            {
                var b = new byte[100];
                var k = s.Receive(b);

                for (int i = 0; i < k; i++)
                    message += Convert.ToChar(b[i]);
                return message;
            }
            return "NULL";
        }

        public void Send(Socket s, Card c)
        {
            if (running)
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                string message = c.toString();
                s.Send(asen.GetBytes(message));
            }     
        }

        public void Send(Socket s, string m)
        {
            if (running)
            {
                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes(m));
            }
        }

        public Game getGame() { return g; }

    }
}
