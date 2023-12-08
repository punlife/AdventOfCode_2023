namespace AdventOfCode_2023.Day5;

public class Condition
{
    public long Input;
    public long Output;
    public long Range;
    public long Shift; // Difference between input/output
    
    public Condition(long input, long output, long range)
    {
        Input = input;
        Output = output;
        Range = range;
        Shift = output - input;
    }
}