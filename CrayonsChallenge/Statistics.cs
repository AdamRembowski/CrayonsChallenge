using CrayonsChallenge;

public class Statistics
{
    public string Name {  get; private set; }
    public Statistics(Child child)
    {
       Name = child.Name;
       CollectionOfCrayons = child.CollectionOfCrayons;
    }
    public List<string> CollectionOfCrayons { get; private set; }
    const int amountOfCryons = 16;
    public decimal Score
    {
        get
        {
            double division = (CollectionOfCrayons.Count * 100) / amountOfCryons;
            decimal score = (decimal)Math.Round(division, 0);
            return score;
        }
    }
    public bool IsWinner
    {
        get
        {
            return CollectionOfCrayons.Count == amountOfCryons;
        }
    }
}

