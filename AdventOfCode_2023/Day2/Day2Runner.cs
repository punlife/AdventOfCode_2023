using AdventOfCode_2023.Day1;
using Serilog;

namespace AdventOfCode_2023.Day2;

public class Day2Runner : IDayRunner
{
    // Day 2
    // I don't think this one needs much explanation
    // Form Game/Set objects go through each set, check if within bounds if so sum game IDs
    // For T2 just iterate and increase variable anytime a set within a game requires more of X colour
    
    public int ExecuteTask1(string[] input)
    {
        var dataLoader = new DataLoader();
        var gameValidator = new GameValidator(12, 13, 14);
        
        Log.Information("Day2:Task1");
        var games = dataLoader.CreateGamesFromInput(input);
        var validGames = gameValidator.ReturnValidGames(games);
        var result = validGames.Select(v => v.Id).Sum();

        return result;
    }

    public int ExecuteTask2(string[] input)
    {
        var dataLoader = new DataLoader();
        var gameValidator = new GameValidator(12, 13, 14);
        
        Log.Information("Day2:Task2");
        var games = dataLoader.CreateGamesFromInput(input);
        var powers = gameValidator.ReturnThePowersForGames(games);
        var result = powers.Sum();
        
        return result;
    }
}