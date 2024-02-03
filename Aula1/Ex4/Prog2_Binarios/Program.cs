using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o primeiro número binário:");
        string numero1 = Console.ReadLine();

        Console.WriteLine("Digite o segundo número binário:");
        string numero2 = Console.ReadLine();

        Console.WriteLine("Digite o terceiro número binário:");
        string numero3 = Console.ReadLine();

        int valor1 = Convert.ToInt32(numero1, 2);
        int valor2 = Convert.ToInt32(numero2, 2);
        int valor3 = Convert.ToInt32(numero3, 2);

        int maior = Math.Max(valor1, Math.Max(valor2, valor3));
        int menor = Math.Min(valor1, Math.Min(valor2, valor3));

        Console.WriteLine("Maior número: " + Convert.ToString(maior, 2));
        Console.WriteLine("Menor número: " + Convert.ToString(menor, 2));
    }
}
