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
    
        var result = 0;
        return result;
    }
}