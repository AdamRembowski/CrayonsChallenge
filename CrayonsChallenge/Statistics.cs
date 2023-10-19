using CrayonsChallenge;

public class Statistics
{
    public Child Child {  get; private set; }
    public Statistics(Child child)
    {
       Child = child;
       CollectionOfCrayons = child.CollectionOfCrayons;
    }
    public List<string> CollectionOfCrayons { get; private set; }
    const int amountOfCryons = 16;
    public decimal Score
    {
        get
        {
            double division = (Child.CollectionOfCrayons.Count * 100) / amountOfCryons;
            decimal score = (decimal)Math.Round(division, 0);
            return score;
        }
    }
    public bool IsWinner
    {
        get
        {
            return Child.CollectionOfCrayons.Count == amountOfCryons;
        }
    }
}

