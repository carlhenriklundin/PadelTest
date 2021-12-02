using System;
using Padel;

namespace PadelTestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            

            for (int i = 1; i < 10; i++)
            {
                Player[] players = new Player[] { new Player("Player 1"), new Player("Player 2") };
                var game = new Game(players[0], players[1]);

                while(!game.gameFinished)
                {
                    var rnd = new Random();

                    game.Point(players[rnd.Next(0, 2)]);

                    Console.WriteLine($"Ställningen: {game.Score()}");
                }

                Console.WriteLine(game.ScoreString());
                Console.WriteLine("------------------------");
                Console.WriteLine();
            }
        }
    }
}
