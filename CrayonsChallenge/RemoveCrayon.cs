namespace CrayonsChallenge
{
    public class RemoveCrayon : ChooseBase
    {
        public RemoveCrayon(ShowMenu whatMenu, Child child) : base(whatMenu,false)
        {
            this.Child = child;
        }
        Child Child { get; set; }
        public override void InitializationMetod()
        {                       
            if (Child.CollectionOfCrayons.Count != 0)
            {
                WhatMenu.PositionsMenuList = Child.CollectionOfCrayons;
            }
        }
        public override void EnterKeyAction()
        {
            Child.RemoveCrayon(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
            if (WhatMenu.PositionsMenuList.Count >= 1 && WhatMenu.ActivePosition == WhatMenu.PositionsMenuList.Count)
            {
                WhatMenu.ChangeMenuActivePosition(WhatMenu.PositionsMenuList.Count - 1);
            }
        }

    }
}
