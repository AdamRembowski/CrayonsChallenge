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
        if (childMenu.PositionsMenuList.Any())
        {
            string activeChild = childMenu.PositionsMenuList[childMenu.ActivePosition];
            ShowActiveChild(activeChild);
        }
        else
        {
            ShowActiveChild("");
        }
        ControlInfoEnterOnly();
        mainMenu.ShowMenuPositions();
        mainMenuChooseOption.ActivateOption();        
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
                    childMenu.ChangeMenuActivePosition(childMenu.PositionsMenuList.Count - 1);
                }
                Console.Clear();
                break;
            case 1:
                Console.Clear();
                if (childMenu.PositionsMenuList.Any())
                {
                    childMenu.ShowMenuPositions();
                    string activeChild = childMenu.PositionsMenuList[childMenu.ActivePosition];
                    ShowActiveChild(activeChild);                    
                    ControlInfoEnterOnly();
                    childMenuChooseOption.ActivateOption();
                }
                Console.Clear();
                break;
            case 2:
                Console.Clear();
                ControlInfoCrayonAddRemove();
                if (childMenu.PositionsMenuList.Any())
                {
                    AddCrayon addCrayon = new AddCrayon(crayonMenu, childList[childMenu.ActivePosition]);
                    crayonMenu.ChangeMenuActivePosition(0);
                    addCrayon.InitializationMetod();
                    crayonMenu.ShowMenuPositions();
                    ShowActiveChild(childMenu.PositionsMenuList[childMenu.ActivePosition]);
                    addCrayon.ActivateOption();
                }
                Console.Clear();
                break;
            case 3:
                Console.Clear();
                ControlInfoCrayonAddRemove();
                if (childMenu.PositionsMenuList.Any())
                {
                    RemoveCrayon removeCrayon = new RemoveCrayon(crayonMenu, childList[childMenu.ActivePosition]);
                    crayonMenu.ChangeMenuActivePosition(0);
                    removeCrayon.InitializationMetod();
                    crayonMenu.ShowMenuPositions();
                    ShowActiveChild(childMenu.PositionsMenuList[childMenu.ActivePosition]);
                    removeCrayon.ActivateOption();
                }
                Console.Clear();
                break;
            case 4:
                Console.Clear();
                if (childMenu.PositionsMenuList.Any())
                {
                    ShowStatistics(childMenu.PositionsMenuList[childMenu.ActivePosition]);
                }
                ControlInfoShowStatistics();
                EscKeyDelayed();
                Console.Clear();
                break;
            case 5:
                Console.Clear();
                foreach (string childName in childMenu.PositionsMenuList)
                {
                    ShowStatistics(childName);
                    Console.WriteLine();
                }
                ControlInfoShowStatistics();
                EscKeyDelayed();
                Console.Clear();
                break;
            case 6:
                var saveAll = new SaveAllStatistics(childList);
                saveAll.ActivateOption();
                if (File.Exists("output.txt"))
                {                    
                    ClearLine(19);
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("Zapisono poprawnie do pliku");
                    Console.SetCursorPosition(0, 0);
                }
                break;
            case 7:
                var loadFromFile = new LoadFromFile(); loadFromFile.ActivateOption(ref childMenu, ref childList);
                if (childList.Any())
                {                    
                    ClearLine(19);
                    Console.SetCursorPosition(0, 19);
                    Console.WriteLine("Wczytano poprawnie z pliku");
                    Console.SetCursorPosition(0, 0);
                }
                break;
            case 8: Environment.Exit(0); break;
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}
void EscKeyDelayed()
{
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
void ShowStatistics(string childName)
{
    Child? child = childList.Find(delegate (Child child) { return child.Name == childName; });
    if (child != null)
    {
        Statistics statistics = new Statistics(child);
        Console.WriteLine($"Imię dziecka: {statistics.Name}");
        Console.WriteLine($"Zebranych kredek: {statistics.CollectionOfCrayonsCount}");
        foreach (var crayon in child.CollectionOfCrayons)
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
}
string GetChildName()
{
    string input = "";
    ControlInfoAddChild();
    Console.WriteLine("Podaj imię dziecka:");
    ConsoleKeyInfo keyInfo;
    while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
    {
        ClearLine(1);
        ControlInfoAddChild();
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
void ControlInfoAddChild()
{    
    Console.SetCursorPosition(0, 3);
    Console.Write("Kliknij klawisz Enter aby dodać dziecko, ESC aby wyjść");
    Console.SetCursorPosition(0, 0);
}
void ControlInfoCrayonAddRemove()
{
    Console.SetCursorPosition(0, 20);
    Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
    Console.SetCursorPosition(0, 0);
}
void ControlInfoShowStatistics()
{
    Console.WriteLine();
    Console.WriteLine("Kliknij klawisz ESC aby wyjść");
}
void ControlInfoEnterOnly()
{
    Console.SetCursorPosition(0, 20);
    Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór");
    Console.SetCursorPosition(0, 0);
}
void ShowActiveChild(string activeChild)
{
    Console.SetCursorPosition(0, 18);
    Console.WriteLine($"Wybrane Dziecko: {activeChild}");
    Console.SetCursorPosition(0, 0);
}
void ClearLine(int line)
{
    Console.SetCursorPosition(0, line);
    Console.WriteLine(new String(' ', 35));
    Console.SetCursorPosition(0, 0);
}