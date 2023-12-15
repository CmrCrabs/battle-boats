namespace BattleBoats
{
    public class Computer : Captain
    {
        public Tile[,] ComputerMap = new Tile[Constants.height, Constants.Width];
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
        public override bool CheckHit()
        {
            return false;
        }
        public override bool CheckVictory()
        {
            return false;
        }
    }

}
