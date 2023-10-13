using CrayonsChallenge;

public class ShowStatistics : IShowStatistics
{
    public ShowStatistics(List<Child> childList)
    {
        ChildList = childList;
    }
    private List<Child> ChildList { get; }
    public void ActivateOption(int indexChild)
    {
        if (ChildList.Count != 0)
        {
            try
            {
                ChildList[indexChild].Statistics();
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
}

