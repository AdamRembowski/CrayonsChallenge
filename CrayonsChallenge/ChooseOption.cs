using System.Reflection.Metadata.Ecma335;

namespace CrayonsChallenge
{
    public class ChooseOption
    {
        public ShowMenu WhatMenu { get; private set; }
        public ChooseOption(ShowMenu WhatMenu)
        {
            this.WhatMenu = WhatMenu;
        }
        public virtual void ActivateOption(ShowMenu WhatMenu, string ActiveChild)
        {
           
            do
            {
                WhatMenu.ShowMenuPositions();
                ShowActiveChild(ActiveChild);
                ControlInfo();
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow)
                {
                    WhatMenu.ActivePosition = (WhatMenu.ActivePosition > 0) ? WhatMenu.ActivePosition - 1 : WhatMenu.PositionsMenuList.Count - 1;
                    WhatMenu.ShowMenuPositions();
                    ShowActiveChild(ActiveChild);
                    ControlInfo();
                }
                else if (klawisz.Key == ConsoleKey.DownArrow)
                {

                    WhatMenu.ActivePosition = (WhatMenu.ActivePosition + 1) % WhatMenu.PositionsMenuList.Count;
                    WhatMenu.ShowMenuPositions();
                    ShowActiveChild(ActiveChild);
                    ControlInfo();
                }
                else if (klawisz.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    Console.Write("_");                  
                }
                else
                {
                    Console.Clear();
                    WhatMenu.ShowMenuPositions();
                    ShowActiveChild(ActiveChild);
                    ControlInfo();
                }
            } while (true);
        }
        public void ControlInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór");
        }
        public void ShowActiveChild(string ActiveChild)
        {
                Console.WriteLine();
                Console.WriteLine($"Wybrane Dziecko: {ActiveChild}");
                Console.WriteLine();            
        }
    }
}
