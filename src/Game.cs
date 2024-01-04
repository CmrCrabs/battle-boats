namespace BattleBoats
{
    public class Game
    {
        public static void New(Tile[,] PlayerMap, Tile[,] ComputerMap)
        {
            GenMap(PlayerMap);
            GenMap(ComputerMap);
            Player player = new Player();
            PlayerMap = player.SetShipPos(PlayerMap);
            bool playerTurn = true;
            while (true)
            {
                if (playerTurn) { Player.Turn(); }
                else { Computer.Turn(); }
                playerTurn ^= true;

                Display.Draw(PlayerMap);
                Thread.Sleep(100);

                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Escape) { Menu.ShowGameMenu(PlayerMap, ComputerMap); }
            }
        }

        public static void Load() { }

        public static void Save() { }

        public static Tile[,] GenMap(Tile[,] Map)
        {
            for (int i = 0; i < Constants.height; i++)
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
