namespace CrayonsChallenge
{
    public class AddCrayon : ChooseBase
    {
        public AddCrayon(ShowMenu whatMenu, Child child) : base(whatMenu, false)
        {
            this.Child = child;
        }
        Child Child { get; }
        List<string> crayons = new Crayons().Colors;
        public override void InitializationMetod()
        {
            WhatMenu.PositionsMenuList = crayons;
            foreach (string color in Child.CollectionOfCrayons)
            {
                WhatMenu.PositionsMenuList.Remove(color);
            }
        }
        public override void EnterKeyAction()
        {
            if (WhatMenu.ActivePosition >= 0)
            {
                Child.GiveCrayon(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
                WhatMenu.PositionsMenuList.Remove(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
                if (WhatMenu.PositionsMenuList.Count >= 1 && WhatMenu.ActivePosition == 0)
                {
                    WhatMenu.ChangeMenuActivePosition(0);
                }
                else if (WhatMenu.ActivePosition == WhatMenu.PositionsMenuList.Count)
                {
                    WhatMenu.ChangeMenuActivePosition(WhatMenu.PositionsMenuList.Count - 1);
                }
            }

        }
    }
}
