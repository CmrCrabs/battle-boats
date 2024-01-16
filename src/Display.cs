namespace BattleBoats
{
    public class Display
    {
        public static void Draw(Tile[,] PlayerMap, string text, string log)
        {
            // decorations are currently hardcoded but I will make them not hardcoded in future
            // make look better NOW.
            // output a Color Key 
            Array enumValues = Enum.GetValues(typeof(Tile));
            List<Tile> ColourKey = new List<Tile>();
            for (int i = 0; i < enumValues.Length; i++)
            {
                Tile tile = (Tile)enumValues.GetValue(i);
                ColourKey.Add(tile);
            }
            if (Constants.Height - enumValues.Length > 0)
            {
                for (int i = 0; i < (Constants.Height - enumValues.Length); i++)
                {
                    ColourKey.Add(Tile.Buffer);
                }
            }

            Console.Clear();
            Console.WriteLine("       " + text);
            Console.WriteLine("_|_______________________|_ "); for (int i = 0; i < Constants.Height; i++)
            {
                Console.Write(" |");
                for (int j = 0; j < Constants.Width; j++)
                {
                    SetColor(PlayerMap[i, j]);
                    Console.Write("■");
                    Console.ResetColor();
                    Console.Write(" |");
                }
                Console.Write("          ");
                SetColor(ColourKey[i]);
                Console.Write("■");
                Console.ResetColor();
                switch (ColourKey[i])
                {
                    case Tile.Buffer: break;
                    case Tile.Empty1: case Tile.Empty2: Console.Write("Ocean"); break;
                    default: Console.Write($"{Enum.GetName(typeof(Tile), ColourKey[i])}"); break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("-|-----------------------|-");
            Console.WriteLine("       /          \\");
            Console.WriteLine("     _/_          _\\_");
            Console.WriteLine("\n    Esc - Main Menu");
            if (string.IsNullOrEmpty(log))
            {
                Console.WriteLine("Incoming Message: No Message");
            }
            else
            {
                Console.WriteLine("Incoming Message: " + log);
            }

            static void SetColor(Tile Tile)
            {
                // use the il
                switch (Tile)
                {
                    case Tile.Empty1:
                        Console.ForegroundColor = ConsoleColor.Blue; break;
                    case Tile.Empty2:
                        Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                    case Tile.Boat:
                        Console.ForegroundColor = ConsoleColor.DarkGray; break;
                    case Tile.Wreckage:
                        Console.ForegroundColor = ConsoleColor.Black; break;
                    case Tile.Hit:
                        Console.ForegroundColor = ConsoleColor.Red; break;
                    case Tile.Miss:
                        Console.ForegroundColor = ConsoleColor.Magenta; break;
                    case Tile.Using:
                        Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                    case Tile.Buffer: Console.ForegroundColor = ConsoleColor.Black; break;
                }

            }


        }
    }
}
