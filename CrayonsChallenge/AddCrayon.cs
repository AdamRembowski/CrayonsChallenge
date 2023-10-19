namespace CrayonsChallenge
{
    public class AddCrayon : ChooseOption
    {
        public AddCrayon(ShowMenu WhatMenu, Child Child) : base(WhatMenu)
        {
            this.Child = Child;
        }
        Child Child { get; }
        List<string> crayons = new Crayons().Color;
        public override int ActivateOption(ShowMenu whatMenu, string activeChild)
        {
            try
            {
                {
                    whatMenu.PositionsMenuList = crayons;
                    foreach (string color in Child.CollectionOfCrayons)
                    {
                        whatMenu.PositionsMenuList.Remove(color);
                    }
                }
                BasicAction(ref whatMenu, 0, activeChild);
                do
                {
                    ConsoleKeyInfo klawisz = Console.ReadKey();
                    if (klawisz.Key == ConsoleKey.UpArrow)
                    {
                        int ActivePosition = (whatMenu.ActivePosition > 0) ? whatMenu.ActivePosition - 1 : whatMenu.PositionsMenuList.Count - 1;
                        BasicAction(ref whatMenu, ActivePosition, activeChild);
                    }
                    else if (klawisz.Key == ConsoleKey.DownArrow)
                    {
                        int ActivePosition = (whatMenu.ActivePosition + 1) % whatMenu.PositionsMenuList.Count;
                        BasicAction(ref whatMenu, ActivePosition, activeChild);
                    }
                    else if (klawisz.Key == ConsoleKey.Enter)
                    {
                        Child.GiveCrayon(whatMenu.PositionsMenuList[whatMenu.ActivePosition]);
                        whatMenu.PositionsMenuList.Remove(whatMenu.PositionsMenuList[whatMenu.ActivePosition]);
                        if (whatMenu.PositionsMenuList.Count != 0 && whatMenu.ActivePosition == 0)
                        {
                            whatMenu.ChangeMenuActivePosition(0);
                        }
                        else if (whatMenu.ActivePosition == whatMenu.PositionsMenuList.Count)
                        {
                            whatMenu.ChangeMenuActivePosition(whatMenu.PositionsMenuList.Count-1);                            
                        }
                        BasicAction(ref whatMenu, whatMenu.ActivePosition, activeChild);
                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        Console.Write("_");
                        break;
                    }
                } while (true);
            }
            catch (Exception e) { }
            return whatMenu.ActivePosition;
        }
        public override void ControlInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
        }
    }
}
