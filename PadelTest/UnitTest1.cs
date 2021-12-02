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
            Action act3 = () => new Player(" ");

            Assert.Throws<Exception>(act1);
            Assert.Throws<Exception>(act2);
            Assert.Throws<Exception>(act3);
        }

        [Fact]
        public void Test_ConstructorNameToManyLetters()
        {
            Action act1 = () => new Player("123456789123456789123"); //21 letters
            
            Assert.Throws<Exception>(act1);
        }

        [Fact]
        public void Test_ConstructorNameMaximumNumberOfLetters()
        {
            Player player1 = new Player("12345678912345678912"); //20 letters

            Assert.Equal("12345678912345678912", player1.Name);
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

        [Fact]
        public void Test_DecreaseToNegative()
        {
            Score score1 = new Score();

            Action act = () => score1.Decrease();

            Assert.Throws<Exception>(act);
        }

    }

    public class GameTests2
    {
        [Fact]
        public void Test_Constructor()
        {
            Player player1 = new Player("Test Player 1");
            Player player2 = new Player("Test Player 2");

            Game testGame = new Game(player1,player2);

            
            Assert.Equal("Test Player 1", testGame.Player1.Name);
            Assert.Equal("Test Player 2", testGame.Player2.Name);
            Assert.Equal(0, testGame.Player1.Score._Score);
            Assert.Equal(0, testGame.Player2.Score._Score);
        }

        [Fact]
        public void Test_ConstructorWithInvalidPlayer()
        {
            Player player2 = new Player("Test Player 2");

            Action act = () => new Game(new Player(null), player2);

            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_ConstructorWithSamePlayer()
        {
            Player player1 = new Player("Test Player 1");

            Action act = () => new Game(player1, player1);

            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_Point_Game_Over()
        {
            Player player1 = new Player("Fredric");
            Player player2 = new Player("Carl-Henrik");


            Game Game1 = new Game(player1, player2);
            Game1.Point(player2);
            Game1.Point(player2);
            Game1.Point(player1);
            Game1.Point(player1);
            Game1.Point(player2);
            Game1.Point(player2);
            Action act = () => Game1.Point(player1);
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_PointUnknownPlayer()
        {
            Player player1 = new Player("Test Player 1");
            Player player2 = new Player("Test Player 2");
            Player player3 = new Player("Test Player 3");


            Game Game1 = new Game(player1, player2);
            Action act = () => Game1.Point(player3);
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_PointDecreaseWhenScoreIs4_4()
        {
            Player player1 = new Player("Test Player 1");
            Player player2 = new Player("Test Player 2");

            var game = new Game(player1, player2);

            game.Point(player2);
            game.Point(player2);
            game.Point(player2);
            game.Point(player1);
            game.Point(player1);
            game.Point(player1);
            game.Point(player1);
            game.Point(player2);

            Assert.Equal(3, player1.Score._Score);
            Assert.Equal(3, player2.Score._Score);
        }


        [Fact]
        public void Test_ScoreString_NewGame_Player2Wins()
        {
            Player Player1 = new Player("Fredric");
            Player Player2 = new Player("Carl-Henrik");
            Game Game2 = new Game(Player1, Player2);

            Game2.Point(Player2); // 0-15
            Game2.Point(Player2); // 0-30
            Game2.Point(Player2); // 0-40
            Game2.Point(Player1); // 15-40
            Game2.Point(Player1); // 30-40
            Game2.Point(Player1); // 40-40
            Game2.Point(Player2); // 40-A
            Game2.Point(Player2); // players2 vinner gamet
            var result = Game2.ScoreString(); // ska bli player2
            Assert.Equal("Player 2 wins", result);
        }


        [Fact]
        public void Test_ScoreString_NewGame_Player1Wins()
        {
            Player Player1 = new Player("Fredric");
            Player Player2 = new Player("Carl-Henrik");
            Game Game1 = new Game(Player1, Player2);

            Game1.Point(Player2); // 0-15
            Game1.Point(Player1); // 15-15
            Game1.Point(Player1); // 30-15
            Game1.Point(Player1); // 40-15
            Game1.Point(Player1); // players1 vinner gamet
            var result = Game1.ScoreString(); // ska bli player1
            Assert.Equal("Player 1 wins", result);
        }

        [Fact]
        public void Test_ScoreString_NewGame_Morethan_four_point()
        {
            Player Player1 = new Player("Fredric");
            Player Player2 = new Player("Carl-Henrik");
            Game Game2 = new Game(Player1, Player2);

            Game2.Point(Player1); // 0-15
            Game2.Point(Player1); // 0-30
            Game2.Point(Player1); // 0-40
            Game2.Point(Player2); // 15-40
            Game2.Point(Player2); // 30-40
            Game2.Point(Player2); // 40-40
            Game2.Point(Player2); // A-40
            Game2.Point(Player1); // 40-40
            Game2.Point(Player2); // A-40
            Game2.Point(Player2); // player2 vinner gamet
            var result = Game2.ScoreString(); // ska bli player2
            Assert.Equal("Player 2 wins", result);
        }

        [Fact]
        public void Test_ScoreString_NewGame_Missing_OnePoint_ToWin()
        {
            Player Player1 = new Player("Fredric");
            Player Player2 = new Player("Carl-Henrik");
            Game Game2 = new Game(Player1, Player2);

            Game2.Point(Player1); // 0-15
            Game2.Point(Player1); // 0-30
            Game2.Point(Player1); // 0-40
            Game2.Point(Player2); // 15-40
            Game2.Point(Player2); // 30-40
            Game2.Point(Player2); // 40-40
            Game2.Point(Player2); // A-40
            Game2.Point(Player1); // 40-40
            Game2.Point(Player2); // A-40
            var result = Game2.ScoreString(); // Ingen vinnare, fördel till player2
            Assert.Equal("Invalid result", result);
        }

        [Fact]
        public void Test_ScoreString_Game_Not_Started()
        {
            Player Player1 = new Player("Fredric");
            Player Player2 = new Player("Ferri");
            Game Game2 = new Game(Player1, Player2);
            var result = Game2.ScoreString();
            Assert.Equal("Invalid result", result);
        }


        [Fact]
        public void Test_PadelScore1()
        {
            Player player1 = new Player("Ferri");
            Player player2 = new Player("Carl-Henrik");
            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player2); // 30 - 15
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Thirty, PadelScore.Fifteen), gamescore);
        }
        [Fact]
        public void Test_PadelScore2()
        {
            Player player1 = new Player("Fredric");
            Player player2 = new Player("Carl-Henrik");
            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player2); // 30 - 15
            game.Point(player2); // 30-30
            game.Point(player2);// 30-40
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Thirty, PadelScore.Forty), gamescore);
        }
        [Fact]
        public void Test_PadelScore3()
        {
            Player player1 = new Player("Fredric");
            Player player2 = new Player("Ferri");
            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player2); // 30 - 15
            game.Point(player2); // 30-30
            game.Point(player2);// 30-40
            game.Point(player1); // 40-40
            game.Point(player2); // 40-A
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Forty, PadelScore.Advance), gamescore);
        }
        [Fact]
        public void Test_PadelScore4()
        {
            Player player1 = new Player("Fredric");
            Player player2 = new Player("Ferri");
            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player1); // 40-0
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Forty, PadelScore.Zero), gamescore);
        }

        [Fact]
        public void Test_PadelScore5()
        {
            Player player1 = new Player("Fredric");
            Player player2 = new Player("Ferri");
            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player1); // 40-0
            game.Point(player2); //40-15
            game.Point(player2);// 40-30
            game.Point(player2);// 40-40
            game.Point(player1); // A-40
            game.Point(player1); // vinner game
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Game, PadelScore.Forty), gamescore);
        }
        [Fact]
        public void Test_PadelScore6()
        {
            Player player1 = new Player("Fredric");
            Player player2 = new Player("Ferri");
            var game = new Game(player1, player2);
            game.Point(player1); // 15 - 0
            game.Point(player1); // 30 - 0
            game.Point(player1); // 40-0
            game.Point(player1); // Game
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Game, PadelScore.Zero), gamescore);
        }

        [Fact]
        public void Test_PadelScore7()
        {
            Player player1 = new Player("Ferri");
            Player player2 = new Player("Carl-Henrik");
            var game = new Game(player1, player2);
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Zero, PadelScore.Zero), gamescore);
        }


        [Fact]
        public void Test_PadelScore8()
        {
            Player player1 = new Player("Ferri");
            Player player2 = new Player("Carl-Henrik");
            var game = new Game(player1, player2);
            game.Point(player2);//0-15
            game.Point(player2);// 0-30
            game.Point(player2);// 0-40
            game.Point(player2);// Game player2
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Zero, PadelScore.Game), gamescore);
        }
        [Fact]
        public void Test_PadelScore9()
        {
            Player player1 = new Player("Ferri");
            Player player2 = new Player("Carl-Henrik");
            var game = new Game(player1, player2);
            game.Point(player2);//0-15
            game.Point(player2);// 0-30
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Zero, PadelScore.Thirty), gamescore);
        }

        [Fact]
        public void Test_PadelScore10_Should_Be_Forty_Forty_NotAdvance_Advance()
        {
            Player player1 = new Player("Ferri");
            Player player2 = new Player("Carl-Henrik");
            var game = new Game(player1, player2);
            game.Point(player2);//0-15
            game.Point(player2);// 0-30
            game.Point(player2);// 0-40
            game.Point(player1);// 15-40
            game.Point(player1);// 30-40
            game.Point(player1);// 40-40
            game.Point(player1);// A-40
            game.Point(player2);// A-A
            (PadelScore, PadelScore) gamescore = game.Score();
            Assert.Equal((PadelScore.Forty, PadelScore.Forty), gamescore);

        }


    }
}
