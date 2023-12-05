using Serilog;

namespace AdventOfCode_2023;

public interface IDayRunner
{
    public void ExecuteTasks(string[] input)
    {
        Log.Information($"Result: {ExecuteTask1(input)}");
        Log.Information($"Result: {ExecuteTask2(input)}");
    }

    int ExecuteTask1(string[] input);
    int ExecuteTask2(string[] input);
}