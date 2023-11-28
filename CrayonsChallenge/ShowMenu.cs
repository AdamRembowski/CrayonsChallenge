namespace CrayonsChallenge
{
    public class ShowMenu
    {
        public ShowMenu(string header)
        {
            this.Header = header;
            this.PositionsMenuList = new List<string>();
            this.ActivePosition = 0;
        }
        public int ActivePosition { get; private set; }
        private string Header { get; set; }
        public List<string> PositionsMenuList { get; set; }
        public void ShowMenuPositions()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
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
        public void ShowMenuPositions(int activePosition)        
        {
            int p = activePosition;
            if (PositionsMenuList.Count > 0)
            {
                Console.SetCursorPosition(0, activePosition + 1);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0,-35}", PositionsMenuList[activePosition]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = activePosition + 1; i <= PositionsMenuList.Count - 1; i++)
                {
                    Console.WriteLine(PositionsMenuList[i] + "          ");
                }
                Console.WriteLine("                          ");
            }
        }
        public void ChangeMenuActivePosition(int position)
        {
            this.ActivePosition = position;
        }
        public void ChangeMenuActivePosition(int lastPosition, int currentPosition, List<string> positionsMenuList)
        {
            Console.SetCursorPosition(0, lastPosition + 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0,-35}", positionsMenuList[lastPosition]);
            Console.SetCursorPosition(0, currentPosition + 1);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0,-35}", positionsMenuList[currentPosition]);
        }
        public void RemoveActivePosition(int position)
        {
            this.PositionsMenuList.Remove(this.PositionsMenuList[this.ActivePosition]);
            if (this.PositionsMenuList.Count >= 1 && this.ActivePosition == 0)
            {
                this.ChangeMenuActivePosition(0);
            }
            else if (this.ActivePosition == this.PositionsMenuList.Count)
            {
                this.ChangeMenuActivePosition(this.PositionsMenuList.Count - 1);
            }
        }

    }
}
