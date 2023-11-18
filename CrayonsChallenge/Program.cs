using CrayonsChallenge;

Console.Title = ">>> Kredkowe Wyzwanie <<<";
Console.CursorVisible = false;

ShowMenu mainMenu = new ShowMenu("Wybierz Opcję:");
ShowMenu childMenu = new ShowMenu("Wybierz Dziecko:");
ShowMenu crayonMenu = new ShowMenu("Wybierz Kolor Kredki:");

mainMenu.PositionsMenuList.Add("Dodaj dziecko");
mainMenu.PositionsMenuList.Add("Wybierz dziecko");
mainMenu.PositionsMenuList.Add("Daj dziecku kredkę");
mainMenu.PositionsMenuList.Add("Usuń błędnie dodaną kredkę");
mainMenu.PositionsMenuList.Add("Pokaż statystyki");
mainMenu.PositionsMenuList.Add("Pokaż statystyki wszystkich");
mainMenu.PositionsMenuList.Add("Zapisz do pliku");
mainMenu.PositionsMenuList.Add("Wczytaj z pliku");
mainMenu.PositionsMenuList.Add("Zakończ");

List<Child> childList = new List<Child>();

ChooseOption mainMenuChooseOption = new ChooseOption(mainMenu);
ChooseOption childMenuChooseOption = new ChooseOption(childMenu);
try
{
    while (true)
    {
        mainMenu.ShowMenuPositions();
        if (childMenu.PositionsMenuList.Any())
        {
            string activeChild = childMenu.PositionsMenuList[childMenu.ActivePosition];
            int activOption = mainMenuChooseOption.ActivateOption(activeChild);
            mainMenu.ChangeMenuActivePosition(activOption);
        }
        else
        {
            int activOption = mainMenuChooseOption.ActivateOption("");
            mainMenu.ChangeMenuActivePosition(activOption);
        }
        switch (mainMenu.ActivePosition)
        {
            case 0:
                Console.Clear();
                string newName = GetChildName();
                if (newName != "")
                {
                    var newChild = new Child(newName);
                    childList.Add(newChild);
                    childMenu.PositionsMenuList.Add(newName);
                    childMenu.ChangeMenuActivePosition(childMenu.PositionsMenuList.Count);
                }
                break;
            case 1:
                Console.Clear();
                if (childMenu.PositionsMenuList.Any())
                {
                    string activeChild = childMenu.PositionsMenuList[childMenu.ActivePosition];
                    childMenuChooseOption.ActivateOption(activeChild);
                }
                break;
            case 2:
                Console.Clear();
                if (childMenu.PositionsMenuList.Any())
                {
                    AddCrayon addCrayon = new AddCrayon(crayonMenu, childList[childMenu.ActivePosition]);
                    addCrayon.ActivateOption(childMenu.PositionsMenuList[childMenu.ActivePosition]);
                }
                break;
            case 3:
                Console.Clear();
                if (childMenu.PositionsMenuList.Any())
                {
                    RemoveCrayon removeCrayon = new RemoveCrayon(crayonMenu, childList[childMenu.ActivePosition]);
                    removeCrayon.ActivateOption(childMenu.PositionsMenuList[childMenu.ActivePosition]);
                }
                break;
            case 4:
                Console.Clear();
                Statistics statistics = new Statistics(childList[childMenu.ActivePosition]);
                ShowStatistics(statistics);
                EscKeyDelayed();
                break;
            case 5:
                Console.Clear();
                for (int index = 0; index < childList.Count; index++)
                {
                    ShowStatistics(new Statistics(childList[index]));
                    Console.WriteLine();
                }
                EscKeyDelayed();
                break;
            case 6:
                Console.Clear();
                var saveAll = new SaveAllStatistics(childList);
                saveAll.ActivateOption();
                break;
            case 7:
                Console.Clear();
                var loadFromFile = new LoadFromFile(); loadFromFile.ActivateOption(ref childMenu, ref childList);
                break;
            case 8: Environment.Exit(0); break;
        }
    }
}
catch
{
   
}
void EscKeyDelayed()
{
    Console.WriteLine();
    Console.WriteLine("Kliknij klawisz Enter ESC aby wyjść");
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
void ShowStatistics(Statistics statistics)
{
    Console.WriteLine($"Imię dziecka: {statistics.Name}");
    Console.WriteLine($"Zebranych kredek: {statistics.CollectionOfCrayons.Count}");
    foreach (var crayon in statistics.CollectionOfCrayons)
    {
        Console.WriteLine(crayon);
    }
    if (statistics.IsWinner)
    {
        Console.WriteLine($"Dziecko o imieniu: {statistics.Name} zapracowało na kolorowankę!");
    }
    else
    {
        Console.WriteLine($"{statistics.Score} % zebranych kredek");
    }
}
string GetChildName()
{
    string input = "";
    ControlInfo();
    Console.WriteLine("Podaj imię dziecka:");
    ConsoleKeyInfo keyInfo;
    while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
    {
        Console.Clear();
        ControlInfo();
        Console.WriteLine("Podaj imię dziecka:");
        if (Char.IsLetter(keyInfo.KeyChar))
        {
            input += keyInfo.KeyChar;
            Console.Write(input);
        }
        else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
        {
            input = input.Remove(input.Length - 1, 1);
            Console.Write(input);
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            if (input != null && input != "")
            {
                return input;
            }
        }
        else if (!Char.IsLetter(keyInfo.KeyChar))
        {
            Console.Write(input);
        }
    }
    return "";
}
void ControlInfo()
{
    Console.SetCursorPosition(0, 3);
    Console.Write("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
    Console.SetCursorPosition(0, 0);
}
