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

            var toDouble = Double(framesPinCount);
            var toTreble = Treble(framesPinCount);
            
            var pinScore = framesPinCount.Where(frame => frame.Any()).Sum(frame => frame.Sum());
            return  pinScore + toDouble + toTreble;
        }

        public IEnumerable<IEnumerable<int>> ParseFramesToScore(IEnumerable<string> frames)
        {
            return frames.Select(frame => frame.Select(roll => roll.ParseThrowCharacters()));
        }

        public int Double(List<IEnumerable<int>> framesPinCount)
        {
            var previousFrameWasStrike = false;
            var result = new List<int>();

            foreach (var frame in framesPinCount)
            {
                if (!frame.Any()) continue;
                result.Add((previousFrameWasStrike ? frame.First() : 0) + (previousFrameWasStrike ? frame.Last() : 0 ));
                previousFrameWasStrike = frame.IsStrike();
            }
            return result.Sum();
        }


        public int Treble(List<IEnumerable<int>> framesPinCount)
        {
            var previousFrameWasStrike = false;
            var previousPlusOneFrameWasStrike = false;

            var result = new List<int>();

            foreach (var frame in framesPinCount)
            {
                if (!frame.Any()) continue;
                result.Add(previousFrameWasStrike && previousPlusOneFrameWasStrike ? frame.First() : 0);
                previousPlusOneFrameWasStrike = previousFrameWasStrike;
                previousFrameWasStrike = frame.IsStrike();
                
            }
            return result.Sum();
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

        internal static bool IsStrike(this IEnumerable<int> frame)
        {
            return frame.First() == 10;
        }

        internal static bool IsStrike(this string frame)
        {
            return frame.Any(role => role == Strike);
        }

    }

}