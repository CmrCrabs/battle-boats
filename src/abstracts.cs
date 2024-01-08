namespace BattleBoats
{
    // The head of a fleet would be the captain so it makes sense
    public abstract class Captain
    {
        public Tile[,] Map;
        public abstract Tile[,] SetShipPos(Tile[,] Map, Tile[,] Map2);
        public abstract (int, int) ChooseTarget();

        public bool CoordinateIsValid((int, int) Coordinate, Tile[,] PlayerMap, bool Rotation, int length)
        {
            bool valid = false;

            switch (Rotation)
            {
                case true:
                    if ((Coordinate.Item1 < Constants.Height && Coordinate.Item1 >= 0) && ((Coordinate.Item2 + length) <= Constants.Width && Coordinate.Item2 >= 0)) { valid = true; }
                    break;

                case false:
                    if (((Coordinate.Item1 + length) <= Constants.Height && Coordinate.Item1 >= 0) && (Coordinate.Item2 < Constants.Width && Coordinate.Item2 >= 0)) { valid = true; }
                    break;
            }
            return valid;
        }

        public bool PlacementIsValid(Tile[,] PlayerMap, bool Rotation, (int, int) Coordinate, int length)
        {
            bool valid = false;
            switch (Rotation)
            {
                case true:
                    for (int i = 0; i < length; i++)
                    {
                        if ((PlayerMap[Coordinate.Item1, Coordinate.Item2 + i] != Tile.Boat)) { valid = true; };
                    }
                    break;
                case false:
                    for (int i = 0; i < length; i++)
                    {
                        if ((PlayerMap[Coordinate.Item1 + i, Coordinate.Item2] != Tile.Boat)) { valid = true; };
                    }
                    break;
            }
            return valid;
        }

        public bool RotationIsValid(bool Rotation, (int, int) Coordinate, int length)
        {
            bool valid = false;
            switch (Rotation)
            {
                case true:
                    if ((Coordinate.Item1 + length) <= Constants.Height) { valid = true; }
                    break;
                case false:
                    if ((Coordinate.Item2 + length) <= Constants.Width) { valid = true; }
                    break;
            }
            return valid;
        }

        public bool Hit() { return false; }
        public bool Sunk() { return false; }
        public bool Victory() { return false; }

        public Captain()
        {
            this.Map = new Tile[Constants.Height, Constants.Width];
        }
    }
}
