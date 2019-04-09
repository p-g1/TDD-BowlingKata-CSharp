using System.Linq;

namespace BowlingKata.Source
{
    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {

            if (char.IsDigit(scoreboard.First()))
            {
                return int.Parse(scoreboard.First().ToString());
            }

            return 0;
        }
    }
}
