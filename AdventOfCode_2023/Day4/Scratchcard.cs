namespace AdventOfCode_2023.Day4;

public class Scratchcard
{
    public int Id { get; private set; }
    public List<int> ChosenNumbers { get; private set; }

    public HashSet<int> WinningNumbers { get; private set; }
    public Scratchcard(int id, List<int> chosenNumbers, List<int> winningNumbers)
    {
        Id = id;
        ChosenNumbers = chosenNumbers;
        WinningNumbers = new HashSet<int>(winningNumbers);
    }
    
}