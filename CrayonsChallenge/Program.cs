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
MainMenu.PositionsMenuList.Add("Zapisz do pliku");
MainMenu.PositionsMenuList.Add("Wczytaj z pliku");
MainMenu.PositionsMenuList.Add("Zakończ");

Console.Title = "Crayons Challenge Console App";
Console.CursorVisible = false;
List<Child> ChildList = new List<Child>();

ChooseOption MainMenuChooseOption = new ChooseOption(MainMenu);
ChooseOption ChildMenuChooseOption = new ChooseOption(ChildMenu);

while (true)
{
    MainMenu.ShowMenuPositions();
    if (ChildMenu.PositionsMenuList.Any())
    {
        var PositionsMenuList = ChildMenu.PositionsMenuList[ChildMenu.ActivePosition];
        int ActivOption = MainMenuChooseOption.ActivateOption(MainMenu, PositionsMenuList);
        MainMenu.ChangeMenuActivePosition(ActivOption);
    }
    else
    {
        int ActivOption = MainMenuChooseOption.ActivateOption(MainMenu, "");
        MainMenu.ChangeMenuActivePosition(ActivOption);
    }
    ActivateOption();
}
void ActivateOption()
{

    switch (MainMenu.ActivePosition)
    {
        case 0: Console.Clear();
            var addChild = new AddChild(ChildMenu);
            var NewChild = addChild.ActivateOption();
            if (NewChild!=null)
            {
                ChildList.Add(NewChild);
            }
            break;
        case 1: 
            Console.Clear();
            if (ChildMenu.PositionsMenuList.Any())
            {
                string ActiveChild = ChildMenu.PositionsMenuList[ChildMenu.ActivePosition];
                ChildMenuChooseOption.ActivateOption(ChildMenu, ActiveChild);
            }
            break;
        case 2:
            Console.Clear();
            if (ChildMenu.PositionsMenuList.Any())
            {
                AddCrayon AddCrayon = new AddCrayon(CrayonsMenu, ChildList[ChildMenu.ActivePosition]);
                AddCrayon.ActivateOption(CrayonsMenu, ChildMenu.PositionsMenuList[ChildMenu.ActivePosition]);
            }
            break;
        case 3:
            Console.Clear();
            if (ChildMenu.PositionsMenuList.Any())
            {
                RemoveCrayon RemoveCrayon = new RemoveCrayon(CrayonsMenu, ChildList[ChildMenu.ActivePosition]);
                RemoveCrayon.ActivateOption(CrayonsMenu, ChildMenu.PositionsMenuList[ChildMenu.ActivePosition]);
            }
            break;
         case 4: Console.Clear(); var showStatistics = new ShowStatistics(ChildList); showStatistics.ActivateOption(ChildMenu.ActivePosition); break;
        //case 4: Console.Clear(); var statistics = ChildList[ChildMenu.ActivePosition].GetStatistics(); break;
        case 5: Console.Clear(); var showAllStatistics = new ShowAllStatistics(ChildList); showAllStatistics.ActivateOption(); break;
        case 6: Console.Clear(); var saveAll = new SaveAllStatistics(ChildList); saveAll.ActivateOption(); break;
        case 7: Console.Clear(); 
            //ChildMenu.PositionsMenuList.Clear();  
            var loadFromFile = new LoadFromFile(); loadFromFile.ActivateOption(ref ChildMenu, ref ChildList); 
            break;
        case 8: Environment.Exit(0); break;
    }
}

public class Statistics
{
    public List<string> CollectionOfCrayons { get; set; }
    public int Score { get; set; }
    public bool IiWinner { get; set; }

 
}