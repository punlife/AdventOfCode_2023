namespace AdventOfCode_2023.Day16;

public class MapLoader
{
    public static char[,] LoadMap(string[] input)
    {
        var xLength = input[0].Length;
        var yLength = input.Length;

        var newMap = new char[xLength, yLength];

        for (var i = 0; i < yLength; i++)
        {
            var line = input[i];
            for (var j = 0; j < line.Length; j++)
            {
                newMap[i, j] = line[j];
            }
        }

        return newMap;
    }
}