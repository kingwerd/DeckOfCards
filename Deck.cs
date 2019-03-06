using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Deck
    {
        private List<Card> Cards;
        public List<Card> DiscardPile;
        public Card NewCard
        {
            get { return Draw(); }
        }
        public Deck()
        {
            Cards = new List<Card>();
            DiscardPile = new List<Card>();
            Dictionary<string, int> types = new Dictionary<string, int>()
            {
                {"Two", 2},
                {"Three", 3},
                {"Four", 4},
                {"Five", 5},
                {"Six", 6},
                {"Seven", 7},
                {"Eight", 8},
                {"Nine", 9},
                {"Ten", 10},
                {"Jack", 10},
                {"Queen", 10},
                {"King", 10},
                {"Ace", 11}
            };
            string[] suits = {"Hearts", "Diamonds", "Spades", "Clubs"};
            
            // create a deck with 52 cards in it when initialized
            foreach (var suit in suits)
            {
                foreach (var type in types)
                {
                    Card card = new Card(type.Key, suit, type.Value);
                    Cards.Add(card);
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            if (DiscardPile.Count > 0)
            {
                Cards.AddRange(DiscardPile);
                DiscardPile.Clear();
            }
            Random ran = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int k = ran.Next(i+1);
                Card temp = Cards[i];
                Cards[i] = Cards[k];
                Cards[k] = temp;
            }
        }

        private Card Draw()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public void AddToDiscard(List<Card> cards)
        {
            DiscardPile.AddRange(cards);
        }
    }
}