using System.ComponentModel;

namespace CrayonsChallenge
{
    public class ChooseOption
    {
        public ShowMenu WhatMenu { get; }
        private bool staticMenu;
        public ChooseOption(ShowMenu whatMenu)
        {
            this.WhatMenu = whatMenu;
            staticMenu = true;
        }
        public ChooseOption(ShowMenu whatMenu, bool staticMenu)
        {
            this.WhatMenu = whatMenu;
            this.staticMenu = staticMenu;
        }
        public virtual int ActivateOption(string activeChild)
        {
            if (WhatMenu.PositionsMenuList != null)
            {
                InitializationMetod();
                do
                {
                    BasicAction(WhatMenu.ActivePosition, activeChild);
                    ConsoleKeyInfo klawisz = Console.ReadKey();
                    if (klawisz.Key == ConsoleKey.UpArrow)
                    {
                        int activePosition = (WhatMenu.ActivePosition > 0) ? WhatMenu.ActivePosition - 1 : WhatMenu.PositionsMenuList.Count - 1;
                        BasicAction(activePosition, activeChild);
                    }
                    else if (klawisz.Key == ConsoleKey.DownArrow)
                    {
                        int activePosition = (WhatMenu.ActivePosition + 1) % WhatMenu.PositionsMenuList.Count;
                        BasicAction(activePosition, activeChild);
                    }
                    else if (klawisz.Key == ConsoleKey.Enter)
                    {
                        EnterKeyAction();
                        if (staticMenu)
                        {
                            Console.WriteLine();
                            break;
                        }
                        else
                            continue;
                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        Console.Write("_");
                        if (!staticMenu)                 
                            break;                        
                        else
                            continue;
                    }
                    else
                    {
                        Console.Clear();
                        BasicAction(WhatMenu.ActivePosition, activeChild);
                    }
                } while (true);
            }
            return WhatMenu.ActivePosition;
        }

        public virtual void EnterKeyAction()
        {
        }
        public virtual void InitializationMetod()
        {
        }
        public void BasicAction(int activePosition, string activeChild)
        {
            WhatMenu.ChangeMenuActivePosition(activePosition);
            WhatMenu.ShowMenuPositions();
            ShowActiveChild(activeChild);
            ControlInfo();
        }
        public virtual void ControlInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór");
        }
        public void ShowActiveChild(string activeChild)
        {
            Console.WriteLine();
            Console.WriteLine($"Wybrane Dziecko: {activeChild}");
            Console.WriteLine();
        }

    }
}
