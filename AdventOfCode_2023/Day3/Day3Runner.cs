using AdventOfCode_2023.Day2;
using Serilog;

namespace AdventOfCode_2023.Day3;

public class Day3Runner : IDayRunner
{
    // Day 3
    // Create a 2D Array to act as a map
    // Find all unique symbols, remove digits and ".", form a set of allowed values from that
    // Iterate through each row until a number is found,
    // discover all digits and note down coordinates,
    // for each coordinate check vicinity
    // if symbol found note it down

    
    public void ExecuteTask1(string[] input)
    {
        Log.Information("Day3:Task1");
        
        var validator = new SchematicValidator();
        validator.PopulateAllowedCharacters(input);
        var engine = new EngineMap(validator, input);
        var partNumbers = engine.TraverseMap();
        var numbers = partNumbers.Select(int.Parse).ToList();
     
        Log.Information($"Result: {numbers.Sum()}");
    }

    public void ExecuteTask2(string[] input)
    {
       Log.Information("Day3:Task2");
       
        var validator = new SchematicValidator();
        validator.PopulateAllowedCharacters(new[]{"*"});
        var engine = new EngineMap(validator, input);
        var partNumbers = engine.TraverseMapT2();
       
        Log.Information($"Result: {partNumbers.Sum()}");
    }

    // Only for testing
    public int ReturnSum(string[] input)
    {
        var validator = new SchematicValidator();
        validator.PopulateAllowedCharacters(input);
        var engine = new EngineMap(validator, input);
        var partNumbers = engine.TraverseMap();
        var numbers = partNumbers.Select(int.Parse).ToList();
        return numbers.Sum();
    }
    
    public int ReturnGear(string[] input)
    {
        var validator = new SchematicValidator();
        validator.PopulateAllowedCharacters(input);
        var engine = new EngineMap(validator, input);
        var partNumbers = engine.TraverseMapT2();
        return partNumbers.Sum();
    }
}