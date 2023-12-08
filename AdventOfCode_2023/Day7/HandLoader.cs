namespace AdventOfCode_2023.Day7;

public class HandLoader
{
    public List<Hand> LoadHandsFromInput(string[] input)
    {
        var hands = new List<Hand>();
        foreach (var line in input)
        {
            var split = line.Split(" ");
            var cards = CreateCardList(split[0]);
            var bet = int.Parse(split[1]);
            hands.Add(new Hand(cards, bet));
        }

        return hands;
    }
    
    public List<HandT2> LoadHandsFromInputT2(string[] input)
    {
        var hands = new List<HandT2>();
        foreach (var line in input)
        {
            var split = line.Split(" ");
            var cards = CreateCardList(split[0]);
            var bet = int.Parse(split[1]);
            hands.Add(new HandT2(cards, bet));
        }

        return hands;
    }

    private List<Card> CreateCardList(string cardInput)
    {
        var cards = new List<Card>();
        foreach (var card in cardInput)
        {
            cards.Add(card switch
                {
                    'A' => Card.ACE,
                    'K' => Card.KING,
                    'Q' => Card.QUEEN,
                    'J' => Card.JACK,
                    'T' => Card.TEN,
                    '9' => Card.NINE,
                    '8' => Card.EIGHT,
                    '7' => Card.SEVEN,
                    '6' => Card.SIX,
                    '5' => Card.FIVE,
                    '4' => Card.FOUR,
                    '3' => Card.THREE,
                    '2' => Card.TWO,
                    _ => throw new ArgumentOutOfRangeException()
                }
            );
        }

        return cards;
    }
}