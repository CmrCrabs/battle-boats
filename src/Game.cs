namespace BattleBoats
{
    public class Data
    {
        public Tile[,] PlayerMap = new Tile[Constants.Height, Constants.Width];
        public Tile[,] ComputerMap = new Tile[Constants.Height, Constants.Width];
        public List<Captain.BoatMap> PlayerFleetMap = new List<Captain.BoatMap>();
        public List<Captain.BoatMap> ComputerFleetMap = new List<Captain.BoatMap>();
    }

    public class Game
    {
        public static void NewGame()
        {
            Data data = new Data();
            GenMap(data.PlayerMap);
            GenMap(data.ComputerMap);

            Player player = new Player();
            data.PlayerMap = player.SetShipPos(data);

            Computer computer = new Computer();
            data.ComputerMap = computer.SetShipPos(data);

            Game.Run(player, computer, data);
        }

        public static void LoadGame()
        {
            Data data = Load.LoadGame();
            Player player = new Player();
            Computer computer = new Computer();
            Game.Run(player, computer, data);
        }

        public static void Run(Player player, Computer computer, Data data)
        {
            // while true is valid here as passing back a endflag is more bloat then while (true) 
            while (true) // <-- peak
            {
                player.Turn(data);
                computer.Turn(data);
                Display.Draw(data.PlayerMap, "Your Board", "Above Are The Results Of The Computers Turn");
                Console.WriteLine("Press Any Key To Begin Firing");
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Escape) { Save.SaveGame(data); Menu.ShowGameMenu(data); }
            }
        }

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
