namespace CrayonsChallenge
{
    public class Child
    {
        public string Name { get; private set; }
        public int Counter { get; private set; }
        public bool IsWinner { get; private set; }
        public List<string> CollectionOfCrayons { get; private set; }
        public const int AmountOfCryons = 16;
        public Child()
        {
        }
        public Child(string name)
        {
            this.Name = name;
            this.Counter = 0;
            this.IsWinner = false;
            this.CollectionOfCrayons = new List<string>();
        }
        public int GetCount()
        {
            if (CollectionOfCrayons.Count() == AmountOfCryons)
            {
                this.IsWinner = true;
            }
            return CollectionOfCrayons.Count();
        }
        public void GiveCrayon(string CrayonsColor)
        {
            this.CollectionOfCrayons.Add(CrayonsColor);
        }
        public void RemoveCrayon(string CrayonsColor)
        {
            this.CollectionOfCrayons.Remove(CrayonsColor);
        }
    }
}