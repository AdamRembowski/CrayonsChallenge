namespace CrayonsChallenge
{
    public class Child
    {
        public string Name { get; private set; }
        public bool IsWinner { get; private set; }
        public List<string> CollectionOfCrayons { get; private set; }
        public const int AmountOfCryons = 16;
        public Child()
        {
        }
        public Child(string name)
        {
            this.Name = name;
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
        public void Podsumowanie()
        {
            //Console.Clear();
            Console.WriteLine($"Imię dziecka: {Name}");
            int counter = GetCount();
            Console.WriteLine($"Zebranych kredek: {counter}");
            foreach (var crayon in CollectionOfCrayons)
            {
                Console.WriteLine(crayon);
            }
            if (IsWinner)
            {
                Console.WriteLine($"Dziecko i imieniu:{Name} zapracowało na kolorowankę!");
            }
            else
            {
                double division = ((counter * 100) / 16);
                var score = (Math.Round(division, 0));
                Console.WriteLine($"{score} % zebranych kredek");
            }
        }
    }
}