using System;

namespace Padel
{
    
    public class Score
    {
        public int _Score { get; set; }

    public void Increase()
        {
            _Score++; 
        }

        public void Decrease()
        {
            _Score--;
        }
    }
}
