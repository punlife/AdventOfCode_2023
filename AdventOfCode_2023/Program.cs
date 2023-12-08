// See https://aka.ms/new-console-template for more information

using AdventOfCode_2023;
using AdventOfCode_2023.Day1;
using AdventOfCode_2023.Day2;
using AdventOfCode_2023.Day3;
using AdventOfCode_2023.Day4;
using AdventOfCode_2023.Day5;
using AdventOfCode_2023.Day6;
using AdventOfCode_2023.Day7;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Console.WriteLine("Hello, Advent of code 2023!");

// Just classes to execute the tasks
IDayRunner day1Runner = new Day1Runner();
IDayRunner day2Runner = new Day2Runner();
IDayRunner day3Runner = new Day3Runner();
IDayRunner day4Runner = new Day4Runner();
IDayRunner day5Runner = new Day5Runner();
IDayRunner day6Runner = new Day6Runner();
IDayRunner day7Runner = new Day7Runner();

// day1Runner.ExecuteTasks(File.ReadAllLines(@"Data\Day1Input.txt"));
// day2Runner.ExecuteTasks(File.ReadAllLines(@"Data\Day2Input.txt"));
// day3Runner.ExecuteTasks(File.ReadAllLines(@"Data\Day3Input.txt"));
// day4Runner.ExecuteTasks(File.ReadAllLines(@"Data\Day4Input.txt"));
// day5Runner.ExecuteTasks(File.ReadAllLines(@"Data\Day5Input.txt"));
// day6Runner.ExecuteTasks(File.ReadAllLines(@"Data\Day6Input.txt"));
day7Runner.ExecuteTasks(File.ReadAllLines(@"Data\Day7Input.txt"));


Console.ReadLine();