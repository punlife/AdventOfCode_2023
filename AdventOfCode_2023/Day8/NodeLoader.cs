using System.Text.RegularExpressions;
using AdventOfCode_2023.Day8;

namespace AdventOfCode_2023.Day10;

public class NodeLoader
{
    const string KeyPattern = @"([A-Z]{3})";
    const string KeyPatternT2 = @"([0-9A-Z]{3})";
    public List<char> InstructionList = new();
    public List<char>.Enumerator InstructionEnumerator;
    
    
    public Dictionary<string, Node> GetNodesFromInput(string[] input, bool t1)
    {
        var nodeDict = new Dictionary<string, Node>();
        for (var index = 0; index < 2; index++)
        {
            var line = input[index];
            foreach (var character in line)
            {
                InstructionList.Add(character);
            }
        }
        
        for (var index = 2; index < input.Length; index++)
        {
            var line = input[index];
            var keyMatch = Regex.Matches(line, t1 ? KeyPattern : KeyPatternT2);
            var key = keyMatch[0].Value;
            var leftKey = keyMatch[1].Value;
            var rightKey = keyMatch[2].Value;
            nodeDict.Add(key, new Node(leftKey, rightKey));
        }
        InstructionEnumerator = InstructionList.GetEnumerator();
        return nodeDict;
    }
    
    public char GetNextInstruction()
    {
        var canMoveFurther = InstructionEnumerator.MoveNext();
        if (!canMoveFurther)
        {
            InstructionEnumerator.Dispose();
            InstructionEnumerator = InstructionList.GetEnumerator();
            InstructionEnumerator.MoveNext();
        }

        var returnValue = InstructionEnumerator.Current;
        return returnValue;
    }
}