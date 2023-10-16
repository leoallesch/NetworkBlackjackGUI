using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Network;
using Blackjack;

namespace Forms
{
    public partial class ServerGame : Form
    {
        private Server server;
        private bool dealerTurn;

        public ServerGame(Server x)
        {           
            dealerTurn = false;
            server = x;

            InitializeComponent();
        }

        public void Start()
        {
            foreach (Card c in server.getGame().getClientHand())
                server.Send(server.s, c);

            addCard(PLAYER.CLIENT, server.getGame().getClientHand()[0], true);
            addCard(PLAYER.CLIENT, server.getGame().getClientHand()[1], false);

            bool turn = true;

            while (turn)
            {
                string message = server.Receive(server.s);

                if (message.Equals("y"))
                {
                    server.getGame().Hit(PLAYER.CLIENT);
                    Card c = server.getGame().getClientHand().Last();
                    addCard(PLAYER.CLIENT, c, false);
                    server.Send(server.s, c);
                    bool bust = server.getGame().CheckBust(PLAYER.CLIENT);
                    if (bust)
                    {
                        turn = false;
                        MessageBox.Show("Client Bust\nDealer Wins");
                        server.Send(server.s, bust.ToString());
                        goto End;
                    }
                    else
                        server.Send(server.s, bust.ToString());
                }
                else
                    turn = false;
            }

            foreach (Card c in server.getGame().getDealerHand())
            {
                server.Send(server.s, c);
                addCard(PLAYER.DEALER, c, false);
            }
            dealerTurn = true;

        End:;

        }


        public void addCard(PLAYER p, Card c, bool flipped)
        {
            PictureBox pB = new PictureBox
            {
                Size = MaximumSize,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            if (flipped)
                pB.Image = Image.FromFile(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).FullName + "\\src\\img\\FLIPPED.png");
            else
                pB.Image = Image.FromFile(c.getImgPath());

            if (p == PLAYER.CLIENT)
                clientPanel.Controls.Add(pB);
            else
                dealerPanel.Controls.Add(pB);
        }

        public void CheckWin()
        {
            if (server.getGame().CheckWin() == PLAYER.CLIENT)
            {
                server.Send(server.s, "True");
                MessageBox.Show("Client Wins");
            }
            else
            {
                server.Send(server.s, "False");
                MessageBox.Show("Dealer Wins");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dealerTurn)
            {
                server.Send(server.s, "y");
                server.getGame().Hit(PLAYER.DEALER);
                Card c = server.getGame().getDealerHand().Last();
                addCard(PLAYER.DEALER, c, false);
                server.Send(server.s, c.toString());
                bool bust = server.getGame().CheckBust(PLAYER.DEALER);
                if (bust)
                {
                    MessageBox.Show("Bust\nClient Wins");
                    dealerTurn = false;
                }
                server.Send(server.s, bust.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dealerTurn)
            {
                server.Send(server.s, "n");
                CheckWin();
            }
        }

        private void ServerGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Stop();
        }

        private void ServerGame_Load(object sender, EventArgs e)
        {
            server.s = server.listener.AcceptSocket();
            Console.WriteLine("Connection accepted from " + server.s.RemoteEndPoint);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
