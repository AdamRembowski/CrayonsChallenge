namespace CrayonsChallenge
{
    public class Crayons
    {
        public List<string> color()
        {
            string fileName = "Colors.txt";
            List<string> Color = new List<string>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    int i = 0;
                    while (line != null)
                    {
                        Color.Add(line);
                        i++;
                        line = reader.ReadLine();
                    }
                }
            }
            return Color;
        }
    }
 }
