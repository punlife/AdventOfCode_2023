using System.Text;

namespace AdventOfCode_2023.Day16;

public class MirrorMap
{
    public char[,] Map { get; private set; }

    public int MapXLength { get; }
    public int MapYLength { get; }
    
    public HashSet<string> EnergisedCells { get; }
    public MirrorMap(char[,] map)
    {
        Map = map;
        EnergisedCells = new HashSet<string>();

        MapYLength = map.GetLength(0);
        MapXLength = map.GetLength(1);
    }

    public void TrackLaser(Coordinate coordinate)
    {
        var keepSearching = true;
        while (keepSearching)
        {
            if (!ProcessCharacter(coordinate))
                break;
            keepSearching = coordinate.Direction switch
            {
                LaserDirection.UP => GoUp(coordinate),
                LaserDirection.DOWN => GoDown(coordinate),
                LaserDirection.LEFT => GoLeft(coordinate),
                LaserDirection.RIGHT => GoRight(coordinate),
                _ => keepSearching
            };
        }
    }

    private bool ProcessCharacter(Coordinate coordinate)
    {
        try
        {
            var value = Map[coordinate.Y, coordinate.X];
            EnergisedCells.Add($"{coordinate.Y},{coordinate.X}");
            switch (value)
            {
                case '|' or '-':
                    ProcessSplitter(coordinate, value is '-');
                    break;
                case '\\' or '/':
                    ProcessMirror(coordinate, value is '/');
                    break;
            }

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    private void ProcessMirror(Coordinate coordinate, bool forwardSlash)
    {
        if (forwardSlash)
        {
            switch (coordinate.Direction)
            {
                case LaserDirection.UP:
                    coordinate.Direction = LaserDirection.RIGHT;
                    coordinate.X += 1;
                    break;
                case LaserDirection.DOWN:
                    coordinate.Direction = LaserDirection.LEFT;
                    coordinate.X -= 1;
                    break;
                case LaserDirection.LEFT:
                    coordinate.Direction = LaserDirection.DOWN;
                    coordinate.Y += 1;
                    break;
                case LaserDirection.RIGHT:
                    coordinate.Direction = LaserDirection.UP;
                    coordinate.Y -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            switch (coordinate.Direction)
            {
                case LaserDirection.UP:
                    coordinate.Direction = LaserDirection.LEFT;
                    coordinate.X -= 1;
                    break;
                case LaserDirection.DOWN:
                    coordinate.Direction = LaserDirection.RIGHT;
                    coordinate.X += 1;
                    break;
                case LaserDirection.LEFT:
                    coordinate.Direction = LaserDirection.UP;
                    coordinate.Y -= 1;
                    break;
                case LaserDirection.RIGHT:
                    coordinate.Direction = LaserDirection.DOWN;
                    coordinate.Y += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
    private void ProcessSplitter(Coordinate coordinate, bool horizontal)
    {
        switch (horizontal)
        {
            case true when !(coordinate.Direction is LaserDirection.LEFT or LaserDirection.RIGHT):
                Task.Run(() => TrackLaser(new Coordinate(coordinate.X - 1, coordinate.Y, LaserDirection.LEFT)));
                Task.Run(() => TrackLaser(new Coordinate(coordinate.X + 1, coordinate.Y, LaserDirection.RIGHT)));
                break;
            case false when !(coordinate.Direction is LaserDirection.UP or LaserDirection.DOWN):
                Task.Run(() => TrackLaser(new Coordinate(coordinate.X, coordinate.Y - 1, LaserDirection.UP)));
                Task.Run(() => TrackLaser(new Coordinate(coordinate.X, coordinate.Y + 1, LaserDirection.DOWN)));
                break;
        }
    }
    
    private bool GoUp(Coordinate coordinate)
    {
        if (coordinate.Y == 0)
        {
            return false;
        }
        coordinate.Y -= 1;
        return true;
    }
    
    private bool GoDown(Coordinate coordinate)
    {
        if (coordinate.Y >= MapYLength-1)
        {
            return false;
        }
        coordinate.Y += 1;
        return true;
    }
    
    private bool GoLeft(Coordinate coordinate)
    {
        if (coordinate.X == 0)
        {
            return false;
        }
        coordinate.X-= 1;
        return true;
    }
    
    private bool GoRight(Coordinate coordinate)
    {
        if (coordinate.X >= MapXLength-1)
        {
            return false;
        }
        coordinate.X += 1;
        return true;
    }

    public void PrintMap()
    {
        var mapToPrint = Map;

        foreach (var coord in EnergisedCells)
        {
            var coords = coord.Split(',');
            mapToPrint[int.Parse(coords[0]), int.Parse(coords[1])] = '#';
        }

        var sb = new StringBuilder();
        for (var i = 0; i < mapToPrint.GetLength(0); i++) 
        { 
            for (var j = 0; j < mapToPrint.GetLength(1); j++) 
            { 
                sb.Append(mapToPrint[i, j]); 
            }

            sb.Append(System.Environment.NewLine);
        }  
        Console.WriteLine(sb.ToString());
    }
}