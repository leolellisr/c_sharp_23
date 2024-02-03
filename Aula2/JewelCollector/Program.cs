using System;

public enum JewelType
{
    Red = 100,
    Green = 50,
    Blue = 10
}

public enum ObstacleType
{
    Water,
    Tree
}

public class Jewel
{
    public int X { get; set; }
    public int Y { get; set; }
    public JewelType Type { get; set; }
}

public class Obstacle
{
    public int X { get; set; }
    public int Y { get; set; }
    public ObstacleType Type { get; set; }
}

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

public class JewelCollector
{
    const bool debug = false;

    private static bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < Map.MapSize && y >= 0 && y < Map.MapSize;
    }

    private static void MoveRobot(Map map, Robot robot, int deltaX, int deltaY)
    {
        int newX = robot.X + deltaX;
        int newY = robot.Y + deltaY;

        // Verificar se a nova posição está dentro dos limites do mapa
        if (IsValidPosition(newX, newY))
        {
            // Verificar se a nova posição não é um obstáculo
            if (!IsObstacle(map, newX, newY) && !IsJewel(map, newX, newY))
            {
                
                robot.X = newX;
                robot.Y = newY;
            }
        }
    }


    private static bool IsObstacle(Map map, int x, int y)
    {
        return map.GetSymbolAtPosition(x, y) == "##" || map.GetSymbolAtPosition(x, y) == "$$";
    }

    private static bool IsJewel(Map map, int x, int y)
        {
            return map.GetSymbolAtPosition(x, y) == "JR" || map.GetSymbolAtPosition(x, y) == "JG" || map.GetSymbolAtPosition(x, y) == "JB";
        }

    private static void CollectJewel(Map map, Robot robot)
    {
        foreach (Jewel jewel in GetAdjacentJewels(map, robot))
        {
            robot.CollectJewel(jewel);
            map.RemoveJewel(jewel);
            if(debug){
                Console.WriteLine($"Robot in position x: {robot.X} and y: {robot.Y} collected jewel in position x: {jewel.X} and y: {jewel.Y}");
            }
        }
    }

    private static Jewel[] GetAdjacentJewels(Map map, Robot robot)
    {
        int startX = Math.Max(0, robot.X - 1);
        int endX = Math.Min(Map.MapSize - 1, robot.X + 1);
        int startY = Math.Max(0, robot.Y - 1);
        int endY = Math.Min(Map.MapSize - 1, robot.Y + 1);

        return map.GetJewelsInArea(startX, endX, startY, endY);
    }

    public static void Main()
    {
        Map map = new Map();
        Robot robot = new Robot(0, 0);
        bool debug = false;
        Jewel[] jewels = new Jewel[]
        {
            new Jewel { X = 1, Y = 9, Type = JewelType.Red },
            new Jewel { X = 8, Y = 8, Type = JewelType.Red },
            new Jewel { X = 9, Y = 1, Type = JewelType.Green },
            new Jewel { X = 7, Y = 6, Type = JewelType.Green },
            new Jewel { X = 3, Y = 4, Type = JewelType.Blue },
            new Jewel { X = 2, Y = 1, Type = JewelType.Blue }
        };

        // Criar e inserir os obstáculos
        Obstacle[] obstacles = new Obstacle[]
        {
            new Obstacle { X = 5, Y = 0, Type = ObstacleType.Water },
            new Obstacle { X = 5, Y = 1, Type = ObstacleType.Water },
            new Obstacle { X = 5, Y = 2, Type = ObstacleType.Water },
            new Obstacle { X = 5, Y = 3, Type = ObstacleType.Water },
            new Obstacle { X = 5, Y = 4, Type = ObstacleType.Water },
            new Obstacle { X = 5, Y = 5, Type = ObstacleType.Water },
            new Obstacle { X = 5, Y = 6, Type = ObstacleType.Water },
            new Obstacle { X = 5, Y = 9, Type = ObstacleType.Tree },
            new Obstacle { X = 3, Y = 9, Type = ObstacleType.Tree },
            new Obstacle { X = 8, Y = 3, Type = ObstacleType.Tree },
            new Obstacle { X = 2, Y = 5, Type = ObstacleType.Tree },
            new Obstacle { X = 1, Y = 4, Type = ObstacleType.Tree }
        };

        // Adicionar as joias e obstáculos no mapa
        foreach (Jewel jewel in jewels)
        {
            map.AddJewel(jewel);
        }

        foreach (Obstacle obstacle in obstacles)
        {
            map.AddObstacle(obstacle);
        }

        // Iniciar o jogo
        bool running = true;
        

        do
        {
            // Imprimir estado atual do mapa
            map.PrintMap(robot);

            // Imprimir estado da sacola do robô
            Console.WriteLine();
            Console.WriteLine("\nBag Value: " + robot.BagValue);
            Console.WriteLine("Score: " + robot.Score);

            Console.WriteLine("Enter the command: ");
            string command = Console.ReadLine();

            if (command.Equals("quit"))
            {
                running = false;
            }
            else if (command.Equals("w"))
            {
                MoveRobot(map, robot, 0, -1);
            }
            else if (command.Equals("a"))
            {
                MoveRobot(map, robot, -1, 0);
            }
            else if (command.Equals("s"))
            {
                MoveRobot(map, robot, 0, 1);
            }
            else if (command.Equals("d"))
            {
                MoveRobot(map, robot, 1, 0);
            }
            else if (command.Equals("g"))
            {
                CollectJewel(map, robot);
            }

            // Imprimir o estado atual do mapa e a sacola do robô
            Console.Clear();
            map.PrintMap(robot);
            Console.WriteLine($"Score: {robot.Score}");
            Console.WriteLine($"Bag Value: {robot.BagValue}");
            if(debug){
                Console.WriteLine($"Robot X: {robot.X}");
                Console.WriteLine($"Robot Y: {robot.Y}");

            }
        } while (running);
    }
}
