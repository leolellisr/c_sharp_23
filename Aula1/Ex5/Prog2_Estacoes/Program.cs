using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o número do mês:");
        int numeroMes = Convert.ToInt32(Console.ReadLine());

        string estacao;

        switch (numeroMes)
        {
            case 1:
            case 2:
            case 12:
                estacao = "Verão";
                break;
            case 3:
            case 4:
            case 5:
                estacao = "Outono";
                break;
            case 6:
            case 7:
            case 8:
                estacao = "Inverno";
                break;
            case 9:
            case 10:
            case 11:
                estacao = "Primavera";
                break;
            default:
                estacao = "Mês inválido";
                break;
        }

        Console.WriteLine("Estação do ano: " + estacao);
    }
}
