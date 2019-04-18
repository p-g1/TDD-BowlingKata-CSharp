namespace BowlingKata.Source
{
    using System.Linq;
    using System.Collections.Generic;
    using System;

    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            var splitScoreBoard = scoreboard.Split(new []{"||"},StringSplitOptions.None);
            var finalFrame = splitScoreBoard[1];
            
            var frames = splitScoreBoard[0].Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var framesPinCount = ParseFramesToScore(frames).ToList();

            var toDouble = Double(framesPinCount);
            var toTreble = Treble(framesPinCount);

            var pinScore = framesPinCount.Where(frame => frame.Any()).Sum(frame => frame.Sum());
            return pinScore + toDouble + toTreble + finalFrame.ParseThrowCharacters().Sum();
        }

        public IEnumerable<IEnumerable<int>> ParseFramesToScore(IEnumerable<string> frames)
        {
            return frames.Select(frame => frame.ParseThrowCharacters());
        }

        public int Double(List<IEnumerable<int>> framesPinCount)
        {
            var previousFrameWasStrike = false;
            var previousFrameWasSpare = false;

            var result = new List<int>();

            foreach (var frame in framesPinCount)
            {
                if (!frame.Any()) continue;

                result.Add(((previousFrameWasStrike || previousFrameWasSpare )? frame.First() : 0) + (previousFrameWasStrike ? frame.Last() : 0));

                previousFrameWasStrike = frame.IsStrike();
                previousFrameWasSpare = frame.IsSpare();
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
        private const char Spare = '/';

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

        internal static IEnumerable<int> ParseThrowCharacters(this string toReplace)
        {
            var firstRoll = toReplace.First().ParseThrowCharacters();

            var secondRoll = toReplace.Last() == Spare
                ? 10 - firstRoll
                : toReplace.Last().ParseThrowCharacters();

            return new List<int> {firstRoll, secondRoll};
        }

        internal static bool IsStrike(this IEnumerable<int> frame)
        {
            return frame.First() == 10;
        }

        internal static bool IsSpare(this IEnumerable<int> frame)
        {
            return frame.First() != 10 && frame.Sum()==10;
        }

    }

}