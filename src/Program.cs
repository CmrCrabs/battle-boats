namespace BattleBoats
{
    class Program
    {
        static void Main(string[] args)
        {
            Tile[,] PlayerMap = new Tile[Constants.Height, Constants.Width];
            Tile[,] ComputerMap = new Tile[Constants.Height, Constants.Width];
            Menu.ShowMenu(PlayerMap, ComputerMap);
        }
    }
}
