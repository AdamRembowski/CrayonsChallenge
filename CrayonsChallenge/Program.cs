using CrayonsChallenge;

List<string> CrayonsColorsList = new List<string>();
List<string> crayons = new Crayons().color();
List<string> PositionsMenuList = new List<string>();
PositionsMenuList.Add("Dodaj dziecko");
PositionsMenuList.Add("Wybierz dziecko");
PositionsMenuList.Add("Daj dziecku kredkę");
PositionsMenuList.Add("Usuń błędnie dodaną kredkę");
PositionsMenuList.Add("Pokaż statystyki");
PositionsMenuList.Add("Pokaż statystyki wszystkich");
PositionsMenuList.Add("Zakończ");
Console.Title = "Crayons Challenge Console App";
Console.CursorVisible = false;
List<Child> ChildList = new List<Child>();
List<string> ChildListName = new List<string>();
bool prawda = true;
ShowMenu MainMenu = new ShowMenu("Wybierz Opcję:");
ShowMenu ChildMenu = new ShowMenu("Wybierz Dziecko:");
ShowMenu CrayonsMenu = new ShowMenu("Wybierz Kolor Kredki:");

while (prawda)
{
    MainMenu.ShowMenuPositions(PositionsMenuList);
    WybierzOpcje();
    UruchomOpcje();
}
void ShowActiveChild()
{
    if (ChildList.Count != 0)
    {
        Console.WriteLine();
        Console.WriteLine($"Wybrane Dziecko: {ChildList[ChildMenu.ActivePosition].Name}");
        Console.WriteLine();
    }
}


