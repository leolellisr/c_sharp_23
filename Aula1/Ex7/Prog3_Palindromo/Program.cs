using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite uma palavra:");
        string palavra = Console.ReadLine();

        bool ehPalindromo = true;

        // Converter a palavra para minúsculas para ignorar diferenças de caixa
        palavra = palavra.ToLower();

        // Remover espaços em branco da palavra
        palavra = palavra.Replace(" ", "");

        // Inverter a palavra
        string palavraInvertida = "";
        foreach (char c in palavra)
        {
            palavraInvertida = c + palavraInvertida;
        }

        // Verificar se a palavra invertida é igual à palavra original
        if (palavra != palavraInvertida)
        {
            ehPalindromo = false;
        }

        if (ehPalindromo)
        {
            Console.WriteLine("A palavra é um palíndromo.");
        }
        else
        {
            Console.WriteLine("A palavra não é um palíndromo.");
        }
    }
}
