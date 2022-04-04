using System;
using System.Collections.Generic;

namespace VetsiBere_4ITB
{
    public class Player
    {
        public event Action<int> CountOfCardsChanged;

        private string name;
        private Queue<Card> cards;

        public string Name { get => name; set => name = value; }
        private Queue<Card> Cards { get => cards; set => cards = value; }
    
        public int CountOfCards => cards.Count;
        
        public Player(string name)
        {
            this.name = name;
            cards = new Queue<Card>();
        }

        public void EnqueueCard(Card card)
        {
            Cards.Enqueue(card);
            CountOfCardsChanged?.Invoke(CountOfCards);
        }

        public Card DequeueCard()
        {
            if (Cards.Count > 0)
            {
                var card = Cards.Dequeue();
                CountOfCardsChanged?.Invoke(CountOfCards);
                return card;
            }
            return null;
        }
    }
}