void WybierzOpcje()
{
    do
    {
        MainMenu.ShowMenuPositions(PositionsMenuList); ;
        ShowActiveChild();
        ConsoleKeyInfo klawisz = Console.ReadKey();
        if (klawisz.Key == ConsoleKey.UpArrow)
        {
            MainMenu.ActivePosition = (MainMenu.ActivePosition > 0) ? MainMenu.ActivePosition - 1 : PositionsMenuList.Count - 1;
            MainMenu.ShowMenuPositions(PositionsMenuList); ;
            ShowActiveChild();
        }
        else if (klawisz.Key == ConsoleKey.DownArrow)
        {
            MainMenu.ActivePosition = (MainMenu.ActivePosition + 1) % PositionsMenuList.Count;
            MainMenu.ShowMenuPositions(PositionsMenuList); ;
            ShowActiveChild();
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
            MainMenu.ShowMenuPositions(PositionsMenuList);
            ShowActiveChild();
        }
    } while (true);
}
void OpcjaWyjscia()
{
    Console.WriteLine();
    Console.WriteLine("Kliknij klawisz Enter aby potwierdzić wybór, Esc aby wyjść z opcji");
}
void UruchomOpcje()
{
    switch (MainMenu.ActivePosition)
    {
        case 0: Console.Clear(); DodajDziecko(); break;
        case 1: Console.Clear(); WybierzDziecko(); break;
        case 2: Console.Clear(); DodajUsunKredke(ChildMenu.ActivePosition, true); break;
        case 3: Console.Clear(); DodajUsunKredke(ChildMenu.ActivePosition, false); break;
        case 4: Console.Clear(); PokazStatystyki(ChildMenu.ActivePosition); break;
        case 5: Console.Clear(); PokazStatystykiWszystkich(); break;
        case 6: Environment.Exit(0); break;
    }
}
void WybierzDziecko()
{
    if (ChildListName.Count != 0)
    {
        ChildMenu.ShowMenuPositions(ChildListName);
        OpcjaWyjscia();
        do
        {
            ConsoleKeyInfo klawisz = Console.ReadKey();
            if (klawisz.Key == ConsoleKey.UpArrow)
            {
                ChildMenu.ActivePosition = (ChildMenu.ActivePosition > 0) ? ChildMenu.ActivePosition - 1 : ChildListName.Count - 1;
                ChildMenu.ShowMenuPositions(ChildListName);
                OpcjaWyjscia();
            }
            else if (klawisz.Key == ConsoleKey.DownArrow)
            {
                ChildMenu.ActivePosition = (ChildMenu.ActivePosition + 1) % ChildListName.Count;
                ChildMenu.ShowMenuPositions(ChildListName);
                OpcjaWyjscia();
            }
            else if (klawisz.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }
            else if (klawisz.Key == ConsoleKey.Escape)
            {
                Console.Write("_");
                MainMenu.ShowMenuPositions(PositionsMenuList);
                OpcjaWyjscia();
                break;
            }
            else
            {
                Console.Clear();
                ChildMenu.ShowMenuPositions(ChildListName);
                OpcjaWyjscia();
            }
        } while (true);
    }
}
void DodajUsunKredke(int indexChild, bool czyDodaj)
{
    if (ChildList.Count != 0)
    {
        CrayonsColorsList.Clear();
        if (czyDodaj)
        {
            foreach (string color in crayons)
            {
                CrayonsColorsList.Add(color);
            }
            for (int i = 0; i < ChildList[indexChild].CollectionOfCrayons.Count; i++)
            {
                CrayonsColorsList.Remove(ChildList[indexChild].CollectionOfCrayons[i]);
            }
        }
        else
        {
            foreach (string color in ChildList[indexChild].CollectionOfCrayons)
            {
                CrayonsColorsList.Add(color);
            }
        }
        CrayonsMenu.ShowMenuPositions(CrayonsColorsList);
        OpcjaWyjscia();
        try
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow)
                {
                    CrayonsMenu.ActivePosition = (CrayonsMenu.ActivePosition > 0) ? CrayonsMenu.ActivePosition - 1 : CrayonsColorsList.Count - 1;
                    CrayonsMenu.ShowMenuPositions(CrayonsColorsList);
                    OpcjaWyjscia();
                }
                else if (klawisz.Key == ConsoleKey.DownArrow)
                {
                    CrayonsMenu.ActivePosition = (CrayonsMenu.ActivePosition + 1) % CrayonsColorsList.Count;
                    CrayonsMenu.ShowMenuPositions(CrayonsColorsList);
                    OpcjaWyjscia();
                }
                else if (klawisz.Key == ConsoleKey.Enter && !czyDodaj)
                {
                    ChildList[indexChild].RemoveCrayon(CrayonsColorsList[CrayonsMenu.ActivePosition]);
                    CrayonsColorsList.Remove(CrayonsColorsList[CrayonsMenu.ActivePosition]);
                    CrayonsMenu.ShowMenuPositions(CrayonsColorsList);
                    OpcjaWyjscia();
                }
                else if (klawisz.Key == ConsoleKey.Enter && czyDodaj)
                {
                    ChildList[indexChild].GiveCrayon(CrayonsColorsList[CrayonsMenu.ActivePosition]);
                    CrayonsColorsList.Remove(CrayonsColorsList[CrayonsMenu.ActivePosition]);
                    CrayonsMenu.ShowMenuPositions(CrayonsColorsList);
                    OpcjaWyjscia();
                }
                else if (klawisz.Key == ConsoleKey.Escape)
                {
                    Console.Write("_");
                    break;
                }
            } while (true);
        }
        catch (Exception e) { }
    }
}
void DodajDziecko()
{
    Console.WriteLine("Podaj imię dziecka:");
    var input = Console.ReadLine();
    if (input != null)
    {
        ChildList.Add(new Child(input));
        ChildListName.Add(input); // nieładne rozwiązanie
    }

}
void PokazStatystyki(int indexChild)
{
    if (ChildList.Count > 1)
    {
        try
        {
            Podsumowanie(indexChild);
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
    if (ChildList.Count > 1)
    {
        try
        {
            for (int index = 0; index < ChildList.Count; index++)
            {
                Podsumowanie(index);
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
void Podsumowanie(int indexChild)
{
    //Console.Clear();
    Console.WriteLine($"Imię dziecka: {ChildList[indexChild].Name}");
    int counter = ChildList[indexChild].GetCount();
    Console.WriteLine($"Zebranych kredek: {counter}");
    foreach (var crayon in ChildList[indexChild].CollectionOfCrayons)
    {
        Console.WriteLine(crayon);
    }
    if (ChildList[indexChild].IsWinner)
    {
        Console.WriteLine($"{ChildList[indexChild].Name} zapracował na kolorowankę!");
    }
    else
    {
        double division = ((counter * 100) / 16);
        var score = (Math.Round(division, 0));
        Console.WriteLine($"{score} % zebranych kredek");
    }
}


