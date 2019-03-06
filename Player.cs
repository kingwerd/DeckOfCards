using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        private string _name;
        private List<Card> _hand;
        public List<Card> Hand
        {
            get { return _hand; }
        }
        public string Name
        {
            get { return _name; }
        }
        public Player(string name)
        {
            _name = name;
            _hand = new List<Card>();
        }

        public void AddToHand(Card card)
        {
            _hand.Add(card);
        }

        public int HandValue()
        {
            int num = 0;
            foreach (var card in _hand)
            {
                num += card.Rank;
            }
            return num;
        }
    }
}