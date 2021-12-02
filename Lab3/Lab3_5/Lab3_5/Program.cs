using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int n = 5;
        int[,] array_1 = new int[n, n];
        int[,] array_2 = new int[n, n];
        Random rand = new Random();
        Console.WriteLine("Превая матрица: ");
        for (int i = 0; i < array_1.GetLength(0); i++)
        {
            for (int j = 0; j < array_1.GetLength(1); j++)
            {
                array_1[i, j] = rand.Next(10);
                Console.Write(array_1[i, j] + "\t");
            }
            Console.Write("\n\n");
        }
        Console.WriteLine("Вторая матрица: ");
        for (int i = 0; i < array_1.GetLength(0); i++)
        {
            for (int j = 0; j < array_1.GetLength(1); j++)
            {
                array_2[i, j] = rand.Next(10);
                Console.Write(array_2[i, j] + "\t");
            }
            Console.Write("\n\n");
        }
        Console.WriteLine("Перемножение двух матриц 5х5: ");
        int[,] a = Multiplication(array_1, array_2);
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + "\t");
            }
            Console.Write("\n\n");
        }
        Console.ReadKey();
    }
    static int[,] Multiplication(int[,] array_1, int[,] array_2)
    {
        int n = 5;
        int[,] arrayOutput = new int[n, n];
        for (int i = 0; i <= n - 1; i++)
        {
            for (int j = 0; j <= n - 1; j++)
            {
                arrayOutput[i, j] = 0;
                for (int k = 0; k <= n - 1; k++)
                {
                    arrayOutput[i, j] += array_1[i, k] * array_2[k, j];
                }
            }
        }
        return arrayOutput;
    }
}