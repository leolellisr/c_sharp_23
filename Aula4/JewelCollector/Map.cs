namespace JewelCollector;

public class Map
{
    public const int MapSize = 10;
    private string[,] map;
    private List<Jewel> jewels;

    public Map()
    {
        map = new string[MapSize, MapSize];
        jewels = new List<Jewel>(); // Initialize the jewels collection
        bool debug = false;
        InitializeMap();
    }

    private void InitializeMap()
    {
        for (int i = 0; i < MapSize; i++)
        {
            for (int j = 0; j < MapSize; j++)
            {
                map[i, j] = "--";
            }
        }
    }

    public void AddJewel(Jewel jewel)
    {
        map[jewel.X, jewel.Y] = GetJewelSymbol(jewel.Type);
        jewels.Add(jewel);
    }

    public void RemoveJewel(Jewel jewel)
    {
        map[jewel.X, jewel.Y] = "--";
        jewels.Remove(jewel);
    }

    public void AddObstacle(Obstacle obstacle)
    {
        map[obstacle.X, obstacle.Y] = GetObstacleSymbol(obstacle.Type);
    }

    public void PrintMap(Robot robot)
    {
        Console.WriteLine();
        Console.WriteLine();
        for (int j = 0; j < MapSize; j++)
        {
            for (int i = 0; i < MapSize; i++)
            {
                if (robot.X == i && robot.Y == j)
                {
                    Console.Write("ME ");
                }
                else
                {
                    Console.Write(map[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }

    public Jewel GetJewelAtPosition(int x, int y)
    {
        foreach (Jewel jewel in jewels)
        {
            if (jewel.X == x && jewel.Y == y)
            {
                return jewel;
            }
        }

        return null;
    }
    
        public static bool IsValidPosition(int x, int y)
    {
        
        return x >= 0 && x < MapSize && y >= 0 && y < MapSize;
    }

    private string GetJewelSymbol(JewelType type)
    {
        switch (type)
        {
            case JewelType.Red:
                return "JR";
            case JewelType.Green:
                return "JG";
            case JewelType.Blue:
                return "JB";
            default:
                return "--";
        }
    }

    private string GetObstacleSymbol(ObstacleType type)
    {
        switch (type)
        {
            case ObstacleType.Water:
                return "##";
            case ObstacleType.Tree:
                return "$$";
            default:
                return "--";
        }
    }

    public string GetSymbolAtPosition(int x, int y)
    {
        if (IsValidPosition(x, y))
        {
            return map[x, y];
        }
        else
        {
            return "--";
        }
    }

    public Jewel[] GetJewelsInArea(int startX, int endX, int startY, int endY)
    {
        List<Jewel> jewelsInArea = new List<Jewel>();

        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                string symbol = GetSymbolAtPosition(x, y);

                if (symbol == "JR" || symbol == "JG" || symbol == "JB")
                {
                    jewelsInArea.Add(GetJewelAtPosition(x, y));
                }
            }
        }

        return jewelsInArea.ToArray();
    }

    

}