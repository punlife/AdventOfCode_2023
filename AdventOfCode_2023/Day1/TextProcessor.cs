using System.Text;
using Serilog;

namespace AdventOfCode_2023.Day1;

public class TextProcessor
{
    private readonly Dictionary<string, string> _possibleValues = new();
    private readonly HashSet<string> _allowedValues = new()
    {
        "zero", "0", 
        "one", "1", 
        "two", "2",
        "three", "3",
        "four", "4",
        "five", "5",
        "six", "6",
        "seven", "7",
        "eight", "8",
        "nine", "9"
    };
    
    public TextProcessor()
    {
        PopulateDictionary();
    }
    
    public int ProcessTaskOneText(string[] input)
    {
        var counter = 0;

        foreach (var line in input)
        {
            var value = ProcessLine(line);
            counter += value;
        }

        return counter;
    }

    public int ProcessTaskTwoText(string[] input)
    {
        var counter = 0;

        foreach (var line in input)
        {
            var value = ProcessLine(TraverseTheStringToGetValues(line));
            counter += value;
        }

        return counter;
    }
    
    public int ProcessLine(string line)
    {
        var processedValue = new string(line.Where(char.IsDigit).ToArray());
        // Only grabbing first and last digit
        var valueToParse = $"{processedValue[0]}{processedValue[^1]}";

        if (int.TryParse(valueToParse, out var numericalValue))
        {
            return numericalValue;
        }

        Log.Error("Not a numerical value");
        throw new ArgumentException("Not a numerical value");
    }

    public List<string> CreateAListOfSubstringsOfValue(string value)
    {
        var substringList = new List<string>();
        var length = value.Length;
        for (var i = 3; i <= length; i++)
        {
            for (int j = 0; j <= length - i; j++)
            {
                substringList.Add(value.Substring(j, i));
            }
        }

        return substringList;
    }

    public string ProcessSubstrings(List<string> substrings)
    {
        var firstValue = 0;
        var currentValue = 0;
        foreach (var value in substrings)
        {
            if (_allowedValues.Contains(value))
            {
                
            }
        }

        return $"{firstValue}{currentValue}";
    }
    
    public string TraverseTheStringToGetValues(string value)
    {
        var valueLength = value.Length;
        
        var firstFrontValue = "";
        var firstBackValue = "";
  
        
        // front
        for (var i = 0; i < valueLength; i++)
        {
            var substring = value.Substring(0, i);
            if (CheckIfValueIsAllowed(substring, out firstFrontValue))
                break;
        }
        
        // back
        var reversedString = new String(value.Reverse().ToArray());
        for (var i = 0; i < valueLength; i++)
        {
            var substring = reversedString.Substring(0, i);
            if (CheckIfValueIsAllowed(new String(substring.Reverse().ToArray()), out firstBackValue))
                break;
        }

        return $"{firstFrontValue}{firstBackValue}";
    }

    
    
    public bool CheckIfValueIsAllowed(string value, out string returnValue)
    {
        returnValue = value;
        
        var found = false;
        foreach (var allowedValue in _allowedValues)
        {
            if (value.Contains(allowedValue))
            {
                found = true;
                returnValue = allowedValue;
                break;
            }
        }
        
        if (!found)
            return false;

        // If it's a number already there is no need to convert
        if (returnValue.Length > 1)
        {
            returnValue = _possibleValues.GetValueOrDefault(returnValue, returnValue);
        }
        
        return true;
    }
    
    public string ConvertWordsToNumbers(string line)
    {
        var newLine = line;
        foreach (var value in _possibleValues.Keys)
        {
            var index = line.IndexOf(_possibleValues[value]);

            newLine = "";
        }

        return "";
    }

    private void PopulateDictionary()
    {
        _possibleValues.Add("zero", "0");
        _possibleValues.Add("one", "1");
        _possibleValues.Add("two", "2");
        _possibleValues.Add("three", "3");
        _possibleValues.Add("four", "4");
        _possibleValues.Add("five", "5");
        _possibleValues.Add("six", "6");
        _possibleValues.Add("seven", "7");
        _possibleValues.Add("eight", "8");
        _possibleValues.Add("nine", "9");
    }
    
}