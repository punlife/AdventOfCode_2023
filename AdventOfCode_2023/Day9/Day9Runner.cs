using Serilog;

namespace AdventOfCode_2023.Day9;

public class Day9Runner : IDayRunner
{
    // Day 9

    public int ExecuteTask1(string[] input)
    {
        Log.Information("Day9:Task1");
        var sequences = SequenceLoader.GetSequencesFromInput(input);
        var longResult = sequences.Select(s => s.GetNextInTheSequence()).Sum();
        Log.Information($"Long result: {longResult}");
        var result = 0;
        try
        {
            result = (int)longResult;
        }
        catch (Exception ex)
        {
            result = 0;
        }

        return result;
    }

    public int ExecuteTask2(string[] input)
    {
        Log.Information("Day9:Task2");
        var sequences = SequenceLoader.GetSequencesFromInputT2(input);
        var longResult = sequences.Select(s => s.GetNextInTheSequence()).Sum();
        Log.Information($"Long result: {longResult}");
        var result = 0;
        try
        {
            result = (int)longResult;
        }
        catch (Exception ex)
        {
            result = 0;
        }
        return result;
    }
}