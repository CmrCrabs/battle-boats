namespace BattleBoats
{
    public class Game
    {
        public static void New(Tile[,] PlayerMap)
        {
            GenMap(PlayerMap);
            Display.Render(PlayerMap);
        }

        public static void Load() { }

        public static void Save() { }

        public static Tile[,] GenMap(Tile[,] PlayerMap)
        {
            for (int i = 0; i < Constants.height; i++)
            {
                for (int j = 0; j < Constants.Width; j++)
                {
                    if ((j % 2 == 0 && i % 2 == 0) || (j % 2 == 1 && i % 2 == 1))
                    {
                        PlayerMap[i, j] = Tile.Empty1;
                    }
                    else { PlayerMap[i, j] = Tile.Empty2; }
                }
            }
            return PlayerMap;
        }
    }
}
