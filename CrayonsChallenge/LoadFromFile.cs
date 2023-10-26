﻿using System.Reflection.PortableExecutable;
using CrayonsChallenge;

public class LoadFromFile : ILoadFromFile
{
    public LoadFromFile()
    {
    }
    List<string> crayons = new Crayons().Color;
    public void ActivateOption(ref ShowMenu childMenu, ref List<Child> childList)
    {
        try
        {
            using (var reader = File.OpenText("output.txt"))
            {
                var child = new Child();

                var input = reader.ReadLine();

                if (input == "Name:")
                {
                    do
                    {
                        input = reader.ReadLine();
                        if (input != null &&
                            input != "Name:" &&
                            input != "" &&
                            !childMenu.PositionsMenuList.Contains(input) &&
                            !crayons.Contains(input))
                        {
                            child = new Child(input);
                            childMenu.PositionsMenuList.Add(input);
                            childList.Add(child);                            
                            LoadCrayons(reader, input, child);
                        }
                        else if (input != null &&
                            input != "Name:" &&
                            input != "" &&
                            childMenu.PositionsMenuList.Contains(input))
                        {
                            foreach (Child item in childList)
                            {
                                if (item.Name == input) child = item;
                            }
                            LoadCrayons(reader, input, child);
                        }

                    }
                    while (input != null);
                }
            }
        }
        catch (Exception e) { Console.WriteLine(e); }
    }

    private void LoadCrayons(StreamReader reader, string input, Child child)
    {
        input = reader.ReadLine();
        do
        {
            if (input == "Name:" || input == null)
            {
                break;
            }
            else if (input != "" && !child.CollectionOfCrayons.Contains(input))
            {
                child.CollectionOfCrayons.Add(input);
            }
            input = reader.ReadLine();
        } while (true);
    }
}
