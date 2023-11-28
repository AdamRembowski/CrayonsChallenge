using System.ComponentModel;

namespace CrayonsChallenge
{
    public abstract class ChooseBase : IChooseBase
    {
        public ShowMenu WhatMenu { get; }
        private bool noESC = true;
        public ChooseBase(ShowMenu whatMenu)
        {
            this.WhatMenu = whatMenu;
        }
        public ChooseBase(ShowMenu whatMenu, bool noESC)
        {
            this.WhatMenu = whatMenu;
            this.noESC = noESC;
        }
        public virtual int ActivateOption(string activeChild)
        {
            if (WhatMenu.PositionsMenuList.Count >= 1)
            {
                int activePosition = 0;
                do
                {
                    InitializationMetod();
                    ShowActiveChild(activeChild);
                    ControlInfo();
                    ConsoleKeyInfo klawisz = Console.ReadKey();
                    if (klawisz.Key == ConsoleKey.UpArrow)
                    {
                        activePosition = (WhatMenu.ActivePosition > 0) ? WhatMenu.ActivePosition - 1 : WhatMenu.PositionsMenuList.Count - 1;
                        WhatMenu.ChangeMenuActivePosition(WhatMenu.ActivePosition, activePosition, WhatMenu.PositionsMenuList);
                        WhatMenu.ChangeMenuActivePosition(activePosition);
                    }
                    else if (klawisz.Key == ConsoleKey.DownArrow)
                    {
                        activePosition = (WhatMenu.ActivePosition + 1) % WhatMenu.PositionsMenuList.Count;
                        WhatMenu.ChangeMenuActivePosition(WhatMenu.ActivePosition, activePosition, WhatMenu.PositionsMenuList);
                        WhatMenu.ChangeMenuActivePosition(activePosition);
                    }
                    else if (klawisz.Key == ConsoleKey.Enter)
                    {
                        EnterKeyAction();
                        if (noESC) break;
                        else
                        {
                            //Console.Clear();
                            WhatMenu.ShowMenuPositions(activePosition);                            
                            continue;
                        } 
                            
                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        Console.Write("_");
                        if (!noESC) break;
                        else continue;
                    }
                    else
                    {
                        Console.Clear();
                    }
                } while ((WhatMenu.PositionsMenuList.Count > 0));
            }
            return WhatMenu.ActivePosition;
        }
        public abstract void EnterKeyAction();

        public abstract void InitializationMetod();

        public virtual void ControlInfo()
        {
            Console.WriteLine();
            if (noESC)
                Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór");
            else
                Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
        }
        public void ShowActiveChild(string activeChild)
        {
            Console.SetCursorPosition(0, 18);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Wybrane Dziecko: {activeChild}");
            Console.WriteLine();
        }
    }
}
