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
                var firstThrow = frame.First().ParseThrowCharacters();
                var secondThrow = frame.Last().ParseThrowCharacters();

                score += (firstThrow + secondThrow);
            }

            return score;
        }

    }

    internal static class BowlingExtensions
    {
        private const char Miss = '-';
        private const char Strike = 'X';

        internal static int ParseThrowCharacters(this char toReplace)
        {
            if (toReplace == Miss)
            {
                return 0;
            }

            if (toReplace == Strike)
            {
                return 10;
            }

            return int.Parse(toReplace.ToString());
        }

    }

}