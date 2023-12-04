namespace AdventOfCode_2023.Day3;

public class EngineMap
{
    public char[,] Schematic { get; }
    public readonly char[,] ImmutableSchematic;
    public SchematicValidator Validator;

    private int XLength;
    private int YLength;


    public Dictionary<string, List<int>> GearToNumberListMap = new();

    public EngineMap(SchematicValidator validator, string[] input)
    {
        Validator = validator;
        Schematic = CreateSchematic(input);
        ImmutableSchematic = CreateSchematic(input);

        XLength = Schematic.GetLength(0);
        YLength = Schematic.GetLength(1);
    }

    private char[,] CreateSchematic(string[] input)
    {
        var xLength = input[0].Length;
        var yLength = input.Length;

        var newSchematic = new char[xLength, yLength];

        for (var i = 0; i < yLength; i++)
        {
            var line = input[i];
            for (var j = 0; j < line.Length; j++)
            {
                newSchematic[i, j] = line[j];
            }
        }

        return newSchematic;
    }

    public List<int> TraverseMapT2()
    {
        var numberList = new List<string>();
        for (int i = 0; i < YLength; i++)
        {
            var lineList = TraverseLineT2(i);
        }
        
        var gearList = GearToNumberListMap.Values
            .Where(l => l.Count == 2)
            .ToList();

        var answerList = new List<int>();
  
        foreach (var gear in gearList)
        {
            var currentGearRatio = 0;
            foreach (var num in gear)
            {
                if (currentGearRatio == 0)
                    currentGearRatio += num;
                else
                    currentGearRatio *= num;
            }
            answerList.Add(currentGearRatio);
        }
        
        return answerList;
    }

    public List<string> TraverseMap()
    {
        var numberList = new List<string>();
        for (int i = 0; i < YLength; i++)
        {
            var lineList = TraverseLine(i);
            numberList.AddRange(lineList);
        }

        return numberList;
    }

    public List<string> TraverseLine(int yIndex)
    {
        var numbers = new List<string>();

        var lastCharDigit = false;
        var coordinatesToUse = new List<int>();
        var completeNumber = "";

        for (int xIndex = 0; xIndex < XLength; xIndex++)
        {
            var value = Schematic[yIndex, xIndex];


            if (Char.IsDigit(value))
            {
                lastCharDigit = true;
                coordinatesToUse.Add(xIndex);
                completeNumber += value;

                // Bit spaghetti to include this here but it's to deal with the case of numbers in final index of the row
                if (xIndex.Equals(XLength - 1))
                {
                    if (ProcessNonDigit(lastCharDigit, coordinatesToUse, yIndex))
                        numbers.Add(completeNumber);
                }
            }
            else if (value.Equals('.') || Validator.AllowedCharacters.Contains(value))
            {
                // Check and save if part number
                if (ProcessNonDigit(lastCharDigit, coordinatesToUse, yIndex))
                    numbers.Add(completeNumber);

                // Reset current
                lastCharDigit = false;
                coordinatesToUse = new List<int>();
                completeNumber = "";
            }
        }

        return numbers;
    }

    public List<string> TraverseLineT2(int yIndex)
    {
        var numbers = new List<string>();

        var lastCharDigit = false;
        var coordinatesToUse = new List<int>();
        var completeNumber = "";

        for (int xIndex = 0; xIndex < XLength; xIndex++)
        {
            var value = Schematic[yIndex, xIndex];

            if (Char.IsDigit(value))
            {
                lastCharDigit = true;
                coordinatesToUse.Add(xIndex);
                completeNumber += value;

                // Bit spaghetti to include this here but it's to deal with the case of numbers in final index of the row
                if (xIndex.Equals(XLength - 1))
                {
                    ProcessGear(lastCharDigit, coordinatesToUse, completeNumber, yIndex);
                }
            }
            else if (value.Equals('.') || Validator.AllowedCharacters.Contains(value))
            {
                // Check and save if part number
                if (ProcessGear(lastCharDigit, coordinatesToUse, completeNumber, yIndex))
                    numbers.Add(completeNumber);

                // Reset current
                lastCharDigit = false;
                coordinatesToUse = new List<int>();
                completeNumber = "";
            }
            else
            {
                lastCharDigit = false;
                coordinatesToUse = new List<int>();
                completeNumber = "";
            }
        }

        return numbers;
    }


