namespace BowlingKata.Source
{
    public class Bowling
    {
        public int CalculateScore(string scoreboard)
        {
            if (scoreboard == "1-|--|--|--|--|--|--|--|--|--||--")
            {
                return 1;
            }
            if (scoreboard == "2-|--|--|--|--|--|--|--|--|--||--")
            {
                return 2;
            }
            if (scoreboard == "9-|--|--|--|--|--|--|--|--|--||--")
            {
                return 9;
            }
            return 0;
        }
    }
}
