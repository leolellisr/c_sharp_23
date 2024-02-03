using System;

class Program
{
    static void Main()
    {
        int numero = 1;
        
        while (numero <= 1000)
        {
            if (numero % 7 == 0 && numero % 13 == 0 && numero % 17 == 0)
            {
                Console.WriteLine("O primeiro número divisível por 7, 13 e 17 é: " + numero);
                break;
            }

            numero++;
        }

        Console.WriteLine("Não há número menor que 1000 que seja divisivel por 7, 13 e 17 ");
    }
}
