using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite as medidas dos lados do triângulo:");

        Console.Write("Lado 1: ");
        double lado1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Lado 2: ");
        double lado2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Lado 3: ");
        double lado3 = Convert.ToDouble(Console.ReadLine());

        if (lado1 > 0 && lado2 > 0 && lado3 > 0)
        {
            if (lado1 == lado2 && lado1 == lado3)
            {
                Console.WriteLine("Triângulo Equilátero");
            }
            else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            {
                Console.WriteLine("Triângulo Isósceles");
            }
            else
            {
                Console.WriteLine("Triângulo Escaleno");
            }

            // Cálculo da área do triângulo usando a fórmula de Heron
            double semiPerimetro = (lado1 + lado2 + lado3) / 2;
            double area = Math.Sqrt(semiPerimetro * (semiPerimetro - lado1) * (semiPerimetro - lado2) * (semiPerimetro - lado3));

            Console.WriteLine("Área do triângulo: " + area.ToString("F3"));
        }
        else
        {
            Console.WriteLine("As medidas dos lados devem ser valores positivos.");
        }
    }
}
