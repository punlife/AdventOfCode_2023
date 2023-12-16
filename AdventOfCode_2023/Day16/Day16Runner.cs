using Serilog;

namespace AdventOfCode_2023.Day16;

public class Day16Runner : IDayRunner
{
    // Day 16

    public int ExecuteTask1(string[] input)
    {
        Log.Information("Day16:Task1");
        var mirrorMap = new MirrorMap(MapLoader.LoadMap(input));
        mirrorMap.TrackLaser(new Coordinate());
        mirrorMap.PrintMap();
        var result = mirrorMap.EnergisedCells.Count;
        return result;
    }

    public int ExecuteTask2(string[] input)
    {
        Log.Information("Day16:Task2");
        var mirrorMap = new MirrorMap(MapLoader.LoadMap(input));
        var coordinatesToTest = new List<Coordinate>();
        var results = new List<int>();
        // Setup all start points
        for (int i = 0; i < mirrorMap.MapXLength; i++)
        {
            coordinatesToTest.Add(new Coordinate(i, 0, LaserDirection.DOWN));
            coordinatesToTest.Add(new Coordinate(i, mirrorMap.MapYLength-1, LaserDirection.UP));
        }
        for (int i = 0; i < mirrorMap.MapYLength; i++)
        {
            coordinatesToTest.Add(new Coordinate(0, i, LaserDirection.RIGHT));
            coordinatesToTest.Add(new Coordinate(mirrorMap.MapXLength-1, i, LaserDirection.LEFT));
        }

        foreach (var coordinate in coordinatesToTest)
        {
            mirrorMap.TrackLaser(coordinate);
            results.Add(mirrorMap.EnergisedCells.Count);
            
            // Clear existing containers before next iteration
            mirrorMap.EnergisedCells.Clear();
            mirrorMap.LaserOriginPoints.Clear();
        }
        
        var result = results.Max();
        return result;
    }
}