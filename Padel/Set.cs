using System;
using System.Collections.Generic;

namespace Padel
{
    public class Set
    {
        public List<Game> _games = new List<Game>();
        public Player _player1;
        public Player _player2;
        public (Score player1, Score player2) setScore;
        public bool setOver = false;
        public int gameIndex = default;


        public Set(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            _games.Add(new Game(player1, player2));
            setScore = (new Score(), new Score());
        }

        public void Point(Player player)
        {
            if (setOver) throw new Exception(message: "The set is already over");
            if (player != _player1 && player != _player2) throw new Exception(message: "Unknown Player");

            _games[gameIndex].Point(player);

            if (_games[gameIndex].gameOver == true)
            {
                if (_games[gameIndex].Player1.Score._Score > _games[gameIndex].Player2.Score._Score)
                {
                    setScore.player1.Increase();
                }
                else
                {
                    setScore.player2.Increase();
                }

                
                _games.Add(new Game(_player1, _player2));

    
                gameIndex++;

                if (gameIndex == 12) _games[gameIndex].tiebreak = true;

                ScoreString();
            }
        }


        public string ScoreString()
        {
            if ((setScore.player1._Score >= 6 && setScore.player1._Score - setScore.player2._Score >= 2) || setScore.player1._Score == 7)
            {
                setOver = true;
                if (_games[gameIndex-1].tiebreak == true) return $"Player 1 wins the set after Tiebreak";
                return $"Player 1 wins the set";
            }
            else if ((setScore.player2._Score >= 6 && setScore.player2._Score - setScore.player1._Score >= 2) || setScore.player2._Score == 7)
            {
                setOver = true;
                if (_games[gameIndex-1].tiebreak == true) return $"Player 1 wins the set after Tiebreak";
                return $"Player 2 wins the set";
            }
            else
            {
                return "Invalid result";
            }
        }

    }
}

