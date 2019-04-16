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

            return AddValues(firstThrow, secondThrow, thirdThrow);
        }

        private static int AddValues(char firstThrow, char secondThrow, char thirdThrow)
        {
            if (firstThrow == '-')
            {
                firstThrow = '0';
            }

            if (secondThrow == '-')
            {
                secondThrow = '0';
            }

            if (thirdThrow == '-')
            {
                thirdThrow = '0';
            }

            return int.Parse(firstThrow.ToString()) 
                   + int.Parse(secondThrow.ToString()) 
                   + int.Parse(thirdThrow.ToString());
        }

    }
}
