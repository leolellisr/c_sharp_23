using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o primeiro número:");
        double numero1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite o segundo número:");
        double numero2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite a operação desejada (+, -, /, *):");
        char operacao = Console.ReadKey().KeyChar;
        Console.WriteLine();

        double resultado = 0;

        switch (operacao)
        {
            case '+':
                resultado = numero1 + numero2;
                break;
            case '-':
                resultado = numero1 - numero2;
                break;
            case '/':
                resultado = numero1 / numero2;
                break;
            case '*':
                resultado = numero1 * numero2;
                break;
            default:
                Console.WriteLine("Operação inválida!");
                return;
        }

        Console.WriteLine("Resultado: " + resultado);
    }
}
