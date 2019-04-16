using BowlingKata.Source;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingKata.Tests
{
    public class BowlingShould
    {

        [TestCase("--|--|--|--|--|--|--|--|--|--||--", 0)]
        [TestCase("1-|--|--|--|--|--|--|--|--|--||--", 1)]
        [TestCase("2-|--|--|--|--|--|--|--|--|--||--", 2)]
        [TestCase("9-|--|--|--|--|--|--|--|--|--||--", 9)]
        [TestCase("-1|--|--|--|--|--|--|--|--|--||--", 1)]
        [TestCase("-9|--|--|--|--|--|--|--|--|--||--", 9)]
        public void ReturnExpectedScore_WhenCalculatingSingleFrame_GivenScoreBoardWithSingleThrow(string scoreBoard, int expectedScore)
        {
            var bowling = new Bowling();
            var result = bowling.CalculateScore(scoreBoard);
            result.Should().Be(expectedScore);
        }

        [TestCase("18|--|--|--|--|--|--|--|--|--||--", 9)]
        [TestCase("25|--|--|--|--|--|--|--|--|--||--", 7)]
        [TestCase("22|--|--|--|--|--|--|--|--|--||--", 4)]
        public void ReturnExpectedScore_WhenCalculatingSingleFrame_GivenScoreBoardTwoThrows(string scoreBoard, int expectedScore)
        {
            var bowling = new Bowling();
            var result = bowling.CalculateScore(scoreBoard);
            result.Should().Be(expectedScore);
        }

        [TestCase("22|1-|--|--|--|--|--|--|--|--||--", 5)]
        public void ReturnExpectedScore_WhenCalculatingTwoFrames_GivenScoreBoardThreeThrows(string scoreBoard,
            int expectedScore)
        {
            var bowling = new Bowling();
            var result = bowling.CalculateScore(scoreBoard);
            result.Should().Be(expectedScore);
        }
    }
}
