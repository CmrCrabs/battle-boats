namespace BattleBoats
{
    // The head of a fleet would be the captain so it makes sense
    public abstract class Captain
    {
        public Tile[,] Map;
        public abstract Tile[,] SetShipPos(Tile[,] Map);
        public abstract (int, int) ChooseTarget();
        public bool Hit() { return false; }
        public bool Sunk() { return false; }
        public bool Victory() { return false; }

        public Captain()
        {
            this.Map = new Tile[Constants.height, Constants.Width];
        }
    }
}