    public bool ProcessNonDigit(bool lastCharDigit, List<int> coordinatesToUse, int yIndex)
    {
        if (lastCharDigit)
        {
            foreach (var xCord in coordinatesToUse)
            {
                if (IsValidPartNumber(xCord, yIndex))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool ProcessGear(bool lastCharDigit, List<int> coordinatesToUse, string number, int yIndex)
    {
        if (lastCharDigit)
        {
            foreach (var xCord in coordinatesToUse)
            {
                if (IsValidGearNumber(xCord, yIndex, number))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void AddOrUpdateGear(string gearCoord, string number)
    {
        if (GearToNumberListMap.ContainsKey(gearCoord))
            GearToNumberListMap[gearCoord].Add(int.Parse(number));
        else
            GearToNumberListMap.Add(gearCoord, new List<int>() { int.Parse(number) });
    }

    public bool IsValidPartNumber(int x, int y)
    {
        //N 
        if (CheckNorth(x, y))
            return true;
        // NW
        if (CheckNorthWest(x, y))
            return true;
        // NE
        if (CheckNorthEast(x, y))
            return true;
        // E
        if (CheckEast(x, y))
            return true;
        // SE
        if (CheckSouthEast(x, y))
            return true;
        // S
        if (CheckSouth(x, y))
            return true;
        // SW
        if (CheckSouthWest(x, y))
            return true;
        // W
        if (CheckWest(x, y))
            return true;

        return false;
    }

    public bool IsValidGearNumber(int x, int y, string number)
    {
        //N 
        if (CheckNorth(x, y, true, number))
            return true;
        // NW
        if (CheckNorthWest(x, y, true, number))
            return true;
        // NE
        if (CheckNorthEast(x, y, true, number))
            return true;
        // E
        if (CheckEast(x, y, true, number))
            return true;
        // SE
        if (CheckSouthEast(x, y, true, number))
            return true;
        // S
        if (CheckSouth(x, y, true, number))
            return true;
        // SW
        if (CheckSouthWest(x, y, true, number))
            return true;
        // W
        if (CheckWest(x, y, true, number))
            return true;

        return false;
    }

    private bool CheckNorth(int x, int y, bool saveCoord = false, string number = "")
    {
        if (y == 0)
            return false;

        var value = Schematic[y - 1, x];

        if (saveCoord && value.Equals('*'))
            AddOrUpdateGear($"{y-1}{x}", number);
        
        return Validator.AllowedCharacters.Contains(value);
    }

    private bool CheckSouth(int x, int y, bool saveCoord = false, string number = "")
    {
        if (y >= YLength - 1)
            return false;
        
        var value = Schematic[y + 1, x];
        
        if (saveCoord && value.Equals('*'))
            AddOrUpdateGear($"{y+1}{x}", number);
        
        return Validator.AllowedCharacters.Contains(value);
    }

    private bool CheckWest(int x, int y, bool saveCoord = false, string number = "")
    {
        if (x == 0)
            return false;

        var value = Schematic[y, x - 1];
        
        if (saveCoord && value.Equals('*'))
            AddOrUpdateGear($"{y}{x-1}", number);
        
        return Validator.AllowedCharacters.Contains(value);
    }

    private bool CheckEast(int x, int y, bool saveCoord = false, string number = "")
    {
        if (x >= XLength - 1)
            return false;

        var value = Schematic[y, x + 1];
        
        if (saveCoord && value.Equals('*'))
            AddOrUpdateGear($"{y}{x+1}", number);
        
        return Validator.AllowedCharacters.Contains(value);
    }

    private bool CheckNorthEast(int x, int y, bool saveCoord = false, string number = "")
    {
        if (x >= XLength - 1 || y == 0)
            return false;

        var value = Schematic[y - 1, x + 1];
        
        if (saveCoord && value.Equals('*'))
            AddOrUpdateGear($"{y-1}{x+1}", number);
        
        return Validator.AllowedCharacters.Contains(value);
    }

    private bool CheckNorthWest(int x, int y, bool saveCoord = false, string number = "")
    {
        if (x == 0 || y == 0)
            return false;

        var value = Schematic[y - 1, x - 1];
        
        if (saveCoord && value.Equals('*'))
            AddOrUpdateGear($"{y-1}{x-1}", number);
        
        return Validator.AllowedCharacters.Contains(value);
    }

    private bool CheckSouthEast(int x, int y, bool saveCoord = false, string number = "")
    {
        if (x >= XLength - 1 || y >= YLength - 1)
            return false;

        var value = Schematic[y + 1, x + 1];
        
        if (saveCoord && value.Equals('*'))
            AddOrUpdateGear($"{y+1}{x+1}", number);
        
        return Validator.AllowedCharacters.Contains(value);
    }

    private bool CheckSouthWest(int x, int y, bool saveCoord = false, string number = "")
    {
        if (x == 0 || y >= YLength - 1)
            return false;

        var value = Schematic[y + 1, x - 1];
        
        if (saveCoord && value.Equals('*'))
            AddOrUpdateGear($"{y+1}{x-1}", number);
        
        return Validator.AllowedCharacters.Contains(value);
    }
}