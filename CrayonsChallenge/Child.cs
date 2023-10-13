namespace CrayonsChallenge
{
    public class Child
    {
        public string Name { get; }
        public bool IsWinner
        {
            get
            {
                return CollectionOfCrayons.Count == AmountOfCryons;
            }
        }
        public List<string> CollectionOfCrayons { get; private set; }
        public const int AmountOfCryons = 16;
        public Child()
        {
        }
        public Child(string name)
        {
            this.Name = name;
            this.CollectionOfCrayons = new List<string>();
        }
        public void GiveCrayon(string CrayonsColor)
        {
            this.CollectionOfCrayons.Add(CrayonsColor);
        }
        public void RemoveCrayon(string CrayonsColor)
        {
            this.CollectionOfCrayons.Remove(CrayonsColor);
        }
        public void Statistics()
        {
            Console.WriteLine($"Imię dziecka: {Name}");
            Console.WriteLine($"Zebranych kredek: {CollectionOfCrayons.Count}");
            foreach (var crayon in CollectionOfCrayons)
            {
                Console.WriteLine(crayon);
            }
            if (IsWinner)
            {
                Console.WriteLine($"Dziecko o imieniu: {Name} zapracowało na kolorowankę!");
            }
            else
            {
                double division = ((CollectionOfCrayons.Count * 100) / AmountOfCryons);
                var score = (Math.Round(division, 0));
                Console.WriteLine($"{score} % zebranych kredek");
            }
        }
    }
}