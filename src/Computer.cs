namespace BattleBoats
{
    public class Computer : Captain
    {
        public override void Turn(List<BoatMap> FleetMap, Tile[,] ComputerMap, Tile[,] PlayerMap)
        {
            (int, int) Coordinate = ChooseTarget(ComputerMap, PlayerMap);
            if (Hit(PlayerMap, Coordinate))
            {
                if (Sunk(FleetMap, PlayerMap, Coordinate))
                {
                    if (Victory(FleetMap, PlayerMap))
                    {
                        while (true)
                        {
                            Console.WriteLine("crying cat emoji!!!");
                        }
                    }
                }
            }
            else
            {
                PlayerMap[Coordinate.Item1, Coordinate.Item2] = Tile.Miss;
            }
        }
        public override Tile[,] SetShipPos(Tile[,] ComputerMap, Tile[,] PlayerMap, List<BoatMap> FleetMap)
        {
            foreach (var boat in Constants.Fleet)
            {
                for (int i = 0; i < boat.quantity; i++)
                {
                    bool placed = false;
                    while (!placed)
                    {
                        Random rand = new Random();
                        (int, int) Coordinate = (rand.Next(0, Constants.Width), rand.Next(0, Constants.Height));

                        bool rotation = rand.NextDouble() >= 0.5;

                        if (
                              CoordinateIsValid(Coordinate, ComputerMap, rotation, boat.length)
                              && PlacementIsValid(ComputerMap, rotation, Coordinate, boat.length)
                              && RotationIsValid(rotation, Coordinate, boat.length)
                            )
                        {

                            var boatmap = new BoatMap();
                            boatmap.Coordinate = Coordinate;
                            boatmap.Length = boat.length;
                            boatmap.Rotation = rotation;
                            FleetMap.Add(boatmap);
                            switch (rotation)
                            {
                                case true:
                                    for (int j = 0; j < boat.length; j++) { ComputerMap[Coordinate.Item1, Coordinate.Item2 + j] = Tile.Boat; }
                                    break;

                                case false:
                                    for (int j = 0; j < boat.length; j++) { ComputerMap[Coordinate.Item1 + j, Coordinate.Item2] = Tile.Boat; }
                                    break;
                            }
                            placed = true;

                        }
                    }

                }
            }
            return ComputerMap;
        }
        public override (int, int) ChooseTarget(Tile[,] ComputerMap, Tile[,] PlayerMap)
        {
            bool TargetSelected = false;
            (int, int) Coordinate = (0, 0);
            while (!TargetSelected)
            {
                Random rand = new Random();
                Coordinate = (rand.Next(0, Constants.Width), rand.Next(0, Constants.Height));
                if ((Coordinate.Item1 >= 0 && Coordinate.Item1 < Constants.Height) && (Coordinate.Item2 >= 0 && Coordinate.Item2 < Constants.Width) && (ComputerMap[Coordinate.Item1, Coordinate.Item2] != Tile.Hit || ComputerMap[Coordinate.Item1, Coordinate.Item2] != Tile.Wreckage)) { TargetSelected = true; }
            }
            return Coordinate;
        }
    }
}
