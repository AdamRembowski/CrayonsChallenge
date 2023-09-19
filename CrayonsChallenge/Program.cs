using CrayonsChallenge;

List<string> pozycjeMenuKredki = new List<string>();
int aktywnaPozycjaMenuKredki = 0;
int aktywnaPozycja = 0;
int aktywneDziecko = 0;
List<string> crayons = new Crayons().color();
string[] pozycjeMenu = { "Dodaj dziecko", "Wybierz dziecko", "Daj dziecku kredkę", "Usuń błędnie dodaną kredkę", "Pokaż statystyki", "Pokaż statystyki wszystkich", "Zakończ" };
Console.Title = "Crayons Challenge Console App";
Console.CursorVisible = false;
List<Child> ChildList = new List<Child>();
bool prawda = true;

while (prawda)
{
    PokazMenu();
    WybierzOpcje();
    UruchomOpcje();
}
void WybierzOpcje()
{
    do
    {
        ConsoleKeyInfo klawisz = Console.ReadKey();
        if (klawisz.Key == ConsoleKey.UpArrow)
        {
            aktywnaPozycja = (aktywnaPozycja > 0) ? aktywnaPozycja - 1 : pozycjeMenu.Length - 1;
            PokazMenu();
        }
        else if (klawisz.Key == ConsoleKey.DownArrow)
        {
            aktywnaPozycja = (aktywnaPozycja + 1) % pozycjeMenu.Length;
            PokazMenu();
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
            PokazMenu();
        }
    } while (true);
}
void PokazMenu()
{
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    if (ChildList.Count > 0)
    {
        Console.WriteLine($"Wybrane Dziecko: {ChildList[aktywneDziecko].Name}");
        Console.WriteLine();
    }
    Console.WriteLine("Wybierz Opcję:");
    for (int i = 0; i < pozycjeMenu.Length; i++)
    {
        if (i == aktywnaPozycja)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0,-35}", pozycjeMenu[i]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine(pozycjeMenu[i]);
        }
    }
}
void PokazMenuDzieci()
{
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Wybierz Dziecko:");
    for (int i = 0; i < ChildList.Count; i++)
    {
        if (i == aktywneDziecko)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0,-35}", ChildList[i].Name);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine(ChildList[i].Name);
        }
    }
}
void UruchomOpcje()
{
    switch (aktywnaPozycja)
    {
        case 0: Console.Clear(); DodajDziecko(); break;
        case 1: Console.Clear(); WybierzDziecko(); break;
        case 2: Console.Clear(); DodajUsunKredke(aktywneDziecko, true); break;
        case 3: Console.Clear(); DodajUsunKredke(aktywneDziecko, false); break;
        case 4: Console.Clear(); PokazStatystyki(aktywneDziecko); break;
        case 5: Console.Clear(); PokazStatystykiWszystkich(); break;
        case 6: Environment.Exit(0); break;
    }
}

void WybierzDziecko()
{
    if (ChildList.Count > 1)
    {
        PokazMenuDzieci();
        do
        {
            ConsoleKeyInfo klawisz = Console.ReadKey();
            if (klawisz.Key == ConsoleKey.UpArrow)
            {
                aktywneDziecko = (aktywneDziecko > 0) ? aktywneDziecko - 1 : ChildList.Count - 1;
                PokazMenuDzieci();
            }
            else if (klawisz.Key == ConsoleKey.DownArrow)
            {
                aktywneDziecko = (aktywneDziecko + 1) % ChildList.Count;
                PokazMenuDzieci();
            }
            else if (klawisz.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }
            else if (klawisz.Key == ConsoleKey.Escape)
            {
                Console.Write("_");
                PokazMenu();
                break;
            }
            else
            {
                Console.Clear();
                PokazMenuDzieci();
            }
        } while (true);
    }
}
void DodajUsunKredke(int indexChild, bool czyDodaj)
{
    if (ChildList.Count > 1)
    {
        pozycjeMenuKredki.Clear();
        if (czyDodaj)
        {
            foreach (string color in crayons)
            {
                pozycjeMenuKredki.Add(color);
            }
            for (int i = 0; i < ChildList[indexChild].CollectionOfCrayons.Count; i++)
            {
                pozycjeMenuKredki.Remove(ChildList[indexChild].CollectionOfCrayons[i]);
            }
        }
        else
        {
            foreach (string color in ChildList[indexChild].CollectionOfCrayons)
            {
                pozycjeMenuKredki.Add(color);
            }
        }
        PokazMenuKredki();
        try
        {
            do
            {
                ConsoleKeyInfo klawisz = Console.ReadKey();
                if (klawisz.Key == ConsoleKey.UpArrow)
                {
                    aktywnaPozycjaMenuKredki = (aktywnaPozycjaMenuKredki > 0) ? aktywnaPozycjaMenuKredki - 1 : pozycjeMenuKredki.Count - 1;
                    PokazMenuKredki();
                }
                else if (klawisz.Key == ConsoleKey.DownArrow)
                {
                    aktywnaPozycjaMenuKredki = (aktywnaPozycjaMenuKredki + 1) % pozycjeMenuKredki.Count;
                    PokazMenuKredki();
                }
                else if (klawisz.Key == ConsoleKey.Enter && !czyDodaj)
                {
                    ChildList[indexChild].RemoveCrayon(pozycjeMenuKredki[aktywnaPozycjaMenuKredki]);
                    pozycjeMenuKredki.Remove(pozycjeMenuKredki[aktywnaPozycjaMenuKredki]);
                    PokazMenuKredki();
                }
                else if (klawisz.Key == ConsoleKey.Enter && czyDodaj)
                {
                    ChildList[indexChild].GiveCrayon(pozycjeMenuKredki[aktywnaPozycjaMenuKredki]);
                    pozycjeMenuKredki.Remove(pozycjeMenuKredki[aktywnaPozycjaMenuKredki]);
                    PokazMenuKredki();
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
    ChildList.Add(new Child(input));
    Console.WriteLine();
    Console.WriteLine("Kliknij klawisz Esc aby zakończyc dodawanie");
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
void PokazMenuKredki()
{
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Wybierz Kolor Kredki:");
    for (int i = 0; i < pozycjeMenuKredki.Count; i++)
    {
        if (i == aktywnaPozycjaMenuKredki)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("{0,-35}", pozycjeMenuKredki[i]);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine(pozycjeMenuKredki[i]);
        }
    }
    Console.WriteLine();
    Console.WriteLine("Kliknij klawisz Esc aby zakończyc dodawanie");
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


