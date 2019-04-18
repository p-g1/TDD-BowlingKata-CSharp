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
            var framesRollToDouble = ParseRollsToDouble(frames);
            var framesRollToTreble = ParseRollsToTreble(frames);
            var pinScore = framesPinCount.Where(frame => frame.Any()).Sum(frame => frame.Sum());
            return pinScore + CalculateDouble(framesPinCount, framesRollToDouble) + CalculateTreble(framesPinCount, framesRollToTreble);
        }

        public int CalculateDouble(IEnumerable<IEnumerable<int>> pinScores, IEnumerable<IEnumerable<bool>> doubleFlags)
        {
            var flatPinScores = pinScores.SelectMany(x => x);
            var flatDoubleFlags = doubleFlags.SelectMany(x => x);

            return flatDoubleFlags.Zip(flatPinScores, ApplyAdditionalScores).Sum();
        }

        public int CalculateTreble(IEnumerable<IEnumerable<int>> pinScores, IEnumerable<IEnumerable<bool>> trebleFlags)
        {
            var flatPinScores = pinScores.SelectMany(x => x);
            var flatTrebleFlags = trebleFlags.SelectMany(x => x);

            return flatTrebleFlags.Zip(flatPinScores, ApplyAdditionalScores).Sum();
        }

        private static int ApplyAdditionalScores(bool flag, int score) => flag ? score : 0;

        public IEnumerable<IEnumerable<int>> ParseFramesToScore(IEnumerable<string> frames)
        {
            return frames.Select(frame => frame.Select(roll => roll.ParseThrowCharacters()));
            
        }

        public IEnumerable<IEnumerable<bool>> ParseRollsToDouble(IEnumerable<string> frames)
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

        public IEnumerable<IEnumerable<bool>> ParseRollsToTreble(IEnumerable<string> frames)
        {
            

            var previousFrameWasStrike = false;
            var previousPlusOneFrameWasStrike = false;

            var result = new List<IEnumerable<bool>>();

            foreach (var frame in frames)
            {

                result.Add(new List<bool> { previousFrameWasStrike && previousPlusOneFrameWasStrike, false });
                previousPlusOneFrameWasStrike = previousFrameWasStrike;
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