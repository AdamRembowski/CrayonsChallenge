namespace CrayonsChallenge
{
    public class ChooseOption
    {
        public ShowMenu WhatMenu { get; }
        public ChooseOption(ShowMenu whatMenu)
        {
            this.WhatMenu = whatMenu;
        }
        public virtual int ActivateOption(ShowMenu whatMenu, string activeChild)
        {
            if (whatMenu.PositionsMenuList != null)
            {
                do
                {
                    BasicAction(ref whatMenu, whatMenu.ActivePosition, activeChild);
                    ConsoleKeyInfo klawisz = Console.ReadKey();
                    if (klawisz.Key == ConsoleKey.UpArrow)
                    {
                        int activePosition = (whatMenu.ActivePosition > 0) ? whatMenu.ActivePosition - 1 : whatMenu.PositionsMenuList.Count - 1;
                        BasicAction(ref whatMenu, activePosition, activeChild);
                    }
                    else if (klawisz.Key == ConsoleKey.DownArrow)
                    {
                        int activePosition = (whatMenu.ActivePosition + 1) % whatMenu.PositionsMenuList.Count;
                        BasicAction(ref whatMenu, activePosition, activeChild);
                    }
                    else if (klawisz.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        break;
                    }
                    else if (klawisz.Key == ConsoleKey.Escape)
                    {
                        Console.Write("_");
                    }
                    else
                    {
                        Console.Clear();
                        BasicAction(ref whatMenu, whatMenu.ActivePosition, activeChild);
                    }
                } while (true);
            }
            return whatMenu.ActivePosition;
        }
        public void BasicAction(ref ShowMenu whatMenu, int activePosition, string activeChild)
        {
            whatMenu.ChangeMenuActivePosition(activePosition);
            whatMenu.ShowMenuPositions();
            ShowActiveChild(activeChild);
            ControlInfo();
        }
        public virtual void ControlInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór");
        }
        public void ShowActiveChild(string activeChild)
        {
            Console.WriteLine();
            Console.WriteLine($"Wybrane Dziecko: {activeChild}");
            Console.WriteLine();
        }

    }
}
