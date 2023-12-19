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
        public struct boat
        {
            public int quantity;
            public int length;
        }
        public List<boat> Fleet = new List<boat>()
        {
          new boat() {quantity = 1, length = 4},
          new boat() {quantity = 2, length = 3},
          new boat() {quantity = 3, length = 2},
        };
    }
}
