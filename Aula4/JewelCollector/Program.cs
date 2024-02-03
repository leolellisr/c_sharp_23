using System;
namespace JewelCollector;

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
