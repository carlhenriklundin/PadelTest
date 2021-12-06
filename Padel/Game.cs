using System;

namespace Padel
{
    public enum PadelScore { Zero, Fifteen, Thirty, Forty, Advance, Game };

    public class Game
    {
        private Player _player1;
        private Player _player2;

        public Player Player1 => _player1;
        public Player Player2 => _player2;

        public bool gameOver = false;
        public bool tiebreak = false;
        private int minPointToWIn { get { if (tiebreak) return 7; else return 4; } }

       public Game(Player player1, Player player2)
        {
            if (player1.Name == player2.Name) throw new Exception(message: "Players 1 and 2 have same name");
            if (player1 == player2) throw new Exception(message: "Players 1 and 2 are the same player");
            _player1 = player1;
            _player2 = player2;
            _player1.Score = new Score();
            _player2.Score = new Score();
        }

        public void Point(Player player)
        {
            if (gameOver) throw new Exception(message: "The game is already over");
            if (player != _player1 && player != _player2) throw new Exception(message: "Unknown Player");
            
            player.Point();

            if (_player1.Score._Score == 4 && _player2.Score._Score == 4 && !tiebreak)
            {
                _player1.DecreasePoint();
                _player2.DecreasePoint();
            }

            ScoreString();
        }

        public (PadelScore, PadelScore) Score()
        {
            PadelScore player1Score = (PadelScore)_player1.Score._Score;
            PadelScore player2Score = (PadelScore)_player2.Score._Score;

            return (player1Score, player2Score);
        }

        

        public string ScoreString()
        {
            
            if (_player1.Score._Score >= minPointToWIn && _player1.Score._Score - _player2.Score._Score >= 2)
            {
                gameOver = true;
                if (!tiebreak) _player1.Score._Score = 5;
                return "Player 1 wins the game";
            }
            else if (_player2.Score._Score >= minPointToWIn && _player2.Score._Score - _player1.Score._Score >= 2)
            {
                gameOver = true;
                if (!tiebreak) _player2.Score._Score = 5;
                return "Player 2 wins the game"; 
            }
            else 
            { 
                return $"{Score().Item1.ToString()}-{Score().Item2.ToString()}"; 
            }

        }
    }
}
