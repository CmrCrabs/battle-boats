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
        public const int Width = 8; public const int Height = 8;
        public const string InstructionsPath = "./Documentation/Instructions.txt";
        public const string SaveGamePath = "./savegame.json";
        public const int WindowWidth = 100;
        public const int WindowHeight = 100;
        public struct boat
        {
            public int quantity;
            public int length;
        }
        public static readonly List<boat> Fleet = new List<boat>()
        {
          new boat() {quantity = 2, length = 4},
          new boat() {quantity = 1, length = 3},
          new boat() {quantity = 1, length = 2},
        };
    }
}
