namespace AdventOfCode_2023.Day7;

public interface IHand
{
    public List<Card> GetCards();

    public Dictionary<Card, int> GetCardsFrequency();

    public int GetBet();

    public HandType GetHandValue();
}