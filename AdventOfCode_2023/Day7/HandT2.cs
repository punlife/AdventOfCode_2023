namespace AdventOfCode_2023.Day7;

public class HandT2 : IHand
{
    private List<Card> cards;
    private Dictionary<Card, int> cardFrequency;
    private int bet;
    private HandType handValue;
    
    public HandT2(List<Card> cards, int bet)
    {
        this.cards = cards;
        this.bet = bet;
        this.cardFrequency = new Dictionary<Card, int>();
        foreach (var card in cards)
        {
            if (cardFrequency.ContainsKey(card))
                cardFrequency[card] += 1;
            else 
                cardFrequency.Add(card,1);
        }
        
        // Doing it last since we need to populate card frequency
        handValue = HandCalculator.GetBaseHandValueT2(this);
    }

    public List<Card> GetCards()
    {
        return cards;
    }
    
    public Dictionary<Card, int> GetCardsFrequency()
    {
        return cardFrequency;
    }
    
    public int GetBet()
    {
        return bet;
    }
    
    public HandType GetHandValue()
    {
        return handValue;
    }
}
