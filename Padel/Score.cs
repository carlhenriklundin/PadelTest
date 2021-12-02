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
            if (_Score == 0) throw new Exception(message: "Players Score can not be negative");
            _Score--;
        }
    }
}
