namespace BattleBoats
{
    class Program
    {
        static void Main(string[] args)
        {
            Tile[,] PlayerMap = new Tile[Constants.height, Constants.Width];
            Tile[,] ComputerMap = new Tile[Constants.height, Constants.Width];
            Menu.ShowMenu(PlayerMap, ComputerMap);
        }
    }
}
