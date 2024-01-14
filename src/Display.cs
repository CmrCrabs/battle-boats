namespace BattleBoats
{
    public class Display
    {
        public static void Draw(Tile[,] PlayerMap, string text)
        {
            // decorations are currently hardcoded but I will make them not hardcoded in future
            // make look better NOW.
            // output a Color Key 
            Console.Clear();
            Console.WriteLine("       " + text);
            Console.WriteLine("_|_______________________|_ ");
            for (int i = 0; i < Constants.Height; i++)
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
            Console.WriteLine("-|-----------------------|-");
            Console.WriteLine("       /          \\");
            Console.WriteLine("     _/_          _\\_");
            Console.WriteLine("\n     Esc - Main Menu");
        }

        public static void DrawClearMap(Tile[,] Map, string text)
        {
            Tile[,] TempMap = new Tile[Constants.Height, Constants.Width];
            Game.GenMap(TempMap);

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    // potentially use switch here, but yeah
                    if (Map[i, j] == Tile.Miss) { TempMap[i, j] = Tile.Miss; }
                    else if (Map[i, j] == Tile.Wreckage) { TempMap[i, j] = Tile.Wreckage; }
                    else if (Map[i, j] == Tile.Hit) { TempMap[i, j] = Tile.Hit; }
                }
            }

            Display.Draw(TempMap, text);
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
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case Tile.Wreckage:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Tile.Hit:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Tile.Miss:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case Tile.Using:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
            }

        }


    }
}
