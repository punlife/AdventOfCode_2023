// See https://aka.ms/new-console-template for more information

using AdventOfCode_2023.Day1;
using AdventOfCode_2023.Day2;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Console.WriteLine("Hello, Advent of code 2023!");

// Day 1
var textProcessor = new TextProcessor();
Log.Information("Day1:Task1");
Log.Information($"Result: {textProcessor.ProcessTaskOneText(File.ReadAllLines(@"Day1\Day1Input.txt"))}");
Log.Information("Day1:Task2");
Log.Information($"Result: {textProcessor.ProcessTaskTwoText(File.ReadAllLines(@"Day1\Day1Input.txt"))}");

// Day 2
var dataLoader = new DataLoader();
var gameValidator = new GameValidator(12, 13, 14);

Log.Information("Day2:Task1");
var games = dataLoader.CreateGamesFromInput(File.ReadAllLines(@"Day2\Day2Input.txt"));
var validGames = gameValidator.ReturnValidGames(games);
Log.Information($"Result: {validGames.Select(v => v.Id).Sum()}");

Log.Information("Day2:Task2");
var powers = gameValidator.ReturnThePowersForGames(games);
Log.Information($"Result: {powers.Sum()}");


Console.ReadLine();