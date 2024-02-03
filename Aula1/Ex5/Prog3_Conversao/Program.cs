using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite um número decimal inteiro:");
        int numeroDecimal = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite a base desejada para conversão:");
        Console.WriteLine("1 - Octal");
        Console.WriteLine("2 - Hexadecimal");
        Console.WriteLine("3 - Binária");
        int opcao = Convert.ToInt32(Console.ReadLine());

        string numeroConvertido;

        switch (opcao)
        {
            case 1:
                numeroConvertido = Convert.ToString(numeroDecimal, 8);
                break;
            case 2:
                numeroConvertido = Convert.ToString(numeroDecimal, 16);
                break;
            case 3:
                numeroConvertido = Convert.ToString(numeroDecimal, 2);
                break;
            default:
                Console.WriteLine("Opção inválida!");
                return;
        }

        Console.WriteLine("Número convertido: " + numeroConvertido);
    }
}
