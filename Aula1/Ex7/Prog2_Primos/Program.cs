using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Números primos até 100:");

        for (int numero = 2; numero <= 100; numero++)
        {
            bool ehPrimo = true;

            for (int divisor = 2; divisor < numero; divisor++)
            {
                if (numero % divisor == 0)
                {
                    ehPrimo = false;
                    break;
                }
            }

            if (ehPrimo)
            {
                Console.WriteLine(numero);
            }
        }
    }
}
