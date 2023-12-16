namespace AdventOfCode_2023.Day9;

public class Sequence
{
    public List<long> Numbers { get; private set; }

    public Sequence(List<long> numbers)
    {
        Numbers = numbers;
    }

    public long GetNextInTheSequence()
    {
        var allEqual = false;
        var sequenceLists = new List<List<long>> { Numbers };
        var numbers = Numbers;
        while (!allEqual)
        {
            var difference = GetDifferenceSequence(numbers);
            sequenceLists.Add(difference);
            numbers = difference;
            if (AreAllNumbersEqual(difference))
            {
                allEqual = true;
            }
        }
        
        // Flow up using the calculated table
        var sequenceListLength = sequenceLists.Count;
        var differenceToAdd = sequenceLists[sequenceListLength-1][0];
        for (var i = sequenceListLength - 2; i >= 0; i--)
        {
            var listLength = sequenceLists[i].Count;
            var currentFinalValue = sequenceLists[i][listLength - 1];
            differenceToAdd = currentFinalValue + differenceToAdd;
            sequenceLists[i].Add(differenceToAdd);
        }

        return sequenceLists[0][sequenceLists[0].Count - 1];
    }

    private List<long> GetDifferenceSequence(List<long> numberSequence)
    {
        var differenceSequence = new List<long>();
        var sequenceLength = numberSequence.Count;
        for (int i = 0; i < sequenceLength; i++)
        {
            if (i < sequenceLength && i + 1 < sequenceLength)
                differenceSequence.Add(numberSequence[i+1] - numberSequence[i]);
        }

        return differenceSequence;
    }

    private bool AreAllNumbersEqual(List<long> numbers)
    {
        var firstItem = numbers[0];
        return numbers
            .Skip(1)
            .All(n => firstItem == n);
    }
}