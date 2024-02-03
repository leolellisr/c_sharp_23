using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite a primeira string:");
        string string1 = Console.ReadLine();

        Console.WriteLine("Digite a segunda string:");
        string string2 = Console.ReadLine();

        if (string1.Equals(string2))
        {
            Console.WriteLine("As strings são iguais.");
        }
        else
        {
            Console.WriteLine("As strings são diferentes.");
        }
    }
}
