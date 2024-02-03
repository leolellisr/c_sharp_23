namespace JewelCollector;

public enum ObstacleType
{
    Water,
    Tree
}


public class Obstacle
{
    public int X { get; set; }
    public int Y { get; set; }
    public ObstacleType Type { get; set; }
}