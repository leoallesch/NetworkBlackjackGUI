using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Reflection;
using System.Collections.Generic;



namespace Blackjack
{
    public enum PLAYER { CLIENT, DEALER };
    public class Game
    {
        private List<Card> clientHand;
        private List<Card> dealerHand;
        private Deck d;

        public Game(bool b)
        {
            d = new Deck();
            clientHand = new List<Card>();
            dealerHand = new List<Card>();
            if (b)
            {
                d.Shuffle();

                clientHand.Add(d.Deal());
                clientHand.Add(d.Deal());
                dealerHand.Add(d.Deal());
                dealerHand.Add(d.Deal());
            }
            
        }

        public void Hit(PLAYER p)
        {
            if (p == PLAYER.CLIENT)
                clientHand.Add(d.Deal());
            else if (p == PLAYER.DEALER)
                dealerHand.Add(d.Deal());
            else
                Console.WriteLine("Invalid Player Type.");
        }

        public void Hit(PLAYER p, Card c)
        {
            if (p == PLAYER.CLIENT)
                clientHand.Add(c);
            else if (p == PLAYER.DEALER)
                dealerHand.Add(c);
            else
                Console.WriteLine("Invalid Player Type.");
        }

        public bool CheckBust(PLAYER p)
        {
            int total = getTotal(p);
            if (total > 21)
                return true;
            else
                return false;
            /*
             List<Card> hand;

            if (p == PLAYER.CLIENT)
                hand = clientHand;
            else if (p == PLAYER.DEALER)
                hand = dealerHand;
            else
                hand = new List<Card>();

            int numAces = 0;
            int total = 0;

            foreach (Card c in hand)
            {
                if (c.getValue() == VALUE.ACE)
                    numAces++;
                else
                    total += c.getNumericValue();
            }

            if (numAces > 0)
            {
                if (total + 11 + (numAces - 1) > 21)
                {
                    if (total + numAces > 21)
                        return true;
                }
            }
            else
            {
                if (total > 21)
                    return true;
            }    
            return false;
            */
        }

        public int getTotal(PLAYER p)
        {
            List<Card> hand;

            if (p == PLAYER.CLIENT)
                hand = clientHand;
            else if (p == PLAYER.DEALER)
                hand = dealerHand;
            else
                hand = new List<Card>();

            int numAces = 0;
            int total = 0;

            foreach (Card c in hand)
            {
                if (c.getValue() == VALUE.ACE)
                    numAces++;
                else
                    total += c.getNumericValue();
            }

            if (numAces > 0)
            {
                if (total + 11 + (numAces - 1) > 21)
                {
                    total += numAces;
                }
                else
                    total += 11 + (numAces - 1);
            }

            return total;
        }

        public PLAYER CheckWin()
        {
            int client = getTotal(PLAYER.CLIENT);
            int dealer = getTotal(PLAYER.DEALER);

            if (client > dealer)
                return PLAYER.CLIENT;
            else
                return PLAYER.DEALER;
        }

        public void printHand(PLAYER p)
        {
            List<Card> hand;
            if (p == PLAYER.CLIENT) 
                hand = clientHand;
            else if (p == PLAYER.DEALER) 
                hand = dealerHand;
            else
                hand = new List<Card>();

            foreach (Card c in hand)
                Console.WriteLine(c.getValue() + " " + c.getSuit());
        }

        public List<Card> getClientHand() {  return clientHand; }
        
        public List<Card> getDealerHand() { return dealerHand; }

    }

}