using System;

namespace BowlingKata.Source
{
    using System.Linq;

    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            var firstThrow = scoreboard.First();
            var secondThrow = scoreboard.Skip(1).First();

            var thirdThrow = scoreboard.Skip(3).First();
            if (thirdThrow == '-')
            {
                thirdThrow = '0';
            }

            var frameOneScore = AddValues(firstThrow, secondThrow);

            return frameOneScore + int.Parse(thirdThrow.ToString());
        }

        private static int AddValues(char firstThrow, char secondThrow)
        {
            if (firstThrow == '-')
            {
                firstThrow = '0';
            }

            if (secondThrow == '-')
            {
                secondThrow = '0';
            }
            
            return int.Parse(firstThrow.ToString()) + int.Parse(secondThrow.ToString());
        }

    }
}
