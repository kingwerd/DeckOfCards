using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lets Play Some Black Jack!!!");
            BlackJack game = new BlackJack();
            game.ConfigureGame();
        }
    }
}
