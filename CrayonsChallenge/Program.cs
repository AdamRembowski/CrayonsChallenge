using System.Runtime.CompilerServices;
using CrayonsChallenge;
Console.Title = ">>> Kredkowe Wyzwanie <<<";
Console.CursorVisible = false;

ShowMenu mainMenu = new ShowMenu("Wybierz Opcję:");
ShowMenu childMenu = new ShowMenu("Wybierz Dziecko:");
ShowMenu crayonsMenu = new ShowMenu("Wybierz Kolor Kredki:");

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

while (true)
{
    mainMenu.ShowMenuPositions();
    if (childMenu.PositionsMenuList.Any())
    {
        var positionsMenuList = childMenu.PositionsMenuList[childMenu.ActivePosition];
        int activOption = mainMenuChooseOption.ActivateOption(mainMenu, positionsMenuList);
        mainMenu.ChangeMenuActivePosition(activOption);
    }
    else
    {
        int activOption = mainMenuChooseOption.ActivateOption(mainMenu, "");
        mainMenu.ChangeMenuActivePosition(activOption);
    }
    ActivateOption();
}
void ActivateOption()
{

    switch (mainMenu.ActivePosition)
    {
        case 0: Console.Clear();
            var addChild = new AddChild(childMenu);
            var newChild = addChild.ActivateOption();
            if (newChild!=null)
            {
                childList.Add(newChild);
            }
            break;
        case 1: 
            Console.Clear();
            if (childMenu.PositionsMenuList.Any())
            {
                string activeChild = childMenu.PositionsMenuList[childMenu.ActivePosition];
                childMenuChooseOption.ActivateOption(childMenu, activeChild);
            }
            break;
        case 2:
            Console.Clear();
            if (childMenu.PositionsMenuList.Any())
            {
                AddCrayon addCrayon = new AddCrayon(crayonsMenu, childList[childMenu.ActivePosition]);
                addCrayon.ActivateOption(crayonsMenu, childMenu.PositionsMenuList[childMenu.ActivePosition]);
            }
            break;
        case 3:
            Console.Clear();
            if (childMenu.PositionsMenuList.Any())
            {
                RemoveCrayon removeCrayon = new RemoveCrayon(crayonsMenu, childList[childMenu.ActivePosition]);
                removeCrayon.ActivateOption(crayonsMenu, childMenu.PositionsMenuList[childMenu.ActivePosition]);
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
        case 6: Console.Clear(); 
            var saveAll = new SaveAllStatistics(childList); 
            saveAll.ActivateOption(); 
            break;
        case 7: Console.Clear(); 
            var loadFromFile = new LoadFromFile(); loadFromFile.ActivateOption(ref childMenu, ref childList); 
            break;
        case 8: Environment.Exit(0); break;
    }
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
void ShowStatistics(Statistics statistics)
{
    Console.WriteLine($"Imię dziecka: {statistics.Child.Name}");
    Console.WriteLine($"Zebranych kredek: {statistics.CollectionOfCrayons.Count}");
    foreach (var crayon in statistics.CollectionOfCrayons)
    {
        Console.WriteLine(crayon);
    }
    if (statistics.IsWinner)
    {
        Console.WriteLine($"Dziecko o imieniu: {statistics.Child.Name} zapracowało na kolorowankę!");
    }
    else
    {
        Console.WriteLine($"{statistics.Score} % zebranych kredek");
    }
}
