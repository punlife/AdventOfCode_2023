using Serilog;

namespace AdventOfCode_2023.Day4;

public class Day4Runner : IDayRunner
{
    // Day 4
    // Pretty simple and comfy task, not much to explain
    // T2 didn't really require much extra work outside of just creating the duplicates
    public int ExecuteTask1(string[] input)
    {
        Log.Information("Day4:Task1");
        var scratchcardValidator = new ScratchcardValidator();
        var scratchcards = ScratchcardLoader.CreateScratchcardsFromInput(input);
        var result = scratchcardValidator.ValidateScratchcards(scratchcards);

        return result;
    }

    public int ExecuteTask2(string[] input)
    {
        Log.Information("Day4:Task2");
        // Basically same as above, create a dictionary based on ID (change ID to int), increment through IDs to create copies 
        var scratchcardValidator = new ScratchcardValidator();
        var scratchcards = ScratchcardLoader.CreateScratchcardDictionaryFromInput(input);
        var result = scratchcardValidator.ValidateScratchcardsT2(scratchcards);
  
        return result;
    }
}