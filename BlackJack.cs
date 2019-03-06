using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class BlackJack
    {
        Dealer Dealer;
        List<Player> Players;

        public BlackJack()
        {
            Dealer = new Dealer();
            Players = new List<Player>();
        }

        public void AddPlayer(string name)
        {
            Player player = new Player(name);
            Players.Add(player);
        }

        public void ConfigureGame()
        {
            Console.WriteLine("Welcome to Black Jack. Lets Start!");
            int starter = 2;
            while (starter == 2)
            {
                Console.Write("Add Player Name: ");
                string name = Console.ReadLine();
                AddPlayer(name);
                Console.WriteLine("Enter 1 to Begin | 2 to Add Another Player");
                starter = Convert.ToInt32(Console.ReadLine());
            }
            StartGame();
        }

        public void StartGame()
        {
            // Deal cards to both dealer and the players
            int i = 0;
            while (i < 2)
            {
                Dealer.AddToHand(Dealer.Deal());
                foreach (var player in Players)
                {
                    player.AddToHand(Dealer.Deal());
                }
                i += 1;
            }
            foreach (var player in Players)
            {
                Console.WriteLine($"Dealer faceup card: {Dealer.Hand[0].Value} of {Dealer.Hand[0].Suit}");
                foreach (var card in player.Hand)
                {
                    Console.WriteLine($"{player.Name}'s cards: {card.Value} of {card.Suit}");
                }
                Console.WriteLine($"{player.Name}'s total: {player.HandValue()}");
                bool onPlayer = true;
                while(onPlayer)
                {
                    Console.WriteLine("1 = Hit | 2 = Stay");
                    int move = Convert.ToInt32(Console.ReadLine());
                    if (move == 1)
                    {
                        player.AddToHand(Dealer.Deal());
                        Card pCard = player.Hand[player.Hand.Count - 1];
                        Console.WriteLine($"{player.Name} drew card: {pCard.Value} of {pCard.Suit}");
                        if (player.HandValue() > 21)
                        {   
                            Console.WriteLine("You have busted. You loose.");
                            onPlayer = false;
                        }
                        else
                        {
                            Console.WriteLine($"{player.Name} total is now {player.HandValue()}");
                        }
                    }
                    else if (move == 2)
                    {
                        onPlayer = false;
                    }
                }
            }
            Console.WriteLine($"Dealer face down card: {Dealer.Hand[1].Value} of {Dealer.Hand[1].Suit}");
            while (Dealer.HandValue() < 17)
            {   
                Dealer.AddToHand(Dealer.Deal());
                Card dCard = Dealer.Hand[Dealer.Hand.Count - 1];
                Console.WriteLine($"Dealer drew card: {dCard.Value} of {dCard.Suit}");
            }
            int winValue = 0;
            Console.WriteLine(Dealer.HandValue());
            if (Dealer.HandValue() >= 17 && Dealer.HandValue() <= 21)
            {
                winValue = Dealer.HandValue();
            }
            else
            {
                Console.WriteLine("Dealer busted you win.");
            }
            foreach (var player in Players)
            {
                if (player.HandValue() > winValue && player.HandValue() < 22)
                {
                    Console.WriteLine($"{player.Name} Won! Congrats!");
                }
                else if (player.HandValue() == winValue && player.HandValue() < 22)
                {
                    Console.WriteLine($"{player.Name} Tied With The Dealer");
                }
                else
                {
                    Console.WriteLine($"{player.Name} You Lost! Try Again Later!");
                }
            }
            Console.WriteLine("Do you want to play a new game?");
            Console.Write("1 = yes | 2 = no");
            int playAgain = Convert.ToInt32(Console.ReadLine());
            if (playAgain == 1)
            {
                foreach (var player in Players)
                {
                    Dealer.Discard(player.Hand);
                    player.Hand.Clear();
                }
                Dealer.Discard(Dealer.Hand);
                Dealer.Hand.Clear();
                Players.Clear();
                Dealer.DealerShuffle();
                ConfigureGame();
            }
        }

    }
}