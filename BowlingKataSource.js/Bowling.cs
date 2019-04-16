namespace BowlingKata.Source
{
    using System.Linq;

    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            var frames = scoreboard.Split('|');
            var firstFrame = frames[0];
            var secondFrame = frames[1];

            var firstThrow = firstFrame.First().ReplaceMissCharacter();
            var secondThrow = firstFrame.Last().ReplaceMissCharacter();
            var thirdThrow = secondFrame.First().ReplaceMissCharacter();
            var fourthThrow = secondFrame.Last().ReplaceMissCharacter();

            return (firstThrow + secondThrow + thirdThrow + fourthThrow);
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