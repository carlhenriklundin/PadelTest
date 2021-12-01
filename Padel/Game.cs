using System;

namespace Padel
{

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
            if (player != _player1 || player != _player2) throw new Exception(message: "Unknown Player");
            
            player.Point();

            if (_player1.Score._Score == 4 && _player1.Score._Score == 4)
            {
                _player1.DecreasePoint();
                _player2.DecreasePoint();
            }

            ScoreString();
        }

        public (PadelScore, PadelScore) Score()
        {
            return (_player1.Score._PadelScore, _player2.Score._PadelScore);
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
