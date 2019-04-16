namespace BowlingKata.Source
{
    using System.Linq;

    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            var firstThrow = scoreboard.First().ReplaceMissCharacter();
            var secondThrow = scoreboard.Skip(1).First().ReplaceMissCharacter();
            var thirdThrow = scoreboard.Skip(3).First().ReplaceMissCharacter();

            return (firstThrow + secondThrow + thirdThrow);
        }

    }

    internal static class BowlingExtensions
    {
        internal static int ReplaceMissCharacter(this char toReplace)
        {
            return toReplace == '-' 
                ? 0 
                : int.Parse(toReplace.ToString());
        }
    }

}