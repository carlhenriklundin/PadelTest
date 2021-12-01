using System;
namespace Padel
{
    public class Player
    {
        public string Name { set; get; }
        public Score Score { set; get; }

        public Player(string name)
        {
            Name = name;
            Score = new Score();
            if (name == null) Name = "New Player";
        }

        public void Point()
        {
            Score.Increase();
        }

        public void DecreasePoint()
        {
            Score.Decrease();
        }
    }
}
