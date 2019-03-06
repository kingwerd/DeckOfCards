using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    interface IDealable
    {
        Card Deal();
        void Discard(List<Card> card);
        void DealerShuffle();
    }
}