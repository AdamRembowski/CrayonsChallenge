using CrayonsChallenge;

ShowMenu MainMenu = new ShowMenu("Wybierz Opcję:");
ShowMenu ChildMenu = new ShowMenu("Wybierz Dziecko:");
ShowMenu CrayonsMenu = new ShowMenu("Wybierz Kolor Kredki:");

MainMenu.PositionsMenuList.Add("Dodaj dziecko");
MainMenu.PositionsMenuList.Add("Wybierz dziecko");
MainMenu.PositionsMenuList.Add("Daj dziecku kredkę");
MainMenu.PositionsMenuList.Add("Usuń błędnie dodaną kredkę");
MainMenu.PositionsMenuList.Add("Pokaż statystyki");
MainMenu.PositionsMenuList.Add("Pokaż statystyki wszystkich");
MainMenu.PositionsMenuList.Add("Zakończ");

Console.Title = "Crayons Challenge Console App";
Console.CursorVisible = false;
List<Child> ChildList = new List<Child>();

ChooseOption MainMenuChooseOption = new ChooseOption(MainMenu);
ChooseOption ChildMenuChooseOption = new ChooseOption(ChildMenu);

DodajDziecko();
while (true)
{
    MainMenu.ShowMenuPositions();
    MainMenuChooseOption.ActivateOption(MainMenu, ChildMenu.PositionsMenuList[ChildMenu.ActivePosition]);
    UruchomOpcje();
}
void UruchomOpcje()
{

    switch (MainMenu.ActivePosition)
    {
        case 0: Console.Clear(); DodajDziecko(); break;
        case 1: Console.Clear(); ChildMenuChooseOption.ActivateOption(ChildMenu, ChildMenu.PositionsMenuList[ChildMenu.ActivePosition]); break;
        case 2:
            Console.Clear();
            AddCrayon AddCrayon = new AddCrayon(CrayonsMenu, ChildList[ChildMenu.ActivePosition]);
            AddCrayon.ActivateOption(CrayonsMenu, ChildMenu.PositionsMenuList[ChildMenu.ActivePosition]);
            break;
        case 3:
            Console.Clear();
            RemoveCrayon RemoveCrayon = new RemoveCrayon(CrayonsMenu, ChildList[ChildMenu.ActivePosition]);
            RemoveCrayon.ActivateOption(CrayonsMenu, ChildMenu.PositionsMenuList[ChildMenu.ActivePosition]);
            break;
        case 4: Console.Clear(); PokazStatystyki(ChildMenu.ActivePosition); break;
        case 5: Console.Clear(); PokazStatystykiWszystkich(); break;
        case 6: Environment.Exit(0); break;
    }
}
void DodajDziecko()
{
    do
    {
        if (ChildMenu.PositionsMenuList.Count() == 0)
        {
            Console.WriteLine("Podaj imię pierwszego dziecka:");
        }
        else
        {
            Console.WriteLine("Podaj imię dziecka:");
        }
        var input = Console.ReadLine();
        if (input != null && input != "")
        {
            ChildList.Add(new Child(input));
            ChildMenu.PositionsMenuList.Add(input);            
            break;
        }
        Console.Clear();
    } while (true);
}
void PokazStatystyki(int indexChild)
{
    if (ChildList.Count != 0)
    {
        try
        {
            ChildList[indexChild].Podsumowanie();
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.Escape)
                {
                    Console.Write("_");
                    break;
                }
            } while (true);
        }
        catch (Exception e) { Console.WriteLine(e); }
    }
}
void PokazStatystykiWszystkich()
{
    if (ChildList.Count != 0)
    {
        try
        {
            for (int index = 0; index < ChildList.Count; index++)
            {
                ChildList[index].Podsumowanie();
                Console.WriteLine();
            }
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.Escape)
                {
                    Console.Write("_");
                    break;
                }
            } while (true);
        }
        catch (Exception e) { Console.WriteLine(e); }
    }
}



