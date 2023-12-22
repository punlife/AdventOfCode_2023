namespace AdventOfCode_2023.Day8;

public class Node
{
    public string LeftKey { get; }
    public string RightKey { get; }

    public Node(string leftKey, string rightKey)
    {
        LeftKey = leftKey;
        RightKey = rightKey;
    }
}