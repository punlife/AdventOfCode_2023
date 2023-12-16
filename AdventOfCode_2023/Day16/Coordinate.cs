namespace AdventOfCode_2023.Day16;

public class Coordinate
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;

    public LaserDirection Direction { get; set; } = LaserDirection.RIGHT;
    
    public Coordinate()
    {
        
    }
    public Coordinate(int x, int y, LaserDirection direction)
    {
        this.X = x;
        this.Y = y;
        this.Direction = direction;
    }
}