namespace BattleBoats
{
    public enum Tile
    {
        Empty1,
        Empty2,
        Boat,
        Wreckage,
        Hit,
        Miss,
        Using,
    }

    public class Constants
    {
        public const int Width = 8;
        public const int height = 8;
        public const string InstructionsPath = "./Documentation/Instructions.txt";
    }

    // The head of a fleet would be the captain so it makes sense
    public abstract class Captain
    {

        // public Tile[,] ComputerMap = new Tile[Constants.height, Constants.Width];
        // public Tile[,] PlayerMap = new Tile[Constants.height, Constants.Width];
        public Tile[,] Map = new Tile[Constants.height, Constants.Width];
        public abstract Tile[,] SetShipPos(Tile[,] Map);
        public abstract (int, int) ChooseTarget();
        public abstract bool CheckHit();
        public abstract bool CheckSunk();
        public abstract bool CheckVictory();
    }


}
