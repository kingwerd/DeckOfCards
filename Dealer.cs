using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Dealer : Player, IDealable
    {
        private Deck deck;
        public Dealer() : base("Dealer") {
            deck = new Deck();
            // deck.Shuffle();
        }
        public Card Deal()
        {
            return deck.NewCard;
        }
        public void Discard(List<Card> cards)
        {
            deck.AddToDiscard(cards);
        }

        public void DealerShuffle()
        {
            deck.Shuffle();
        }
    }
}