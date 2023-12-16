using System.Text;
using Serilog;

namespace AdventOfCode_2023.Day15;

public class Day15Runner : IDayRunner
{
    // Day 15

    public int ExecuteTask1(string[] input)
    {
        Log.Information("Day15:Task1");
        var hashes = HashLoader.LoadHashesFromInput(input);
        var results = new List<int>();

        foreach (var hash in hashes)
        {
            var hashResult = 0;
            for (int i =0; i < hash.Length; i++) 
            {
                var value = (int) hash[i];
                hashResult += value;
                hashResult *= 17;
                hashResult %= 256;
            }
            results.Add(hashResult);
        }
        
        var result = results.Sum();
        return result;
    }

    public int ExecuteTask2(string[] input)
    {
        Log.Information("Day15:Task2");
    
        var result = 0;
        return result;
    }
}