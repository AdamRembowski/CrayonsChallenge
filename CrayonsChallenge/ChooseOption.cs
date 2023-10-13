using System.Reflection.Metadata.Ecma335;

namespace CrayonsChallenge
{
    public class ChooseOption
    {
        public ShowMenu WhatMenu { get; }
        public ChooseOption(ShowMenu WhatMenu)
        {
            this.WhatMenu = WhatMenu;
        }
        public virtual int ActivateOption(ShowMenu WhatMenu, string ActiveChild)
        {
            if (WhatMenu.PositionsMenuList != null)
            {
                do
                {
                    BasicAction(ref WhatMenu, WhatMenu.ActivePosition, ActiveChild);
                    ConsoleKeyInfo klawisz = Console.ReadKey();
                    if (klawisz.Key == ConsoleKey.UpArrow)
                    {
                        int ActivePosition = (WhatMenu.ActivePosition > 0) ? WhatMenu.ActivePosition - 1 : WhatMenu.PositionsMenuList.Count - 1;
                        BasicAction(ref WhatMenu, ActivePosition, ActiveChild);
                    }
                    else if (klawisz.Key == ConsoleKey.DownArrow)
                    {
                        int ActivePosition = (WhatMenu.ActivePosition + 1) % WhatMenu.PositionsMenuList.Count;
                        BasicAction(ref WhatMenu, ActivePosition, ActiveChild);
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
                        BasicAction(ref WhatMenu, WhatMenu.ActivePosition, ActiveChild);
                    }
                } while (true);
            }
            return WhatMenu.ActivePosition;
        }
        public void BasicAction(ref ShowMenu WhatMenu, int ActivePosition, string ActiveChild)
        {
            WhatMenu.ChangeMenuActivePosition(ActivePosition);
            WhatMenu.ShowMenuPositions();
            ShowActiveChild(ActiveChild);
            ControlInfo();
        }
        public virtual void ControlInfo()
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
