using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Network;
using Blackjack;
using System.Diagnostics;

namespace Forms
{
    public partial class ClientGame : Form
    {
        Client c;
        bool clientTurn;

        public ClientGame(Client client)
        {
            c = client;
            clientTurn = true;

            InitializeComponent();
        }

        public void addCard(PLAYER p, Card c)
        {
            if (p == PLAYER.CLIENT)
                label1.Text += c.toString() + "\n";
            else
                label2.Text += c.toString() + "\n";
        }

        public void dealerTurn()
        {
            if (!clientTurn)
            {
                c.getGame().Hit(PLAYER.DEALER, new Card(c.Receive()));
                c.getGame().Hit(PLAYER.DEALER, new Card(c.Receive()));

                foreach (Card c in c.getGame().getDealerHand())
                {
                    addCard(PLAYER.DEALER, c);
                }

                bool bust;
                string message;

                do
                {
                    message = c.Receive();
                    bust = false;
                    if (message.Equals("y"))
                    {
                        c.getGame().Hit(PLAYER.DEALER, new Card(c.Receive()));
                        if (c.Receive() == "True")
                            bust = true;
                    }
                } while (message.Equals("y") && !bust);

                if (bust)
                    MessageBox.Show("Dealer Bust. Client Wins.");
                else
                {
                    bool win = false;
                    if (c.Receive() == "True")
                        win = true;
                    if (win)
                        MessageBox.Show("Client Wins!");
                    else
                        MessageBox.Show("Client Loses, Dealer Wins.");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clientTurn)
            {
                c.Send("y");
                Card card = new Card(c.Receive());
                c.getGame().Hit(PLAYER.CLIENT, card);
                addCard(PLAYER.CLIENT, card);
                if (c.Receive() == "True")
                {
                    MessageBox.Show("Bust. Dealer Wins");
                    clientTurn = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (clientTurn)
            {
                c.Send("n");
                clientTurn = false;
                dealerTurn();
            }
        }

        private void ClientGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            c.Disconnect();
        }

        private void ClientGame_Load(object sender, EventArgs e)
        {
            c.getGame().Hit(PLAYER.CLIENT, new Card(c.Receive()));
            c.getGame().Hit(PLAYER.CLIENT, new Card(c.Receive()));

            foreach (Card c in c.getGame().getClientHand())
            {
                addCard(PLAYER.CLIENT, c);
            }
        }
    }
}
