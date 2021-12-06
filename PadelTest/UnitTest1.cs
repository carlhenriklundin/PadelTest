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

        [Fact]
        public void Test_DecreasePointToNegative()
        {
            var player = new Player("Player");
            Action act1 = () => player.DecreasePoint();

            Assert.Throws<Exception>(act1);
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

    public class GameTests
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
        public void Test_COnstructorSameName()
        {
            Player testPlayer1 = new Player("Test Player1");
            Player testPlayer2 = new Player("Test Player1");
            Action act = () => new Game(testPlayer1, testPlayer2);
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
        public void Test_Point_ScoreShouldNotDcreaseWhenScoreIs4_4AndItIsTiebreak()
        {
            Player player1 = new Player("Ferri");
            Player player2 = new Player("Carl-Henrik");
            var game = new Game(player1, player2);
            game.tiebreak = true;
            game.Point(player2);// 0-1
            game.Point(player2);// 0-2
            game.Point(player2);// 0-3
            game.Point(player1);// 1-3
            game.Point(player1);// 2-3
            game.Point(player1);// 3-3
            game.Point(player1);// 4-3
            game.Point(player2);// 4-4
            Assert.Equal(4, game.Player1.Score._Score);
            Assert.Equal(4, game.Player2.Score._Score);
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
            Assert.Equal("Player 2 wins the game", result);
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
            Assert.Equal("Player 1 wins the game", result);
        }

        [Fact]
        public void Test_Player1WinsInTiebreak()
        {
            Player player1 = new Player("Ferri");
            Player player2 = new Player("Carl-Henrik");
            var game = new Game(player1, player2);

            game.tiebreak = true;
            game.Point(player2);// 0-1
            game.Point(player2);// 0-2
            game.Point(player2);// 0-3
            game.Point(player1);// 1-3
            game.Point(player1);// 2-3
            game.Point(player1);// 3-3
            game.Point(player1);// 4-3
            game.Point(player1);// 5-3
            game.Point(player1);// 6-3
            game.Point(player1);// 7-3
            var result = game.ScoreString();
            Assert.Equal("Player 1 wins the game", result);
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
            Assert.Equal("Player 2 wins the game", result);
        }

        [Fact]
        public void Test_ScoreString_NewGame_Missing_OnePoint_ToWin()
        {
            Player Player1 = new Player("Fredric");
            Player Player2 = new Player("Carl-Henrik");
            Game Game2 = new Game(Player1, Player2);

            Game2.Point(Player1); // 15-0
            Game2.Point(Player1); // 30-0
            Game2.Point(Player1); // 40-0
            Game2.Point(Player2); // 40-15
            Game2.Point(Player2); // 40-30
            Game2.Point(Player2); // 40-40
            Game2.Point(Player2); // 40-A
            Game2.Point(Player1); // 40-40
            Game2.Point(Player2); // 40-A
            var result = Game2.ScoreString(); // Ingen vinnare, fördel till player2
            Assert.Equal("Forty-Advance", result);
        }

        [Fact]
        public void Test_ScoreString_Game_Not_Started()
        {
            Player Player1 = new Player("Fredric");
            Player Player2 = new Player("Ferri");
            Game Game2 = new Game(Player1, Player2);
            var result = Game2.ScoreString();
            Assert.Equal("Zero-Zero", result);
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

    public class MatchTest
    {
        [Fact]
        public void Test_ConstructorName()
        {
            Player player1 = new Player("Test Player 1");
            Player player2 = new Player("Test Player 2");

            var match = new Match(5, player1, player2);

            Assert.Equal("Test Player 1", match._player1.Name);
            Assert.Equal("Test Player 2", match._player2.Name);
        }

        [Fact]
        public void Test_ConstructorWithInvalidPlayer()
        {
            Player player2 = new Player("Test Player 2");

            Action act = () => new Match(5, new Player(null), player2);

            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_ConstructorWithSamePlayer()
        {
            Player player1 = new Player("Test Player 2");

            Action act = () => new Match(5, player1, player1);

            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_ConstructorSameName()
        {
            Player player1 = new Player("Test Player 1");
            Player player2 = new Player("Test Player 1");

            Action act = () => new Match(5, player1, player2);

            Assert.Throws<Exception>(act);
        }

        [Theory]
        [InlineData (5, 5)]
        [InlineData (3, 3)]
        public void Test_ConstructorCorrectNumberOfSet(int numberOfSet, int expected)
        {
            var match = new Match(numberOfSet, new Player("Player 1"), new Player("Player 2"));

            Assert.Equal(expected, match._sets.Count);
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        public void Test_ConstructorInvalidNumberOfSet(int set)
        {
            Action act = () => new Match(set, new Player("Test Player 1"), new Player("Test Player 2"));
            
            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_ConstructorMatchScoreIsEmpty()
        {
            var match = new Match(5, new Player("Player 1"), new Player("Player 2"));

            Assert.Equal(0, match.matchScore.player1._Score);
            Assert.Equal(0, match.matchScore.player2._Score);
        }

        [Theory]
        [InlineData (3, 2)]
        [InlineData (5, 3)]
        public void Test_ScoreStringPlayer1ShouldWin(int set, int player1Score)
        {
            var match = new Match(set, new Player("Player 1"), new Player("Player 2"));
            match.matchScore.player1._Score = player1Score;

            Assert.Equal("Player 1 wins the match", match.ScoreString());
        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(5, 3)]
        public void Test_ScoreStringPlayer2ShouldWin(int set, int player2Score)
        {
            var match = new Match(set, new Player("Player 1"), new Player("Player 2"));
            match.matchScore.player2._Score = player2Score;

            Assert.Equal("Player 2 wins the match", match.ScoreString());
            Assert.True(match.matchOver);
        }

        [Theory]
        [InlineData(3, 1, 1)]
        [InlineData(3, 0, 0)]
        [InlineData(5, 2, 2)]
        [InlineData(5, 0, 0)]
        public void Test_ScoreStringMatchNotOver(int set, int player1Score, int player2Score)
        {
            var match = new Match(set, new Player("Player 1"), new Player("Player 2"));
            match.matchScore.player1._Score = player1Score;
            match.matchScore.player2._Score = player2Score;
            match.ScoreString();

            Assert.False(match.matchOver);
        }

        [Theory]
        [InlineData(5, 0, 0)]
        [InlineData(5, 1, 1)]
        [InlineData(5, 2, 2)]
        public void Test_ScoreStringResultWhenMatchIsNotOver(int set, int player1Score, int player2Score)
        {
            var match = new Match(set, new Player("Player 1"), new Player("Player 2"));
            match.matchScore.player1._Score = player1Score;
            match.matchScore.player2._Score = player2Score;
            var result = match.ScoreString();

            Assert.Equal($"{player1Score}-{player2Score} (the match is in progress).", result);
        }


        [Fact]
        public void Test_PointMatchIsAlreadyOver()
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            var match = new Match(5, player1, player2);
            match.matchOver = true;

            Action act = () => match.Point(player1);

            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_PointUnknownPlayer()
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            var player3 = new Player("Player 3");
            var match = new Match(5, player1, player2);
            
            Action act = () => match.Point(player3);

            Assert.Throws<Exception>(act);
        }

        [Fact]
        public void Test_Point_Player1ShouldHaveOnePointInGame1()
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");
            
            var match = new Match(5, player1, player2);
            match.Point(player1);

            Assert.Equal(1, match._sets[0]._games[0].Player1.Score._Score);
        }

        [Fact]
        public void Test_Point_Player2ShouldHaveOnePointInGame1()
        {
            var player1 = new Player("Player 1");
            var player2 = new Player("Player 2");

            var match = new Match(5, player1, player2);
            match.Point(player2);

            Assert.Equal(1, match._sets[0]._games[0].Player2.Score._Score);
        }

        [Fact]
        public void Test_Point_Player1ShouldHaveOneMatchPointAndPlayer2Zero()
        {
            var player1 = new Player("Player 1");
            var match = new Match(5, player1, new Player("Player 2"));
            match._sets[0].setScore.player1._Score = 5;
            match._sets[0]._games[0].Player1.Score._Score = 3;
            match.Point(player1);

            Assert.Equal(1, match.matchScore.player1._Score);
            Assert.Equal(0, match.matchScore.player2._Score);
        }

        [Fact]
        public void Test_Point_Player2ShouldHaveOneMatchPointAndPlayer1Zero()
        {
            var player2 = new Player("Player 2");
            var match = new Match(5, new Player("Player 1"), player2);
            match._sets[0].setScore.player2._Score = 5;
            match._sets[0]._games[0].Player2.Score._Score = 3;
            match.Point(player2);

            Assert.Equal(1, match.matchScore.player2._Score);
            Assert.Equal(0, match.matchScore.player1._Score);
        }

        [Theory]
        [InlineData(6, 1, 6, 1, 6, 1, 6, 1, 6, 1)]
        [InlineData(1, 6, 2, 6, 2, 6, 1, 6, 1, 6)]
        [InlineData(0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public void Test_ResultString(int s1p1, int s1p2, int s2p1, int s2p2, int s3p1, int s3p2, int s4p1, int s4p2, int s5p1, int s5p2)
        {
            var match = new Match(5, new Player("Player 1"), new Player("Player 2"));
            match.setIndex = 5;
            match._sets[0].setScore.player1._Score = s1p1;
            match._sets[0].setScore.player2._Score = s1p2;
            match._sets[1].setScore.player1._Score = s2p1;
            match._sets[1].setScore.player2._Score = s2p2;
            match._sets[2].setScore.player1._Score = s3p1;
            match._sets[2].setScore.player2._Score = s3p2;
            match._sets[3].setScore.player1._Score = s4p1;
            match._sets[3].setScore.player2._Score = s4p2;
            match._sets[4].setScore.player1._Score = s5p1;
            match._sets[4].setScore.player2._Score = s5p2;
            match.ScoreString();

            string expected = $"Matchscore: {match.matchScore.player1._Score}-{match.matchScore.player1._Score} ( {s1p1}-{s1p2} {s2p1}-{s2p2} {s3p1}-{s3p2} {s4p1}-{s4p2} {s5p1}-{s5p2} )";
            Assert.Equal(expected, match.ResultString());
        }
    }
}
