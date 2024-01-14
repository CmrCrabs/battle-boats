namespace BattleBoats
{
    // The head of a fleet would be the captain so it makes sense
    public abstract class Captain
    {
        public struct BoatMap
        {
            public (int, int) Coordinate;
            public int Length;
            public bool Rotation;
            public bool Sunk;
        }

        public Tile[,] Map;
        public abstract void Turn(List<BoatMap> FleetMap, Tile[,] Map1, Tile[,] Map2);
        public abstract Tile[,] SetShipPos(Tile[,] Map, Tile[,] Map2, List<BoatMap> FleetMap);
        public abstract (int, int) ChooseTarget(Tile[,] Map, Tile[,] Map2);

        public bool CoordinateIsValid((int, int) Coordinate, Tile[,] Map, bool Rotation, int length)
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

        public bool PlacementIsValid(Tile[,] Map, bool Rotation, (int, int) Coordinate, int length)
        {
            bool valid = false;
            switch (Rotation)
            {
                case true:
                    for (int i = 0; i < length; i++)
                    {
                        if ((Map[Coordinate.Item1, Coordinate.Item2 + i] != Tile.Boat)) { valid = true; } else { valid = false; break; };
                    }
                    break;
                case false:
                    for (int i = 0; i < length; i++)
                    {
                        if ((Map[Coordinate.Item1 + i, Coordinate.Item2] != Tile.Boat)) { valid = true; } else { valid = false; break; };
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

        public bool Hit(Tile[,] Map, (int, int) Coordinate)
        {
            bool hit = false;
            if (Map[Coordinate.Item1, Coordinate.Item2] == Tile.Boat)
            {
                hit = true;
                Map[Coordinate.Item1, Coordinate.Item2] = Tile.Hit;
            }
            return hit;
        }

        // most of the code doesnt run unless its needed to so the performance isnt too bad
        public bool Sunk(List<BoatMap> FleetMap, Tile[,] Map, (int, int) Coordinate)
        {
            bool sunk = false;
            int j = 0;
            var BufferFleet = new List<BoatMap>();
            BufferFleet.AddRange(FleetMap);

            foreach (var boat in BufferFleet)
            {
                switch (boat.Rotation)
                {
                    case true:
                        for (int i = 0; i < boat.Length; i++)
                        {
                            if (Map[boat.Coordinate.Item1, boat.Coordinate.Item2 + i] == Tile.Hit) { sunk = true; } else { sunk = false; break; }
                        }
                        break;
                    case false:
                        for (int i = 0; i < boat.Length; i++)
                        {
                            if (Map[boat.Coordinate.Item1 + i, boat.Coordinate.Item2] == Tile.Hit) { sunk = true; } else { sunk = false; break; }
                        }
                        break;
                }
                if (sunk)
                {
                    switch (boat.Rotation)
                    {
                        case true:
                            for (int i = 0; i < boat.Length; i++) { Map[boat.Coordinate.Item1, boat.Coordinate.Item2 + i] = Tile.Wreckage; }
                            break;
                        case false:
                            for (int i = 0; i < boat.Length; i++) { Map[boat.Coordinate.Item1 + i, boat.Coordinate.Item2] = Tile.Wreckage; }
                            break;
                    }
                    var BufferBoat = FleetMap[j];
                    BufferBoat.Sunk = true;
                    FleetMap[j] = BufferBoat;
                    break;
                }
                j++;
            }
            return sunk;
        }
        // only checked upon sinking of a boat so does not need to be overly performant
        public bool Victory(List<BoatMap> FleetMap, Tile[,] Map)
        {
            bool victory = true;
            foreach (var boat in FleetMap)
            {
                if (boat.Sunk == false)
                {
                    victory = false;
                }
            }
            return victory;
        }

        public Captain()
        {
            this.Map = new Tile[Constants.Height, Constants.Width];
        }
    }
}
