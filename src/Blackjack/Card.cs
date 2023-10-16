using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public enum VALUE { ACE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING };
    public enum SUIT { HEART, DIAMOND, CLUB, SPADE };
    public class Card
    {
        private VALUE val;
        private SUIT suit;
        private string imgPath;

        public Card(VALUE v, SUIT s)
        {
            val = v;
            suit = s;
            imgPath = "img\\" + s + "\\" + v + ".png";
        }

        public Card (string s)
        {
            string[] sA = s.Split(' ');
            Enum.TryParse(sA[0], out val);
            Enum.TryParse(sA[1], out suit);
            imgPath = sA[2];
        }

        public VALUE getValue()
        {
            return val;
        }

        public int getNumericValue()
        {
            if (val == VALUE.JACK || val == VALUE.QUEEN || val == VALUE.KING)
                return 10;

            else if (val == VALUE.ACE)
                return 1;

            else
                return (int)val + 1;
        }

        public SUIT getSuit()
        {
            return suit;
        }

        public string getImgPath()
        {
            return imgPath;
        }

        public string toString()
        {
            return val + " " + suit + " " + imgPath;
        }
    }
}
