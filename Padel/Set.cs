using System;
using System.Collections.Generic;

namespace Padel
{
    public class Set
    {
        List<Game> _games = new List<Game>();
        public Player _player1;
        public Player _player2;
        public (Score player1, Score player2) setScore;
        public bool setOver = false;
        

        public Set(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void Point(Player player)
        {
            _games[0].Point(player);   
        }



    }
}
