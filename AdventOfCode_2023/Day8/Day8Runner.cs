using AdventOfCode_2023.Day10;
using Serilog;

namespace AdventOfCode_2023.Day8;

public class Day8Runner : IDayRunner
{
    // Day 8
    // Dictionary of each pointer to next value

    public int ExecuteTask1(string[] input)
    {
        Log.Information("Day8:Task1");
        var loader = new NodeLoader();
        var dictionary = loader.GetNodesFromInput(input, true);

        var startKey = "AAA";
        var searchKey = "ZZZ";
        var stepCounter = 0;
        var currentKey = "AAA";
        while (true)
        {
            var instruction = loader.GetNextInstruction();
            currentKey = instruction.Equals('L')
                ? dictionary[currentKey].LeftKey
                : dictionary[currentKey].RightKey;
            stepCounter++;
            if (currentKey.Equals(searchKey))
                break;
        }

        var result = stepCounter;
        return result;
    }

    public int ExecuteTask2(string[] input)
    {
        Log.Information("Day10:Task2");
        var loader = new NodeLoader();
        var dictionary = loader.GetNodesFromInput(input, false);

        var stepCounter = 0;
        var listOfCurrentKeys = dictionary.Keys
            .Where(k => k[^1].Equals('A'))
            .ToList();

        while (true)
        {
            var instruction = loader.GetNextInstruction();
            Parallel.For(0, listOfCurrentKeys.Count, i =>
            {
                var key = listOfCurrentKeys[i];
                key = instruction.Equals('L')
                    ? dictionary[key].LeftKey
                    : dictionary[key].RightKey;
                listOfCurrentKeys[i] = key;
            });

            stepCounter++;
            Log.Information($"{stepCounter}");
            if (listOfCurrentKeys.All(k => k[^1].Equals('Z')))
                break;
        }

        var result = stepCounter;
        return result;
    }
    
}