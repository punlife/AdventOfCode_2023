namespace AdventOfCode_2023.Day3;

public class SchematicValidator
{
    public HashSet<char> AllowedCharacters { get; } = new();
    
    public void PopulateAllowedCharacters(string[] input)
    {
        foreach (var line in input)
        {
            foreach (var character in line)
            {
                if (Char.IsDigit(character) || character.Equals('.'))
                    continue;

                AllowedCharacters.Add(character);
            }
        }
    }
    
    
}