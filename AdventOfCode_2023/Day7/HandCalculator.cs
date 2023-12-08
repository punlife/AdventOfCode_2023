namespace AdventOfCode_2023.Day7;

public class HandCalculator
{
    public static HandType GetBaseHandValue(Hand hand)
    {
        // Just trying to make it easy for myself to spot pairs 
        var frequencyOfFrequencies = new Dictionary<int, int>();
        var orderedFrequencies = hand.GetCardsFrequency().Values.OrderDescending().ToList();

        foreach (var orderedFrequency in orderedFrequencies)
        {
            if (frequencyOfFrequencies.ContainsKey(orderedFrequency))
                frequencyOfFrequencies[orderedFrequency] += 1;
            else 
                frequencyOfFrequencies.Add(orderedFrequency, 1);
        }
        
        var highestTypeSoFar = HandType.HIGH_CARD;
        foreach (var frequency in orderedFrequencies)
        {
            if (frequency is 5)
            {
                highestTypeSoFar = HandType.FIVE_OF_A_KIND;
                break;
            } 
            else if (frequency is 4)
            {
                highestTypeSoFar = HandType.FOUR_OF_A_KIND;
                break;
            } 
            else if (frequency is 3 )
            {
                highestTypeSoFar = frequencyOfFrequencies.ContainsKey(2)
                    ? HandType.FULL_HOUSE
                    : HandType.THREE_OF_A_KIND;
                break;
            }
            else if (frequency is 2 && frequencyOfFrequencies.ContainsKey(3))
            {
                highestTypeSoFar = HandType.FULL_HOUSE;
                break;
            }
            else if (frequency is 2)
            {
                highestTypeSoFar = frequencyOfFrequencies[2] == 2
                    ? HandType.TWO_PAIR
                    : HandType.ONE_PAIR;
                
            }
       
        }

        return highestTypeSoFar;
    }
    
    public static HandType GetBaseHandValueT2(HandT2 hand)
    {
        // Just trying to make it easy for myself to spot pairs 
        var frequencyOfFrequencies = new Dictionary<int, int>();
        var orderedFrequencies = hand.GetCardsFrequency().Values.OrderDescending().ToList();

        foreach (var orderedFrequency in orderedFrequencies)
        {
            if (frequencyOfFrequencies.ContainsKey(orderedFrequency))
                frequencyOfFrequencies[orderedFrequency] += 1;
            else 
                frequencyOfFrequencies.Add(orderedFrequency, 1);
        }
        
        var highestTypeSoFar = HandType.HIGH_CARD;
        foreach (var frequency in orderedFrequencies)
        {
            if (frequency is 5)
            {
                highestTypeSoFar = HandType.FIVE_OF_A_KIND;
                break;
            } 
            else if (frequency is 4)
            {
                highestTypeSoFar = HandType.FOUR_OF_A_KIND;
                break;
            } 
            else if (frequency is 3 )
            {
                highestTypeSoFar = frequencyOfFrequencies.ContainsKey(2)
                    ? HandType.FULL_HOUSE
                    : HandType.THREE_OF_A_KIND;
                break;
            }
            else if (frequency is 2 && frequencyOfFrequencies.ContainsKey(3))
            {
                highestTypeSoFar = HandType.FULL_HOUSE;
                break;
            }
            else if (frequency is 2)
            {
                highestTypeSoFar = frequencyOfFrequencies[2] == 2
                    ? HandType.TWO_PAIR
                    : HandType.ONE_PAIR;
                
            }
       
        }

        return highestTypeSoFar;
    }
}