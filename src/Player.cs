namespace BattleBoats
{
    public class Player : Captain
    {
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
    }
}
