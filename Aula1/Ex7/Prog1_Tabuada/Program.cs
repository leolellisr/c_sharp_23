using System;

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 9; i++)
        {
            Console.WriteLine("Tabuada do " + i + ":");
            Console.WriteLine("-----------------");

            for (int j = 1; j <= 10; j++)
            {
                int resultado = i * j;
                Console.WriteLine(i + " x " + j + " = " + resultado);
            }

            Console.WriteLine();
        }
    }
}
