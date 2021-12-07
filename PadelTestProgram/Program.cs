using System;
using Padel;

namespace PadelTestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[] { new Player("Player 1"), new Player("Player 2") };


            // Kör 10 game.
            for (int i = 0; i < 10; i++)
            {
                Game game = new Game(players[0], players[1]);

                Console.WriteLine($"Game {i+1}:");
                while (!game.gameOver)
                {
                    var rnd = new Random();

                    game.Point(players[rnd.Next(0, 2)]);
                    Console.WriteLine($"{game.Score()}");
                }

                Console.WriteLine($"Result: {game.ScoreString()}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();


            // Kör 10 tiebreak.
            for (int i = 0; i < 10; i++)
            {
                Game game = new Game(players[0], players[1]);
                game.tiebreak = true;

                Console.WriteLine($"Tiebreak {i+1}:");
                while (!game.gameOver)
                {
                    var rnd = new Random();

                    game.Point(players[rnd.Next(0, 2)]);
                    Console.WriteLine($"{game.Player1.Score._Score}-{game.Player2.Score._Score}");
                }

                Console.WriteLine($"Result: {game.ScoreString()}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();


            // Kör 20 set.
            for (int i = 0; i < 20; i++)
            {
                Set set = new Set(players[0], players[1]);

                while (!set.setOver)
                {
                    var rnd = new Random();

                    set.Point(players[rnd.Next(0, 2)]);
                }

                Console.WriteLine($"SetScore: {set.setScore.player1._Score}-{set.setScore.player2._Score} - {set.ScoreString()}");
            }

            Console.WriteLine();
            Console.WriteLine();

            // Kör en match.


            for (int i = 0; i < 10; i++)
            {
                Match match1 = new Match(5, players[0], players[1]);
                while (!match1.matchOver)
                {
                    var rnd = new Random();
                    match1.Point(players[rnd.Next(0, 2)]);
                }

                Console.WriteLine("Slutresultat:");
                Console.WriteLine(match1.ResultString());
                Console.WriteLine();
            }



            Match match2 = new Match(5, players[0], players[1]);
            while (!match2.matchOver)
                {
                    var rnd = new Random();

                    match2.Point(players[rnd.Next(0, 2)]);
                    if (!match2.matchOver) Console.WriteLine($"Matchpoängen just nu: {match2.ScoreString()}");
                    if (!match2.matchOver) Console.WriteLine($"Setpoängen just nu:   {match2._sets[match2.setIndex].ScoreString()}");
                    if (!match2.matchOver) Console.WriteLine($"Gamepoängen just nu:  {match2._sets[match2.setIndex]._games[match2._sets[match2.setIndex].gameIndex].ScoreString()}");

                }

                Console.WriteLine();
                Console.WriteLine("Slutresultat:");
                Console.WriteLine(match2.ResultString());
            
        }

    }
}
