namespace BattleBoats
{
    public class Game
    {
        public static void New(Tile[,] PlayerMap, Tile[,] ComputerMap)
        {
            GenMap(PlayerMap);
            GenMap(ComputerMap);

            Player player = new Player();
            List<Captain.BoatMap> PlayerFleetMap = new List<Captain.BoatMap>();
            PlayerMap = player.SetShipPos(PlayerMap, ComputerMap, PlayerFleetMap);
            Computer computer = new Computer();
            List<Captain.BoatMap> ComputerFleetMap = new List<Captain.BoatMap>();
            ComputerMap = computer.SetShipPos(ComputerMap, PlayerMap, ComputerFleetMap);

            // while true is valid here as passing back a endflag is more bloat then while (true) 
            while (true) // <-- peak
            {
                player.Turn(ComputerFleetMap, PlayerMap, ComputerMap);
                computer.Turn(PlayerFleetMap, ComputerMap, PlayerMap);
                // Display.Draw(PlayerMap, "Computers Turn..");
                Display.Draw(ComputerMap, "real");
                Console.WriteLine(" Press Any Key To Continue");
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Escape) { Menu.ShowGameMenu(PlayerMap, ComputerMap); }
            }
        }

        public static void Load() { }

        public static void Save() { }

        public static Tile[,] GenMap(Tile[,] Map)
        {
            for (int i = 0; i < Constants.Height; i++)
            {
                for (int j = 0; j < Constants.Width; j++)
                {
                    if ((j % 2 == 0 && i % 2 == 0) || (j % 2 == 1 && i % 2 == 1))
                    {
                        Map[i, j] = Tile.Empty1;
                    }
                    else { Map[i, j] = Tile.Empty2; }
                }
            }
            return Map;
        }

    }
}
