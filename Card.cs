using System;

namespace DeckOfCards
{
    public class Card
    {
        private string _value;
        private string _suit;
        private int _rank;

        public string Value
        {
            get { return _value; }
        }
        public string Suit
        {
            get { return _suit; }
        }
        public int Rank
        {
            get { return _rank; }
        }

        public Card(string val, string suit, int rank)
        {
            _value = val;
            _suit = suit;
            _rank = rank;
        }
    }
}