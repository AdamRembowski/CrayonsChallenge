namespace CrayonsChallenge
{
    public class AddChild
    {
        public AddChild(ref ShowMenu whatMenu)
        {
            WhatMenu = whatMenu;
        }
        ShowMenu WhatMenu { get; set; }
        public Child? ActivateOption()
        {
            string input = "";
            ControlInfo();
            Console.WriteLine("Podaj imię dziecka:");
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                Console.Clear();
                ControlInfo();
                Console.WriteLine("Podaj imię dziecka:");
                if (Char.IsLetter(keyInfo.KeyChar) && keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                        input += keyInfo.KeyChar;
                        Console.Write(input);     
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length>0)
                {                   
                    input = input.Remove(input.Length - 1,1);
                    Console.Write(input);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (input != null && input != "")                    
                        {
                        WhatMenu.PositionsMenuList.Add(input);
                        return new Child(input);
                    }                     
                }
                else if (!Char.IsLetter(keyInfo.KeyChar))
                {
                    Console.Write(input);
                }
            }
            return null;
        }
        public void ControlInfo()
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
            Console.SetCursorPosition(0, 0);
        }            
    }
}
