using System;
namespace Padel
{
    public class Player
    {
        public string Name { set; get; }
        public Score Score { set; get; }

        public Player(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new Exception(message: "The player name does not meet the rules");
            Name = name;
            Score = new Score();
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
