using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace BowlingKata.Source
{
    using System.Linq;

    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            var frames = scoreboard.Split('|').ToList();

            var framePinCount = ParseFrames(frames);

            var score = 0;

            foreach (var frame in framePinCount)
            {
                if (!frame.Any()) continue;

                var firstThrow = frame.First();
                var secondThrow = frame.Last();

                score += (firstThrow + secondThrow);
            }

            return score;
        }

        public IEnumerable<IEnumerable<int>> ParseFrames(IEnumerable<string> frames)
        {
            return frames.Select(frame => frame.Select(roll => roll.ParseThrowCharacters()));
            
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