namespace AdventOfCode_2023.Day15;

public class HashLoader
{
    public static List<string> LoadHashesFromInput(string[] input)
    {
        var hashes = new List<string>();
        foreach (var line in input)
        {
            hashes.AddRange(line.Split(','));
        }
        return hashes;
    }
}