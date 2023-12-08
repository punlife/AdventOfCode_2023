using Serilog;

namespace AdventOfCode_2023.Day7;

public class Day7Runner : IDayRunner
{
    // Day 7
    // Create objects to contain cards and bid, maybe an assignable point value too so that a comprarer can be used to do it?
    // that way when ranking you can just order them easily and use the object to 

    public int ExecuteTask1(string[] input)
    {
        Log.Information("Day7:Task1");
        var loader = new HandLoader();
        var hands = loader.LoadHandsFromInput(input);
        hands.Sort(0, hands.Count, new HandComparer());
        var result = hands.Select((t, i) => t.GetBet() * (i+1)).Sum();
        return result;
    }

    public int ExecuteTask2(string[] input)
    {
        Log.Information("Day7:Task2");
        var loader = new HandLoader();
        var hands = loader.LoadHandsFromInputT2(input);
        hands.Sort(0, hands.Count, new HandComparer());
        var result = hands.Select((t, i) => t.GetBet() * (i+1)).Sum();
        return result;
    }
}