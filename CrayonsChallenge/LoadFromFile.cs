using CrayonsChallenge;

public class LoadFromFile : ILoadFromFile
{
    public LoadFromFile()
    {
    }
    public void ActivateOption(ref ShowMenu childMenu, ref List<Child> childList)
    {
        try
        {
            using (var reader = File.OpenText("output.txt"))
            {
                int index = -1;
                {
                    var input = reader.ReadLine();
                    do
                    {
                        if (input == "Name:")
                        {
                            input = reader.ReadLine();
                            if (!childMenu.PositionsMenuList.Contains(input))
                            {
                                childList.Add(new Child(input));
                                childMenu.PositionsMenuList.Add(input);
                            }
                            index++;
                        }
                        else if (input != "" && !childList[index].CollectionOfCrayons.Contains(input))
                        {
                            childList[index].CollectionOfCrayons.Add(input);
                        }
                        input = reader.ReadLine();
                    } while (input != null);
                }
            }
        }
        catch (Exception e) { Console.WriteLine(e); }
    }
}
