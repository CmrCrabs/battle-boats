namespace BattleBoats
{
    public class Menu
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu:\n1 - New Game\n2 - Load Game\n3 - View Instructions\n4- Quit");

            var choice = Console.ReadKey();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    Game.NewGame();
                    break;
                case ConsoleKey.D2:
                    Game.LoadGame();
                    break;
                case ConsoleKey.D3:
                    ReadInstructions();
                    while (true)
                    {
                        var input = Console.ReadKey();
                        if (input.Key == ConsoleKey.Escape) { break; }
                        Menu.ReadInstructions();
                    }
                    Menu.ShowMenu();
                    break;
                case ConsoleKey.D4:
                    System.Environment.Exit(-1);
                    break;
                default:
                    Menu.ShowMenu();
                    Console.WriteLine("bad input");
                    break;
            }

        }
        public static void ReadInstructions()
        {
            Console.Clear();
            Console.WriteLine(File.ReadAllText(Constants.InstructionsPath));
            Console.WriteLine("Esc - Return To Main Menu");
        }
        public static void ShowGameMenu(Data data)
        {
            Console.Clear();
            Console.WriteLine("Menu:\n1 - Continue Game\n2 - View Instructions\n3- Save & Quit");

            var choice = Console.ReadKey();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    Game.LoadGame();
                    break;
                case ConsoleKey.D2:
                    ReadInstructions();
                    var input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Escape) { Menu.ShowGameMenu(data); }
                    break;
                case ConsoleKey.D3:
                    Save.SaveGame(data);
                    System.Environment.Exit(-1);
                    break;
                default:
                    Console.WriteLine("bad input");
                    break;
            }

        }
    }
}
