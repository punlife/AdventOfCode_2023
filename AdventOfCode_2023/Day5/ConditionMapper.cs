
namespace AdventOfCode_2023.Day5;

public class ConditionMapper
{
    public List<Condition> Conditions { get; } = new();
    
    public ConditionMapper()
    {
        
    }

    public long MapValue(long value)
    {
        var mappedValue = value;

        foreach (var condition in Conditions)
        {
            if (value < condition.Input || value > condition.Input + condition.Range) continue;
            mappedValue = value + condition.Shift;
            break;
        }
        
        return mappedValue;
    }
    
    
}