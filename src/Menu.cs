namespace BattleBoats
{
    public class Menu
    {
        public static void ShowMenu(Tile[,] PlayerMap)
        {
            Console.Clear();
            Console.WriteLine("Menu:\n1 - New Game\n2 - Load Game\n3 - View Instructions\n4- Quit");

            var choice = Console.ReadKey();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    Game.New(PlayerMap);
                    break;

                case ConsoleKey.D2:
                    Game.Load();
                    break;

                case ConsoleKey.D3:
                    ReadInstructions();
                    var input = Console.ReadKey();
                    if (input.Key == ConsoleKey.Escape) { Menu.ShowMenu(PlayerMap); }
                    break;

                case ConsoleKey.D4:
                    System.Environment.Exit(-1);
                    break;

                default:
                    Console.WriteLine("bad input");
                    break;
            }

            static void ReadInstructions()
            {
                Console.Clear();
                Console.WriteLine(File.ReadAllText(Constants.InstructionsPath));
                Console.WriteLine("Esc - Return To Main Menu");
            }
        }
    }
}
