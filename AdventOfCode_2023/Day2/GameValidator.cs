namespace AdventOfCode_2023.Day2;

public class GameValidator
{
    public int MaxRed { get; private set; }
    public int MaxGreen { get; private set; }
    public int MaxBlue  { get; private set; }

    public GameValidator(int maxRed, int maxGreen, int maxBlue)
    {
        MaxRed = maxRed;
        MaxGreen = maxGreen;
        MaxBlue = maxBlue;
    }

    public bool IsSetValid(GameSet set)
    {
        return set.Red <= MaxRed && set.Green <= MaxGreen && set.Blue <= MaxBlue;
    }
    
    public bool IsGameValid(Game game)
    {
        return game.Sets.All(IsSetValid);
    }
    
    public List<Game> ReturnValidGames(List<Game> games)
    {
        return games.Where(g => IsGameValid(g)).ToList();
    }
    
    public List<int> ReturnThePowersForGames(List<Game> games)
    {
        var gamePowers = new List<int>();
        foreach (var game in games)
        {
            var minRed = 0;
            var minGreen = 0;
            var minBlue = 0;
            
            foreach (var set in game.Sets)
            {
                if (set.Red > minRed)
                    minRed = set.Red;
                
                if (set.Green > minGreen)
                    minGreen = set.Green;
                
                if (set.Blue > minBlue)
                    minBlue = set.Blue;
            }
            
            gamePowers.Add(minRed * minGreen * minBlue);
        }

        return gamePowers;
    }
    
    
}