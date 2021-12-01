using System;
using Xunit;
using Padel;

namespace PadelTest
{
    public class PlayerTest
    {
       
        [Fact]
        public void Test_NameInConstructor()
        {
            Player testPlayer = new Player("Test Player");
            Score score = new Score();
            Assert.Equal("Test Player", testPlayer.Name);
        }

        [Fact]
        public void Test_InvalidNameInConstructor()
        {
            Player testPlayer = new Player(null);
          
            Assert.Equal("New Player", testPlayer.Name);
        }

        [Fact]
        public void Test_PointInConstructor()
        {
            Player testPlayer = new Player("Test Player");
            Score score = new Score();
            Assert.Equal(score, testPlayer.Score);
        }
    } 


    public class GameTests
    {
        [Fact]
        public void Test1()
        {
            //Exempel på användning:
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player2); // 30 - 15
            game.Point(player1); // 40 - 15
            game.Point(player1); // Player 1 vinner Gamet

            var result = game.ScoreString(); // Ska vara Player 1 wins Game
            Assert.Equal("Player 1 wins", result);

        }

        [Fact]
        public void Test2()
        {

            //Exempel på användning:
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game2 = new Game(player1, player2);
            game2.Point(player2); // 15 - 0
            game2.Point(player2); // 30 - 0
            game2.Point(player1); // 30 - 15
            game2.Point(player2); // 40 - 15
            game2.Point(player2); // Player 1 vinner Gamet

            var result = game2.ScoreString(); // Ska vara Player 1 wins Game
            //Player två kan inte vinns. 
            Assert.Equal("Player 2 wins", result);

        }

        [Fact]
        public void Test10()
        {

            //Exempel på användning:
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game2 = new Game(player1, player2);
            game2.Point(player2); // 15 - 0
            game2.Point(player2); // 30 - 0
            game2.Point(player1); // 30 - 15
            game2.Point(player2); // 40 - 15
            game2.Point(player2); // Player 1 vinner Gamet
            game2.Point(player1); // 15 - 0
            game2.Point(player1); // 30 - 0
            game2.Point(player1); // 30 - 15
            game2.Point(player1); // 40 - 15
            game2.Point(player1); // Player 1 vinner Gamet
            game2.Point(player1); // Player 1 vinner Gamet


            var result = game2.ScoreString(); // Ska vara Player 1 wins Game
            //Player två kan inte vinns. 
            Assert.Equal("Player 2 wins", result);

        }

        [Fact]
        public void Test3()
        {

            //Exempel på användning:
            Player player1 = new Player("Player 1");
            Player player2 = player1;

            var game2 = new Game(player2, player2);
            game2.Point(player2); // 15 - 0
            game2.Point(player2); // 30 - 0
            game2.Point(player2); // 30 - 15
            game2.Point(player2); // 40 - 15
            game2.Point(player2); // Player 1 vinner Gamet

            var result = game2.ScoreString(); // Ska vara Player 1 wins Game
            //Player två kan inte vinns. 
            Assert.Equal("Player 1 wins", result);
        }

        [Fact]
        public void Test4()
        {

            //Exempel på användning:
            Player player1 = new Player("Player 1");
            Player player2 = player1;

            var game2 = new Game(player2, player2);
            game2.Point(player2); // 15 - 0
            game2.Point(player2); // 30 - 0
            game2.Point(player2); // 30 - 15
            game2.Point(player2); // 40 - 15
            game2.Point(player2); // Player 1 vinner Gamet

            var result = game2.ScoreString(); // Ska vara Player 1 wins Game
            //Player två kan inte vinns. 
            Assert.Equal("Player 1 wins", result);
        }
    }
}
