namespace BattleBoats
{
    public class Computer : Captain
    {
        public static void Turn() { }
        public override Tile[,] SetShipPos(Tile[,] ComputerMap)
        {
            return ComputerMap;
        }
        public override (int, int) ChooseTarget()
        {
            int x = 0;
            int y = 0;
            return (x, y);
        }
    }
}
