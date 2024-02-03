namespace JewelCollector;


public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Score { get; set; }
    public int BagValue { get; set; }

    public Robot(int x, int y)
    {
        X = x;
        Y = y;
        Score = 0;
        BagValue = 0;
    }

    public void CollectJewel(Jewel jewel)
    {
        if (IsAdjacent(jewel))
        {
            Score += (int)jewel.Type;
            BagValue += (int)jewel.Type;
        }
    }

    private bool IsAdjacent(Jewel jewel)
    {
        return Math.Abs(jewel.X - X) <= 1 && Math.Abs(jewel.Y - Y) <= 1;
    }
}

