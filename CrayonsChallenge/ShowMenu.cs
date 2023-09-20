using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrayonsChallenge
{
    internal class ShowMenu
    {
        public ShowMenu(string header)
        {
            this.Header = header;
        }
        public int ActivePosition { get; set; }
        public string Header { private get; set; }
        public void ShowMenuPositions(List<string> listOfMenu)
        {            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(this.Header);
            for (int i = 0; i < listOfMenu.Count; i++)
            {
                if (i == this.ActivePosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("{0,-35}", listOfMenu[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(listOfMenu[i]);
                }
            }            
        }

    }
}
