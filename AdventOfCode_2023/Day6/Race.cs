namespace AdventOfCode_2023.Day6;

public class Race
{
    public long Time { get; }
    public long Distance { get; }

    public Race(long time, long distance)
    {
        Time = time;
        Distance = distance;
    }
}