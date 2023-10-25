
namespace CrayonsChallenge
{
    public class RemoveCrayon : ChooseOption
    {
        public RemoveCrayon(ShowMenu whatMenu, Child child) : base(whatMenu,false)
        {
            this.Child = child;
        }
        Child Child { get; set; }

        public override void ControlInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
        }
        public override void InitializationMetod()
        {
            WhatMenu.PositionsMenuList.Clear();
            if (Child.CollectionOfCrayons.Count != 0)
            {
                foreach (string color in Child.CollectionOfCrayons)
                {
                    WhatMenu.PositionsMenuList.Add(color);
                }
            }
            BasicAction(0, Child.Name);
        }
        public override void EnterKeyAction()
        {
            Child.RemoveCrayon(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
            WhatMenu.PositionsMenuList.Remove(WhatMenu.PositionsMenuList[WhatMenu.ActivePosition]);
            if (WhatMenu.PositionsMenuList.Count != 0 && WhatMenu.ActivePosition == WhatMenu.PositionsMenuList.Count)
            {
                WhatMenu.ChangeMenuActivePosition(WhatMenu.PositionsMenuList.Count - 1);
            }
            BasicAction(WhatMenu.ActivePosition, Child.Name);
        }

    }
}
