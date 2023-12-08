using System.Text.RegularExpressions;

namespace AdventOfCode_2023.Day6;

public class RaceLoader
{
    private const string NumberMatcher = @"(\d{1,4} )";

    public static List<Race> GetRacesFromInput(string[] input)
    {
        var races = new List<Race>();

        var times = Regex.Matches(input[0], NumberMatcher)
            .Select(v => int.Parse(v.ToString()))
            .ToList();
        var distances = Regex.Matches(input[1],NumberMatcher)
            .Select(v => int.Parse(v.ToString()))
            .ToList();

        for (var i = 0; i < times.Count; i++)
        {
            races.Add(new Race(times[i], distances[i]));
        }

        return races;
    }
    
    public static List<Race> GetRacesFromInputT2(string[] input)
    {
        var races = new List<Race>();

        var time = long.Parse(input[0].Replace(" ", "").Replace("Time:", ""));
        var distance =  long.Parse(input[1].Replace(" ", "").Replace("Distance:", ""));
        
        races.Add(new Race(time, distance));

        return races;
    }
    
}