using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Deck
    {
        private List<Card> deck;

        public Deck()
        {
            deck = new List<Card>();

            foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                    deck.Add(new Card(v, s));
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int r = rnd.Next(0, 52);
                Card temp = deck[i];
                deck[i] = deck[r];
                deck[r] = temp;
            }
        }

        public Card Deal()
        {
            Card c = deck[0];
            deck.RemoveAt(0);
            return c;
        }

        public List<Card> getDeckList()
        {
            return deck;
        }

        public void Print()
        {
            foreach (Card c in deck)
                Console.WriteLine(c.getValue() + " " + c.getSuit());
        }
    }
}
