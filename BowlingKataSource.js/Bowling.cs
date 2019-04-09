using System;

namespace BowlingKata.Source
{
    using System.Linq;

    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            if (char.IsDigit(scoreboard.Skip(1).First()) && char.IsDigit(scoreboard.First()))
            {
                return int.Parse(scoreboard.Skip(1).First().ToString()) + int.Parse(scoreboard.First().ToString());
            }

            if (char.IsDigit(scoreboard.First()))
            {
                return int.Parse(scoreboard.First().ToString());
            }
            if (char.IsDigit(scoreboard.Skip(1).First()))
            {
                return int.Parse(scoreboard.Skip(1).First().ToString());
            }

            return 0;
        }
    }
}
