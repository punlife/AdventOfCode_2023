using Serilog;

namespace AdventOfCode_2023.Day1;

public class Day1Runner : IDayRunner
{
    
    // Day 1
    // For T1, look until a digit is found, put all digits into a string grab first and last and parse
    // For T2 traverse the string from front/back until a numerical value or text value is recognized, break and return 

    public void ExecuteTask1(string[] input)
    {
        var textProcessor = new TextProcessor();
        Log.Information("Day1:Task1");
        Log.Information($"Result: {textProcessor.ProcessTaskOneText(input)}");
    }

    public void ExecuteTask2(string[] input)
    {
        var textProcessor = new TextProcessor();
        Log.Information("Day1:Task2");
        Log.Information($"Result: {textProcessor.ProcessTaskTwoText(input)}");
    }
}