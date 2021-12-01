using System;

namespace Padel
{
    public enum PadelScore { Zero, Fifteen, Thirty, Forty, Advantage, Game};
    public class Score
    {
        public PadelScore _PadelScore;
        public int _Score;

    public void Increase()
        {
            _Score++;
            _PadelScore = (PadelScore) _Score; 
        }

        public void Decrease()
        {
            _Score--;
            _PadelScore = (PadelScore)_Score;
        }
    }
}
