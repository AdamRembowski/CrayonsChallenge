using CrayonsChallenge;

public class LoadFromFile : ILoadFromFile
{
    public LoadFromFile()
    {
    }
    public void ActivateOption(ref ShowMenu ChildMenu, ref List<Child>ChildList)
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
                            if (!ChildMenu.PositionsMenuList.Contains(input))
                            {
                                ChildList.Add(new Child(input));
                                ChildMenu.PositionsMenuList.Add(input);
                            }
                            index++;
                        }
                        else if (input != "" && !ChildList[index].CollectionOfCrayons.Contains(input))
                        {
                            ChildList[index].CollectionOfCrayons.Add(input);
                        }
                        input = reader.ReadLine();
                    } while (input != null);
                }
            }
        }
        catch (Exception e) { Console.WriteLine(e); }
    }
}
