using System.Collections;

namespace AdventOfCode_2023.Day7;

public class HandComparer : IComparer<IHand>
{
    // Ascending
    public int Compare(IHand? x, IHand? y)
    {
        // If hand types are equal check card by card
        if (x.GetHandValue() > y.GetHandValue())
            return 1;
        if (x.GetHandValue() < y.GetHandValue())
            return -1;
        
        return CompareNCards(x, y);
    }

    private int CompareNCards(IHand x, IHand y)
    {
        for (var i = 0; i < x.GetCards().Count; i++)
        {
            var xCard = x.GetCards()[i];
            var yCard = y.GetCards()[i];
            
            if (xCard > yCard)
                return 1;
            else if (xCard < yCard)
                return -1;
            
        }
        // Shouldn't really get here unless there is an edge case/duplicate hands
        return 0;
    }
}