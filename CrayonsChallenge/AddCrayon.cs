namespace CrayonsChallenge
{
    public class AddCrayon : ChooseOption
    {
        public AddCrayon(ShowMenu whatMenu, Child child) : base(whatMenu, false)
        {
            this.Child = child;
        }
        Child Child { get; }
        List<string> crayons = new Crayons().Color;

        public override void ControlInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
        }
        public override void InitializationMetod(string activeChild)
        {
            WhatMenu.PositionsMenuList = crayons;
            foreach (string color in Child.CollectionOfCrayons)
            {
                WhatMenu.PositionsMenuList.Remove(color);
            }
            BasicAction(0, activeChild);
        }
        public override void EnterKeyAction(string activeChild)
        {
            Child.GiveCrayon(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
            WhatMenu.PositionsMenuList.Remove(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
            if (WhatMenu.PositionsMenuList.Count != 0 && WhatMenu.ActivePosition == 0)
            {
                WhatMenu.ChangeMenuActivePosition(0);
            }
            else if (WhatMenu.ActivePosition == WhatMenu.PositionsMenuList.Count)
            {
                WhatMenu.ChangeMenuActivePosition(WhatMenu.PositionsMenuList.Count - 1);
            }
            BasicAction(WhatMenu.ActivePosition, activeChild);
        }
    }
}
