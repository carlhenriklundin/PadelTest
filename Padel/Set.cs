using System;
using System.Collections.Generic;

namespace Padel
{
    public class Set
    {
        List<Game> _games = new List<Game>();

        public void Point(Player player)
        {
            _games[0].Point(player);
        }
    }
}
