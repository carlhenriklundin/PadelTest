using System;
using System.Collections.Generic;

namespace Padel
{
    public class Match
    {
        public List<Set> _sets;
        public Player _player1;
        public Player _player2;
        public (Score player1, Score player2) matchScore;
        public bool matchOver = false;
        public int setIndex = 0;
        
        public Match(int numberOfSets, Player player1, Player player2)
        {
            if (player1 == player2) throw new Exception(message: "Players 1 and 2 are the same player");
            if (numberOfSets != 5 && numberOfSets != 3) throw new Exception(message: "A match can only have 3 or 5 sets");
            
            _sets = new List<Set>(numberOfSets);
            
            for (int i = 0; i < numberOfSets; i++)
            {
                _sets.Add(new Set(player1,player2));
            }
            
            _player1 = player1;
            _player2 = player2;
            matchScore = (new Score(), new Score());
        }

        public void Point(Player player)
        {
            if (matchOver) throw new Exception(message: "The match is already over");
            if (player != _player1 && player != _player2) throw new Exception(message: "Unknown Player");

             _sets[setIndex].Point(player);
            
            if (_sets[setIndex].setOver == true)
            {
                if (_sets[setIndex].setScore.player1._Score > _sets[setIndex].setScore.player2._Score)
                {
                    matchScore.player1.Increase();
                }
                else
                {
                    matchScore.player2.Increase();
                }
                  
            setIndex++;
            ScoreString();
            }
        }

        public string ScoreString()
        {
            if (matchScore.player1._Score > _sets.Count/2)
            {
                matchOver = true;
                return $"Player 1 wins the match";
            }
            else if (matchScore.player2._Score > _sets.Count / 2)
            {
                matchOver = true;
                return $"Player 2 wins the match";
            }
            else
            {
                return "Invalid result";
            }
        }

    }
}
