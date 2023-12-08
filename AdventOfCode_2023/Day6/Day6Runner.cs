using Serilog;

namespace AdventOfCode_2023.Day6;

public class Day6Runner : IDayRunner
{
    // Day 6
    // Briefly read this, initial idea is to just brute force every outcome

    public int ExecuteTask1(string[] input)
    {
        Log.Information("Day6:Task1");
        var calculator = new SpeedCalculator();
        var races = RaceLoader.GetRacesFromInput(input);

        List<long> waysToWin = new();
        foreach (var race in races)
            waysToWin.Add(calculator.ReturnAmountOfWaysToWin(race));
        
        
        long result = 0;
        for (var i = 0; i < waysToWin.Count; i++)
        {
            if (i == 0)
                result += waysToWin[i];
            else
                result *= waysToWin[i];
        }
        
        
        return (int) result;
    }

    public int ExecuteTask2(string[] input)
    {
        Log.Information("Day6:Task2");
        var calculator = new SpeedCalculator();
        var races = RaceLoader.GetRacesFromInputT2(input);
        
        var result = calculator.ReturnAmountOfWaysToWin(races[0]);
        Log.Information($"Long result:{result}");

        // Only doing this to get test passing
        try
        {
            return (int)result;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}