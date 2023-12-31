﻿namespace CrayonsChallenge
{
    public class Crayons
    {
        public List<string> Colors
        {
            get
            {
                string fileName = "Colors.txt";
                List<string> color = new List<string>();
                if (File.Exists(fileName))
                {
                    using (var reader = File.OpenText(fileName))
                    {
                        string? line = reader.ReadLine();
                        int i = 0;
                        while (line != null)
                        {
                            color.Add(line);
                            i++;
                            line = reader.ReadLine();
                        }
                    }
                }
                return color;
            }
        }
        public const int Count = 16;
    }
}
