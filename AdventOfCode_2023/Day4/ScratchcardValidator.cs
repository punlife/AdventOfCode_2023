namespace AdventOfCode_2023.Day4;

public class ScratchcardValidator
{
    
    public ScratchcardValidator()
    { 
    }

    public int ValidateScratchcard(Scratchcard scratchcard)
    {
        var pointsToAdd = 1;
        var points = 0;
        foreach (var number in scratchcard.ChosenNumbers)
        {
            if (!scratchcard.WinningNumbers.Contains(number)) continue;

            // 0
            if (points == 0)
            {
                points += pointsToAdd;
            }
            else 
            {
                points += pointsToAdd;
                pointsToAdd *= 2;
            }
        }

        return points;
    }
    
    public int ValidateScratchcardT2(Scratchcard scratchcard)
    {
        var matchedNumbers = 0;
        foreach (var number in scratchcard.ChosenNumbers)
        {
            if (!scratchcard.WinningNumbers.Contains(number)) continue;

            matchedNumbers += 1;
        }

        return matchedNumbers;
    }
    
    public int ValidateScratchcards(List<Scratchcard> scratchcard)
    {
        return scratchcard.Select(ValidateScratchcard).Sum();
    }
    
    public int ValidateScratchcardsT2(Dictionary<int, List<Scratchcard>> scratchcards)
    {
        foreach (var key in scratchcards.Keys)
        {
            foreach (var scratchcard in scratchcards[key])
            {
                var id = scratchcard.Id;
                var number = ValidateScratchcardT2(scratchcard);

                AddDuplicateScratchcards(scratchcards, id, number);
            }
        }

        return scratchcards.Values.Select(l => l.Count).Sum();
    }

    public void AddDuplicateScratchcards(Dictionary<int, List<Scratchcard>> scratchcards, int scratchcardId, int duplicateNumber)
    {
        for (int i = 1; i <= duplicateNumber; i++)
        {
            var updatedId = scratchcardId + i;

            if (scratchcards.TryGetValue(updatedId, out var scratchcardList))
            {
                scratchcardList.Add(scratchcardList[0]);
            }
        }
    }
}