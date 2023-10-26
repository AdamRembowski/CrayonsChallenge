namespace CrayonsChallenge
{
    public class AddChild : ChooseOption
    {
        public AddChild(ref ShowMenu whatMenu) : base(whatMenu)
        {

        }
        public Child? ActivateOption()
        {
            string input = "";
            var i = 0;
            ControlInfo();
            Console.WriteLine("Podaj imię dziecka:");
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                Console.Clear();
                ControlInfo();
                Console.WriteLine("Podaj imię dziecka:");
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    input += keyInfo.KeyChar;        
                    Console.Write(input);                    
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length>0)
                {                   
                    input = input.Remove(input.Length - 1,1);
                    Console.Write("{0,-35}", input);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (input != null && input != "")
                    {
                        WhatMenu.PositionsMenuList.Add(input);
                        return new Child(input);
                    }                     
                }
            }
            return null;
        }
        public override void ControlInfo()
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("Kliknij klawisz Enter aby potwierdzić wybór, ESC aby wyjść");
            Console.SetCursorPosition(0, 0);
        }            
    }
}
