using CrayonsChallenge;

public class ShowAllStatistics : IShowAllStatistics
{
    public ShowAllStatistics(List<Child> childList)
    {
        this.ChildList = childList;
    }
    private List<Child> ChildList { get; }
    public void ActivateOption()
    {
        if (ChildList.Count != 0)
        {
            try
            {
                for (int index = 0; index < ChildList.Count; index++)
                {
                    ChildList[index].Statistics();
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
}
