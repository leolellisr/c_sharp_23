using System;

class Program
{
    static void Main()
    {
        int soma = 0;

        for (int i = 1; i <= 1000; i++)
        {
            if (i % 5 != 0)
            {
                soma += i;
            }
        }

        Console.WriteLine("A soma dos números de 1 até 1000 (exceto múltiplos de 5) é: " + soma);
    }
}
