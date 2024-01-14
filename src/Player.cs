namespace BattleBoats
{
    public class Player : Captain
    {
        public override void Turn(List<BoatMap> FleetMap, Tile[,] PlayerMap, Tile[,] ComputerMap)
        {
            (int, int) Coordinate = ChooseTarget(PlayerMap, ComputerMap);
            if (Hit(ComputerMap, Coordinate))
            {
                if (Sunk(FleetMap, ComputerMap, Coordinate))
                {
                    Console.WriteLine("YIPPIE");
                    if (Victory(FleetMap, ComputerMap))
                    {
                        while (true)
                        {
                            Console.WriteLine("yippie!!!");
                        }
                    }
                }
            }
            else
            {
                ComputerMap[Coordinate.Item1, Coordinate.Item2] = Tile.Miss;
            }
        }

        public override Tile[,] SetShipPos(Tile[,] PlayerMap, Tile[,] ComputerMap, List<BoatMap> FleetMap)
        {
            foreach (var boat in Constants.Fleet)
            {
                for (int j = 0; j < boat.quantity; j++)
                {
                    Tile[,] BufferMap = new Tile[Constants.Height, Constants.Width];
                    for (int m = 0; m < Constants.Height; m++)
                    {
                        for (int n = 0; n < Constants.Width; n++)
                        {
                            BufferMap[m, n] = PlayerMap[m, n];
                        }
                    }

                    for (int i = 0; i < boat.length; i++) { BufferMap[i, 0] = Tile.Using; }
                    (int, int) Coordinate = (0, 0);
                    (int, int) Prev_Coordinate = (0, 0);

                    bool placed = false;
                    bool rotation = false;
                    while (!placed)
                    {
                        Prev_Coordinate = Coordinate;
                        Display.Draw(BufferMap, "Placing Boats");

                        var input = Console.ReadKey();
                        switch (input.Key)
                        {
                            case ConsoleKey.Enter:
                                if (PlacementIsValid(PlayerMap, rotation, Coordinate, boat.length)) { placed = true; }
                                break;

                            case ConsoleKey.W:
                            case ConsoleKey.UpArrow:
                                if (CoordinateIsValid((Coordinate.Item1 - 1, Coordinate.Item2), PlayerMap, rotation, boat.length)) { Coordinate.Item1 -= 1; };
                                break;

                            case ConsoleKey.A:
                            case ConsoleKey.LeftArrow:
                                if (CoordinateIsValid((Coordinate.Item1, Coordinate.Item2 - 1), PlayerMap, rotation, boat.length)) { Coordinate.Item2 -= 1; };
                                break;

                            case ConsoleKey.S:
                            case ConsoleKey.DownArrow:
                                if (CoordinateIsValid((Coordinate.Item1 + 1, Coordinate.Item2), PlayerMap, rotation, boat.length)) { Coordinate.Item1 += 1; };
                                break;

                            case ConsoleKey.D:
                            case ConsoleKey.RightArrow:
                                if (CoordinateIsValid((Coordinate.Item1, Coordinate.Item2 + 1), PlayerMap, rotation, boat.length)) { Coordinate.Item2 += 1; };
                                break;

                            case ConsoleKey.Escape:
                                Menu.ShowGameMenu(PlayerMap, ComputerMap);
                                break;
                            case ConsoleKey.R:
                                if (RotationIsValid(rotation, Coordinate, boat.length))
                                {
                                    rotation ^= true;
                                    switch (rotation)
                                    {
                                        case true:
                                            for (int i = 0; i < boat.length; i++) { BufferMap[Prev_Coordinate.Item1 + i, Prev_Coordinate.Item2] = PlayerMap[Prev_Coordinate.Item1 + i, Prev_Coordinate.Item2]; }
                                            break;
                                        case false:
                                            for (int i = 0; i < boat.length; i++) { BufferMap[Prev_Coordinate.Item1, Prev_Coordinate.Item2 + i] = PlayerMap[Prev_Coordinate.Item1, Prev_Coordinate.Item2 + i]; }
                                            break;
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                        switch (rotation)
                        {
                            case true:
                                for (int i = 0; i < boat.length; i++) { BufferMap[Prev_Coordinate.Item1, Prev_Coordinate.Item2 + i] = PlayerMap[Prev_Coordinate.Item1, Prev_Coordinate.Item2 + i]; }
                                for (int i = 0; i < boat.length; i++) { BufferMap[Coordinate.Item1, Coordinate.Item2 + i] = Tile.Using; }
                                break;

                            case false:
                                for (int i = 0; i < boat.length; i++) { BufferMap[Prev_Coordinate.Item1 + i, Prev_Coordinate.Item2] = PlayerMap[Prev_Coordinate.Item1 + i, Prev_Coordinate.Item2]; }
                                for (int i = 0; i < boat.length; i++) { BufferMap[Coordinate.Item1 + i, Coordinate.Item2] = Tile.Using; }
                                break;
                        }

                        if (placed)
                        {
                            switch (rotation)
                            {
                                case true:
                                    for (int i = 0; i < boat.length; i++) { PlayerMap[Coordinate.Item1, Coordinate.Item2 + i] = Tile.Boat; }
                                    break;

                                case false:
                                    for (int i = 0; i < boat.length; i++) { PlayerMap[Coordinate.Item1 + i, Coordinate.Item2] = Tile.Boat; }
                                    break;
                            }
                            var boatmap = new BoatMap();
                            boatmap.Coordinate = Coordinate;
                            boatmap.Length = boat.length;
                            boatmap.Rotation = rotation;
                            FleetMap.Add(boatmap);
                        }
                    }
                }
            }
            return PlayerMap;
        }


        public override (int, int) ChooseTarget(Tile[,] PlayerMap, Tile[,] ComputerMap)
        {
            bool TargetSelected = false;
            (int, int) Coordinate = (0, 0);
            (int, int) Prev_Coordinate = (0, 0);
            Tile[,] BufferMap = new Tile[Constants.Height, Constants.Width];
            Game.GenMap(BufferMap);
            Tile[,] EmptyMap = new Tile[Constants.Height, Constants.Width];
            Game.GenMap(EmptyMap);
            for (int i = 0; i < ComputerMap.GetLength(0); i++)
            {
                for (int j = 0; j < ComputerMap.GetLength(1); j++)
                {
                    // potentially use switch here, but yeah
                    if (ComputerMap[i, j] == Tile.Miss) { EmptyMap[i, j] = Tile.Miss; }
                    else if (ComputerMap[i, j] == Tile.Wreckage) { EmptyMap[i, j] = Tile.Wreckage; }
                    else if (ComputerMap[i, j] == Tile.Hit) { EmptyMap[i, j] = Tile.Hit; }
                }
            }
            BufferMap = (Tile[,])EmptyMap.Clone();
            BufferMap[Coordinate.Item1, Coordinate.Item2] = Tile.Using;

            while (!TargetSelected)
            {
                Prev_Coordinate = Coordinate;
                Display.Draw(BufferMap, "Choosing Target");
                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.Enter:
                        if ((Coordinate.Item1 < Constants.Height && Coordinate.Item1 >= 0) && ((Coordinate.Item2) <= Constants.Width && Coordinate.Item2 >= 0) && (ComputerMap[Coordinate.Item1, Coordinate.Item2] != Tile.Hit || ComputerMap[Coordinate.Item1, Coordinate.Item2] != Tile.Wreckage || ComputerMap[Coordinate.Item1, Coordinate.Item2] != Tile.Hit))
                        {
                            TargetSelected = true;
                        }
                        break;

                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (Coordinate.Item1 > 0) { Coordinate.Item1 -= 1; }
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if ((Coordinate.Item2 > 0)) { Coordinate.Item2 -= 1; }
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (Coordinate.Item1 < (Constants.Height - 1)) { Coordinate.Item1 += 1; }
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (Coordinate.Item2 < (Constants.Width - 1)) { Coordinate.Item2 += 1; }
                        break;

                    case ConsoleKey.Escape:
                        Menu.ShowGameMenu(PlayerMap, ComputerMap);
                        break;

                    default:
                        break;
                }

                BufferMap[Prev_Coordinate.Item1, Prev_Coordinate.Item2] = EmptyMap[Prev_Coordinate.Item1, Prev_Coordinate.Item2];
                BufferMap[Coordinate.Item1, Coordinate.Item2] = Tile.Using;
            }


            return Coordinate;
        }
    }
}
