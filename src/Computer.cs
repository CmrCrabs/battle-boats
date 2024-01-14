namespace BattleBoats
{
    public class Computer : Captain
    {
        public override void Turn(Data data)
        {
            (int, int) Coordinate = ChooseTarget(data);
            if (Hit(data.PlayerMap, Coordinate))
            {
                if (Sunk(data.PlayerFleetMap, data.PlayerMap, Coordinate))
                {
                    if (Victory(data.PlayerFleetMap, data.PlayerMap))
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
                data.PlayerMap[Coordinate.Item1, Coordinate.Item2] = Tile.Miss;
            }
        }
        public override Tile[,] SetShipPos(Data data)
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
                              CoordinateIsValid(Coordinate, data.ComputerMap, rotation, boat.length)
                              && PlacementIsValid(data.ComputerMap, rotation, Coordinate, boat.length)
                              && RotationIsValid(rotation, Coordinate, boat.length)
                            )
                        {

                            var boatmap = new BoatMap();
                            boatmap.Coordinate = Coordinate;
                            boatmap.Length = boat.length;
                            boatmap.Rotation = rotation;
                            data.ComputerFleetMap.Add(boatmap);
                            switch (rotation)
                            {
                                case true:
                                    for (int j = 0; j < boat.length; j++) { data.ComputerMap[Coordinate.Item1, Coordinate.Item2 + j] = Tile.Boat; }
                                    break;

                                case false:
                                    for (int j = 0; j < boat.length; j++) { data.ComputerMap[Coordinate.Item1 + j, Coordinate.Item2] = Tile.Boat; }
                                    break;
                            }
                            placed = true;

                        }
                    }

                }
            }
            return data.ComputerMap;
        }
        public override (int, int) ChooseTarget(Data data)
        {
            bool TargetSelected = false;
            (int, int) Coordinate = (0, 0);
            while (!TargetSelected)
            {
                Random rand = new Random();
                Coordinate = (rand.Next(0, Constants.Width), rand.Next(0, Constants.Height));
                if ((Coordinate.Item1 >= 0 && Coordinate.Item1 < Constants.Height) && (Coordinate.Item2 >= 0 && Coordinate.Item2 < Constants.Width) && (data.ComputerMap[Coordinate.Item1, Coordinate.Item2] != Tile.Hit || data.ComputerMap[Coordinate.Item1, Coordinate.Item2] != Tile.Wreckage)) { TargetSelected = true; }
            }
            return Coordinate;
        }
    }
}
