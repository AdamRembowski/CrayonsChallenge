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
        public virtual void ActivateOption()
        {
            if (WhatMenu.PositionsMenuList.Count >= 1)
            {
                int activePosition = 0;
                do
                {
                    InitializationMetod();
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
                        Console.ForegroundColor = ConsoleColor.White;
                        EnterKeyAction();
                        if (noESC) break;
                        else
                        {
                            activePosition = WhatMenu.ActivePosition;
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
                    }
                } while ((WhatMenu.PositionsMenuList.Count > 0));
            }
        }
        public abstract void EnterKeyAction();

        public abstract void InitializationMetod();

    }
}
