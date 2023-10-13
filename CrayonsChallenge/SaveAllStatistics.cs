using CrayonsChallenge;

public class SaveAllStatistics : ISaveAllStatistics
{
    public SaveAllStatistics(List<Child> childList)
    {
        ChildList = childList;
    }
    private List<Child> ChildList { get; }
    public void ActivateOption()
    {
        if (ChildList.Count != 0)
        {
            try
            {
                File.Delete("output.txt");
                using (var writer = File.AppendText("output.txt"))
                {
                    for (int index = 0; index < ChildList.Count; index++)
                    {
                        writer.WriteLine("Name:");
                        writer.WriteLine($"{ChildList[index].Name}");
                        foreach (string crayons in ChildList[index].CollectionOfCrayons)
                        {
                            writer.WriteLine(crayons);
                        }
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}



