using System;
using Padel;

namespace PadelTestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[] { new Player("Player 1"), new Player("Player 2") };

            Match match = new Match(3, players[0], players[1]);

            while (!match.matchOver)
            {
                var rnd = new Random();

                match.Point(players[rnd.Next(0, 2)]);
               
            }
            Console.WriteLine(match.ScoreString());
            
        }
    }
}
