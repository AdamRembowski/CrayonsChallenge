namespace CrayonsChallenge
{
    public class ShowMenu
    {
        public ShowMenu(string header)
        {
            this.Header = header;
            this.PositionsMenuList = new List<string>();
        }
        public int ActivePosition { get; set; }
        string Header { get; set; }
        public List<string> PositionsMenuList { get; set; }
        public void ShowMenuPositions()
        {            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(this.Header);
            int position = 0;
            foreach (string item in PositionsMenuList)
            {
                if (position == ActivePosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("{0,-35}", PositionsMenuList[position]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(item);
                }
                position++;
            }
        }
    }
}
