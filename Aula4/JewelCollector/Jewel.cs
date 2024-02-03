namespace JewelCollector;

public enum JewelType
{
    Red = 100,
    Green = 50,
    Blue = 10
}

public class Jewel
{
    public int X { get; set; }
    public int Y { get; set; }
    public JewelType Type { get; set; }
}

