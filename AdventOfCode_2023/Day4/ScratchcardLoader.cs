using System.Text.RegularExpressions;

namespace AdventOfCode_2023.Day4;

public class ScratchcardLoader
{
    const string IdPattern = @"([\d]+):";
    private const string NumberMatcher = @"(\d{1,2} )";
    
    public static List<Scratchcard> CreateScratchcardsFromInput(string[] input)
    {
        var listOfScratchcards = new List<Scratchcard>();
        foreach (var line in input)
        {
            var scratchcard = ReturnScratchcard(line);
            listOfScratchcards.Add(scratchcard);
        }

        return listOfScratchcards;
    }
    
    public static Dictionary<int, List<Scratchcard>> CreateScratchcardDictionaryFromInput(string[] input)
    {
        var listOfScratchcards = new Dictionary<int, List<Scratchcard>>();
        foreach (var line in input)
        {
            var scratchcard = ReturnScratchcard(line);
            listOfScratchcards.Add(scratchcard.Id, new List<Scratchcard>(){scratchcard});
        }

        return listOfScratchcards;
    }

    private static Scratchcard ReturnScratchcard(string line)
    {
        // adding a space at the end to make my life easier when regexing
        var lineValue = line + " ";
            
        var id = int.Parse(Regex.Match(lineValue, IdPattern).Groups[1].Value);
        var numberCollection = lineValue.Split(":")[1].Split("|");
        var numbers = Regex.Matches(numberCollection[1], NumberMatcher)
            .Select(v => int.Parse(v.ToString()))
            .ToList();
        var winningNumbers = Regex.Matches(numberCollection[0], NumberMatcher)
            .Select(v => int.Parse(v.ToString()))
            .ToList();
        var scratchcard = new Scratchcard(id, numbers, winningNumbers);
        return scratchcard;
    }
}