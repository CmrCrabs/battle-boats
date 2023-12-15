namespace BattleBoats
{
    public class Player : Captain
    {
        public Tile[,] PlayerMap = new Tile[Constants.height, Constants.Width];
        public static void Turn() { }
        public override Tile[,] SetShipPos(Tile[,] PlayerMap)
        {
            return PlayerMap;
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
        public override bool CheckSunk()
        {
            return false;
        }
        public override bool CheckVictory()
        {
            return false;
        }
    }
}
