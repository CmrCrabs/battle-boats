namespace BattleBoats
{
    public class Computer : Captain
    {
        public static void Turn() { }
        public override Tile[,] SetShipPos(Tile[,] ComputerMap, Tile[,] PlayerMap)
        {
            return ComputerMap;
        }
        public override (int, int) ChooseTarget(Tile[,] ComputerMap, Tile[,] PlayerMap)
        {
            int x = 0;
            int y = 0;
            return (x, y);
        }
    }
}
