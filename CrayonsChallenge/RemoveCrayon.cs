
namespace CrayonsChallenge
{
    public class RemoveCrayon : ChooseOption
    {
        public RemoveCrayon(ShowMenu WhatMenu, Child Child) : base(WhatMenu)
        {
            this.Child = Child;
        }
        Child Child { get; set; }
        List<string> crayons = new Crayons().color();
        public override void ActivateOption(ShowMenu WhatMenu, string ActiveChild)
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
                WhatMenu.ActivePosition = 0;
                WhatMenu.ShowMenuPositions();
                ShowActiveChild(ActiveChild);
                ControlInfo();
                do
                {
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
                        Child.RemoveCrayon(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
                        WhatMenu.PositionsMenuList.Remove(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
                        if (WhatMenu.PositionsMenuList.Count != 0 && WhatMenu.ActivePosition == WhatMenu.PositionsMenuList.Count)
                        {
                            WhatMenu.ActivePosition--;
                        }
                        WhatMenu.ShowMenuPositions();
                        ShowActiveChild(ActiveChild);
                        ControlInfo();
                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        Console.Write("_");
                        break;
                    }
                } while (true);
            }
            catch (Exception e) { }
        }
    }
}
