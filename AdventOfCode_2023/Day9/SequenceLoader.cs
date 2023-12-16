namespace AdventOfCode_2023.Day9;

public class SequenceLoader
{
    public static List<Sequence> GetSequencesFromInput(string[] input)
    {
        var values = new List<Sequence>();
        foreach (var line in input)
            values.Add(new Sequence(line.Split(" ").Select(long.Parse).ToList()));
        
        return values;
    }
    
    public static List<Sequence> GetSequencesFromInputT2(string[] input)
    {
        var values = new List<Sequence>();
        foreach (var line in input)
        {
            var numbers = line.Split(" ").Select(long.Parse).ToList();
            numbers.Reverse();
            values.Add(new Sequence(numbers));
        }

        return values;
    }
}