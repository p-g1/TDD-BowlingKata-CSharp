namespace BowlingKata.Source
{
    using System.Linq;

    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            var frames = scoreboard.Split('|');

            var score = 0;

            foreach (var frame in frames)
            {
                if (string.IsNullOrEmpty(frame))
                {
                    continue;
                }
                var firstThrow = frame.First().ReplaceMissCharacter();
                var secondThrow = frame.Last().ReplaceMissCharacter();

                score += (firstThrow + secondThrow);
            }

            return score;
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