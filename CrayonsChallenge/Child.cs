namespace CrayonsChallenge
{
    public class Child
    {
        public string Name { get; private set; }
        public List<string> CollectionOfCrayons { get; private set; }
        public Child()
        {
        }
        public Child(string name)
        {
            this.Name = name;
            this.CollectionOfCrayons = new List<string>();
        }
        public void GiveCrayon(string crayonsColor)
        {
            if (!CollectionOfCrayons.Contains(crayonsColor))
            {
                this.CollectionOfCrayons.Add(crayonsColor);
            }

        }
        public void RemoveCrayon(string crayonsColor)
        {
            if (CollectionOfCrayons.Contains(crayonsColor))
            {
                this.CollectionOfCrayons.Remove(crayonsColor);
            }
        }
    }

}