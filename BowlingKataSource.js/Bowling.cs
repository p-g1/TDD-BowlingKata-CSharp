namespace BowlingKata.Source
{
    using System.Linq;
    using System.Collections.Generic;

    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            var frames = scoreboard.Split('|').ToList();

            var framesPinCount = ParseFramesToScore(frames).ToList();

            var framesRollToDouble = ParseFramesToDouble(frames);

            var pinScore = framesPinCount.Where(frame => frame.Any()).Sum(frame => frame.Sum());

            return pinScore + CalculateDouble(framesPinCount, framesRollToDouble);
        }

        public int CalculateDouble(IEnumerable<IEnumerable<int>> pinScores, IEnumerable<IEnumerable<bool>> doubleFlags)
        {
            var flatPinScores = pinScores.SelectMany(x => x);
            var flatDoubleFlags = doubleFlags.SelectMany(x => x);

            return flatDoubleFlags.Zip(flatPinScores, ApplyAdditionalScores).Sum();
        }

        private static int ApplyAdditionalScores(bool flag, int score) => flag ? score : 0;

        public IEnumerable<IEnumerable<int>> ParseFramesToScore(IEnumerable<string> frames)
        {
            return frames.Select(frame => frame.Select(roll => roll.ParseThrowCharacters()));
            
        }

        public IEnumerable<IEnumerable<bool>> ParseFramesToDouble(IEnumerable<string> frames)
        {
            var previousFrameWasStrike = false;

            var result = new List<IEnumerable<bool>>();

            foreach (var frame in frames)
            {
                result.Add(new List<bool> {previousFrameWasStrike, previousFrameWasStrike});
                previousFrameWasStrike = frame.IsStrike();
            }

            return result;
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

        internal static bool IsStrike(this string frame)
        {
            return frame.Any(roll => roll == Strike);
        }

    }

}