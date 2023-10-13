
namespace CrayonsChallenge
{
    public class RemoveCrayon : ChooseOption
    {
        public RemoveCrayon(ShowMenu WhatMenu, Child Child) : base(WhatMenu)
        {
            this.Child = Child;
        }
        Child Child { get; set; }
        public override int ActivateOption(ShowMenu WhatMenu, string ActiveChild)
        {
            try
            {
                WhatMenu.PositionsMenuList.Clear();
                if (Child.CollectionOfCrayons.Count != 0)
                {
                    foreach (string color in Child.CollectionOfCrayons)
                    {
                        WhatMenu.PositionsMenuList.Add(color);
                    }
                }
                BasicAction(ref WhatMenu,0, ActiveChild);
                do
                {
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
                        Child.RemoveCrayon(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
                        WhatMenu.PositionsMenuList.Remove(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
                        if (WhatMenu.PositionsMenuList.Count != 0 && WhatMenu.ActivePosition == WhatMenu.PositionsMenuList.Count)
                        {                            
                            WhatMenu.ChangeMenuActivePosition(WhatMenu.PositionsMenuList.Count-1);
                        }
                        BasicAction(ref WhatMenu, WhatMenu.ActivePosition, ActiveChild);
                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        Console.Write("_");
                        break;
                    }
                } while (true);
            }            
            catch (Exception e) { }
            return WhatMenu.ActivePosition;
        }
        public override void ControlInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
        }
    }
}
