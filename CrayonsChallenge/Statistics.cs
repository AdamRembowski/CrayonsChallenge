using CrayonsChallenge;

public class Statistics
{
    public string Name {  get; private set; }
    public Statistics(Child child)
    {
       Name = child.Name;
       CollectionOfCrayonsCount = child.CollectionOfCrayons.Count;
    }
    public int CollectionOfCrayonsCount { get; private set; }
    int amountOfCryons = Crayons.Count;
    public decimal Score
    {
        get
        {
            double division = (CollectionOfCrayonsCount * 100) / amountOfCryons;
            decimal score = (decimal)Math.Round(division, 0);
            return score;
        }
    }
    public bool IsWinner
    {
        get
        {
            return CollectionOfCrayonsCount == amountOfCryons;
        }
    }
}

