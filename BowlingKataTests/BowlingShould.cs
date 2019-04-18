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
            new Bowling()
                .CalculateScore(scoreBoard)
                .Should().Be(expectedScore);
        }

        [TestCase("18|--|--|--|--|--|--|--|--|--||--", 9)]
        [TestCase("25|--|--|--|--|--|--|--|--|--||--", 7)]
        [TestCase("22|--|--|--|--|--|--|--|--|--||--", 4)]
        public void ReturnExpectedScore_WhenCalculatingSingleFrame_GivenScoreBoardTwoThrows(string scoreBoard, int expectedScore)
        {
            new Bowling()
                .CalculateScore(scoreBoard)
                .Should().Be(expectedScore);
        }

        [TestCase("22|1-|--|--|--|--|--|--|--|--||--", 5)]
        [TestCase("22|13|--|--|--|--|--|--|--|--||--", 8)]
        [TestCase("22|-3|--|--|--|--|--|--|--|--||--", 7)]
        public void ReturnExpectedScore_WhenCalculatingTwoFrames_GivenScoreBoardTwoFrames(string scoreBoard,
            int expectedScore)
        {
            new Bowling()
                .CalculateScore(scoreBoard)
                .Should().Be(expectedScore);
        }

        [TestCase("X-|--|--|--|--|--|--|--|--|--||--", 10)]
        [TestCase("X-|1-|--|--|--|--|--|--|--|--||--", 12)]
        [TestCase("X-|15|--|--|--|--|--|--|--|--||--", 22)]
        [TestCase("X-|X-|11|--|--|--|--|--|--|--||--", 35)]
        [TestCase("X-|X-|11|X-|X-|22|--|--|--|--||--", 75)]
        [TestCase("X-|X-|X-|X-|X-|X-|X-|X-|X-|11||--", 245)]
        public void ReturnExpectedScore_WhenCalculatingScore_GivenSomeStrikes(string scoreBoard,
            int expectedResult)
        {
            new Bowling()
                .CalculateScore(scoreBoard)
                .Should().Be(expectedResult);
        }

        [TestCase("-/|--|--|--|--|--|--|--|--|--||--", 10)]      
        [TestCase("2/|--|--|--|--|--|--|--|--|--||--", 10)]      
        [TestCase("2/|1-|--|--|--|--|--|--|--|--||--", 12)]
        [TestCase("2/|-9|--|--|--|--|--|--|--|--||--", 19)]
        [TestCase("2/|-9|9/|9-|--|--|--|--|--|--||--", 47)]
        [TestCase("2/|-9|9/|9/|2-|--|--|--|--|--||--", 52)]
        public void ReturnExpectedScore_WhenCalculatingScore_GivenSomeSpares(string scoreBoard,
            int expectedResult)
        {
            new Bowling()
                .CalculateScore(scoreBoard)
                .Should().Be(expectedResult);
        }

        [TestCase("2/|-9|9/|X-|2-|--|--|--|--|--||--", 53)]
        [TestCase("2/|-9|9/|X-|2-|X-|1/|X-|9/|X-||--", 143)]
        [TestCase("2/|-9|9/|X-|2-|X-|1/|X-|9/|X-||23", 148)]
        [TestCase("X-|X-|X-|X-|X-|X-|X-|X-|X-|X-||--", 270)]
        [TestCase("X-|X-|X-|X-|X-|X-|X-|X-|X-|X-||X-", 290)]
        [TestCase("X-|X-|X-|X-|X-|X-|X-|X-|X-|X-||XX", 300)]
        public void ReturnExpectedScore_WhenCalculatingScore_GivenSomeSparesAndStrikes(string scoreBoard,
            int expectedResult)
        {
            new Bowling()
                .CalculateScore(scoreBoard)
                .Should().Be(expectedResult);
        }
    }
}
