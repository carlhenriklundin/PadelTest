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
            Player testPlayer1 = new Player("Test Player1");
            Player testPlayer2 = new Player("Test Player2");
            
            Assert.Equal("Test Player1", testPlayer1.Name);
            Assert.Equal("Test Player2", testPlayer2.Name);
        }

        [Fact]
        public void Test_InvalidNameInConstructor()
        {
            Action act1 = () => new Player(null);
            Action act2 = () => new Player("");
            Action act3 = () => new Player("This name has too many letters");

            Assert.Throws<Exception>(act1);
            Assert.Throws<Exception>(act2);
            Assert.Throws<Exception>(act3);
        }

        [Fact]
        public void Test_PointInConstructor()
        {
            Player player1 = new Player("Test Player 1");
            Player player2 = new Player("Test Player 2");
            
            int expected = 0;
            
            Assert.Equal(expected, player1.Score._Score);
            Assert.Equal(expected, player2.Score._Score);
        }

        [Fact]
        public void Test_Point()
        {
            Player player1 = new Player("Test Player 1");
            player1.Point();

            int expected = 1;

            Assert.Equal(expected, player1.Score._Score);
        }

        [Fact]
        public void Test_DecreasePointAndPoint()
        {
            Player player1 = new Player("Test Player 1");
            player1.Point();
            player1.Point();
            player1.DecreasePoint();

            int expected = 1;

            Assert.Equal(expected, player1.Score._Score);
        }

    } 

    public class ScoreTest
    {
        [Fact]
        public void Test_Constructor()
        {
            Score score1 = new Score();
            
            int expected = 0;

            Assert.Equal(expected, score1._Score);
        }

        [Fact]
        public void Test_Increase()
        {
            Score score1 = new Score();
            score1.Increase();

            int expected = 1;

            Assert.Equal(expected, score1._Score);
        }

        [Fact]
        public void Test_DecreaseAndIncrease()
        {
            Score score1 = new Score();
            score1.Increase();
            score1.Increase();
            score1.Decrease();

            int expected = 1;

            Assert.Equal(expected, score1._Score);
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
        public void Test100()
        {
            //Exempel på användning:
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player2); // 30 - 15
            (PadelScore, PadelScore) gameScore = game.Score();

            Assert.Equal((PadelScore.Thirty, PadelScore.Fifteen), gameScore);
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
            game2.Point(player2); // 40 - 15

            var result = game2.ScoreString();

           
            Action act = () => game2.Point(player1); // 15 - 0
            
            Assert.Equal("Player 2 wins", result);
            //Assert.Throws<ArgumentException>();

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
