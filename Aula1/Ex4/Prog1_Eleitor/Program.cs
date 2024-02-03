using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o ano de nascimento:");
        string input = Console.ReadLine();
        
        int anoNascimento;
        if (int.TryParse(input, out anoNascimento))
        {
            int anoAtual = DateTime.Now.Year;
            int idade = anoAtual - anoNascimento;
            
            if (idade >= 16)
            {
                Console.WriteLine("Você poderá votar este ano!");
            }
            else
            {
                Console.WriteLine("Você não poderá votar este ano.");
            }
        }
        else
        {
            Console.WriteLine("Ano de nascimento inválido. Por favor, digite um valor numérico válido.");
        }
    }
}
