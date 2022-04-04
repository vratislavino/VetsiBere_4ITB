using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetsiBere_4ITB
{
    public class CardCreator
    {
        private CardValues[] cardValues = { 
            new CardValues("A", 13),
            new CardValues("2", 1),
            new CardValues("3", 2),
            new CardValues("4", 3),
            new CardValues("5", 4),
            new CardValues("6", 5),
            new CardValues("7", 6),
            new CardValues("8", 7),
            new CardValues("9", 8),
            new CardValues("10", 9),
            new CardValues("J", 10),
            new CardValues("Q", 11),
            new CardValues("K", 12),

        };
        private List<Card> cards;
        public List<Card> Cards => cards;

        public CardCreator(string path)
        {

            cards = new List<Card>();
            Bitmap bmp = (Bitmap)Image.FromFile(path);
            int cardWidth = bmp.Width / 13;
            int cardHeight = bmp.Height / 4;

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Bitmap cardBmp = bmp.GetPart(i * cardWidth, j * cardHeight, cardWidth, cardHeight);
                    Card c = new Card((Symbol)j, cardValues[i].jmeno, cardValues[i].hodnota, cardBmp);
                    cards.Add(c);
                }
            }
        }

    }

    public struct CardValues
    {
        public int hodnota;
        public string jmeno;
        public CardValues(string jmeno, int hodnota)
        {
            this.jmeno = jmeno;
            this.hodnota = hodnota;
        }
    }

    public class Card
    {
        public Symbol symbol;
        public string nazev;
        public int hodnota;
        public Bitmap bitmap;

        public string FullName => $"({symbol}) {nazev}";

        public Card(Symbol symbol, string nazev, int hodnota, Bitmap bitmap)
        {
            this.symbol = symbol;
            this.nazev = nazev;
            this.hodnota = hodnota;
            this.bitmap = bitmap;
        }

        public override string ToString()
        {
            return $"{nazev} ({hodnota})";
        }
    }

    public enum Symbol
    {
        Srdce, Piky, Kary, Krize
    }
}
