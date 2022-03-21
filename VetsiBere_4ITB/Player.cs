using System.Collections.Generic;

namespace VetsiBere_4ITB
{
    internal class Player
    {
        private string name;
        private List<Card> cards;

        public string Name { get => name; set => name = value; }
        internal List<Card> Cards { get => cards; set => cards = value; }
    
        public Player(string name)
        {
            this.name = name;
            cards = new List<Card>();
        }
    }
}
