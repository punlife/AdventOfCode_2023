using System.Text.RegularExpressions;

namespace AdventOfCode_2023.Day2;

public class DataLoader
{
    string idPattern = @"Game ([\d]+)";
    string bluePattern = @"([0-9]+) blue";
    string greenPattern = @"([0-9]+) green";
    string redPattern = @"([0-9]+) red";

    public List<Game> CreateGamesFromInput(string[] input)
    {
        var games = new List<Game>();
        
        foreach (var line in input)
        {
            games.Add(CreateGameFromInputLine(line));
        }

        return games;
    }
    
    
    public Game CreateGameFromInputLine(string input)
    {
        var idMatch = Regex.Match(input, idPattern);
        var setsInput = input.Split(":")[1];
        var sets = CreateGameSetsFromInputLine(setsInput);

        if (int.TryParse(idMatch.Groups[1].Value, out var id))
        {
            return new Game()
            {
                Id = id,
                Sets = sets
            };
        }

        throw new Exception();
    }

    public List<GameSet> CreateGameSetsFromInputLine(string input)
    {
        var setsInput = input.Split(";");
        var setsOutput = new List<GameSet>();

        foreach (var set in setsInput)
        {
            var redMatch = Regex.Match(set, redPattern);
            var greenMatch = Regex.Match(set, greenPattern);
            var blueMatch = Regex.Match(set, bluePattern);


            var gameSet = new GameSet()
            {
                Red = redMatch.Success ? int.Parse(redMatch.Groups[1].Value) : 0,
                Green = greenMatch.Success ? int.Parse(greenMatch.Groups[1].Value) : 0,
                Blue = blueMatch.Success ? int.Parse(blueMatch.Groups[1].Value) : 0,
            };
            setsOutput.Add(gameSet);
        }

        return setsOutput;
    }
}