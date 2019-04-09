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
        public void ReturnExpectedScore_WhenCalculating_GivenScoreBoard(string scoreBoard, int expectedScore)
        {
            var bowling = new Bowling();
            var result = bowling.CalculateScore(scoreBoard);
            result.Should().Be(expectedScore);
        }

    }
}
