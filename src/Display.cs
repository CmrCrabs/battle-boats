namespace BattleBoats
{


    public class Display
    {
        public static void Render(Tile[,] PlayerMap)
        {
            // decorations are currently hardcoded but I will make them not hardcoded in future
            Console.Clear();
            Console.WriteLine("       Battle Boats");
            Console.WriteLine("_|_______________________|_ ");
            for (int i = 0; i < Constants.height; i++)
            {
                Console.Write(" |");
                for (int j = 0; j < Constants.Width; j++)
                {
                    SetColor(PlayerMap[i, j]);
                    Console.Write("■");
                    Console.ResetColor();
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
            Console.WriteLine("_|_______________________|_");
            Console.WriteLine("       /          \\");
            Console.WriteLine("     _/_          _\\_");
            Console.WriteLine("\n     Esc - Main Menu");
        }

        static void SetColor(Tile Tile)
        {
            switch (Tile)
            {
                case Tile.Empty1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Tile.Empty2:
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case Tile.Boat:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case Tile.Wreckage:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case Tile.Hit:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Tile.Miss:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case Tile.Using:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }

        }


    }
}
