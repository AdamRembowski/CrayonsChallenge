namespace CrayonsChallenge
{
    public class RemoveCrayon : ChooseOption
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
            BasicAction(0, Child.Name);
        }
        public override void EnterKeyAction()
        {
            Child.RemoveCrayon(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
            if (WhatMenu.PositionsMenuList.Count != 0 && WhatMenu.ActivePosition == WhatMenu.PositionsMenuList.Count)
            {
                WhatMenu.ChangeMenuActivePosition(WhatMenu.PositionsMenuList.Count - 1);
            }
            BasicAction(WhatMenu.ActivePosition, Child.Name);
        }

    }
}
