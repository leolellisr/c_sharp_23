using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite números inteiros (maiores que 1):");

        int soma = 0;
        int numero;

        do
        {
            numero = Convert.ToInt32(Console.ReadLine());
            soma += numero;
        } while (numero > 1);

        Console.WriteLine("Soma dos números digitados: " + soma);
    }
}
