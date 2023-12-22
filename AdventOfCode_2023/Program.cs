// See https://aka.ms/new-console-template for more information

using AdventOfCode_2023;
using AdventOfCode_2023.Day10;
using AdventOfCode_2023.Day11;
using AdventOfCode_2023.Day12;
using AdventOfCode_2023.Day13;
using AdventOfCode_2023.Day14;
using AdventOfCode_2023.Day15;
using AdventOfCode_2023.Day16;
using AdventOfCode_2023.Day17;
using AdventOfCode_2023.Day18;
using AdventOfCode_2023.Day19;
using AdventOfCode_2023.Day2;
using AdventOfCode_2023.Day20;
using AdventOfCode_2023.Day21;
using AdventOfCode_2023.Day22;
using AdventOfCode_2023.Day23;
using AdventOfCode_2023.Day24;
using AdventOfCode_2023.Day25;
using AdventOfCode_2023.Day3;
using AdventOfCode_2023.Day4;
using AdventOfCode_2023.Day5;
using AdventOfCode_2023.Day6;
using AdventOfCode_2023.Day7;
using AdventOfCode_2023.Day8;
using AdventOfCode_2023.Day9;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Console.WriteLine("Hello, Advent of code 2023!");

// ((IDayRunner) new Day1Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day1Input.txt"));
// ((IDayRunner) new Day2Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day2Input.txt"));
// ((IDayRunner) new Day3Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day3Input.txt"));
// ((IDayRunner) new Day4Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day4Input.txt"));
// ((IDayRunner) new Day5Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day5Input.txt"));
// ((IDayRunner) new Day6Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day6Input.txt"));
// ((IDayRunner) new Day7Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day7Input.txt"));
((IDayRunner) new Day8Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day8Input.txt"));
// ((IDayRunner) new Day9Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day9Input.txt"));
// ((IDayRunner) new Day10Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day10Input.txt"));
// ((IDayRunner) new Day11Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day12Input.txt"));
// ((IDayRunner) new Day12Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day13Input.txt"));
// ((IDayRunner) new Day13Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day14Input.txt"));
// ((IDayRunner) new Day14Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day15Input.txt"));
// ((IDayRunner) new Day15Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day16Input.txt"));
// ((IDayRunner) new Day16Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day15Input.txt"));
// ((IDayRunner) new Day17Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day16Input.txt"));
// ((IDayRunner) new Day18Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day15Input.txt"));
// ((IDayRunner) new Day19Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day16Input.txt"));
// ((IDayRunner) new Day20Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day15Input.txt"));
// ((IDayRunner) new Day21Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day16Input.txt"));
// ((IDayRunner) new Day22Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day15Input.txt"));
// ((IDayRunner) new Day23Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day16Input.txt"));
// ((IDayRunner) new Day24Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day15Input.txt"));
// ((IDayRunner) new Day25Runner()).ExecuteTasks(File.ReadAllLines(@"Data\Day16Input.txt"));

Console.ReadLine();