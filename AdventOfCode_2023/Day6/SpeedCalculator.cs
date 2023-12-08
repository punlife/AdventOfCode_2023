namespace AdventOfCode_2023.Day6;

public class SpeedCalculator
{
    public long ReturnAmountOfWaysToWin(Race race)
    {
        var waysToWin = 0;
        for (var i = 1; i < race.Time; i++)
        {
            var speed = i;
            var remainingTime = race.Time - i;
            var distance = speed * remainingTime;

            if (distance > race.Distance)
                waysToWin += 1;
        }
        
        return waysToWin;
    }
}