namespace AdventOfCode_2023;

public interface IDayRunner
{
    public void ExecuteTasks(string[] input)
    {
        ExecuteTask1(input);
        ExecuteTask2(input);
    }
    
    void ExecuteTask1(string[] input);
    void ExecuteTask2(string[] input);
}