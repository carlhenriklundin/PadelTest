using System;

namespace Padel
{
    public enum PadelScore { Zero, Fifteen, Thirty, Forty, Advantage, Game };

    public class Game
    {
        private Player _player1;
        private Player _player2;

        bool gameFinished = false;

       public Game(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void Point(Player player)
        {
            if (gameFinished) throw new Exception(message: "The game is already over");
            if (player != _player1 && player != _player2) throw new Exception(message: "Unknown Player");
            
            player.Point();

            if (_player1.Score._Score == 4 && _player2.Score._Score == 4)
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
            
            if (_player1.Score._Score >= 4 && _player1.Score._Score - _player2.Score._Score >= 2)
            {
                gameFinished = true;
                return "Player 1 wins";
            }
            else if (_player2.Score._Score >= 4 && _player2.Score._Score - _player1.Score._Score >= 2)
            {
                gameFinished = true;
                return "Player 2 wins"; 
            }
            else 
            { 
                return "Invalid result"; 
            }

        }
    }
}
