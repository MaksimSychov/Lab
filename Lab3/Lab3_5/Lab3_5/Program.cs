using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int[,] array_1 = new int[5, 5];
        int[,] array_2 = new int[5, 5];
        int[,] array_3 = new int[5, 5];
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array_1[i, j] = random.Next(10);
                array_2[i, j] = random.Next(10);
            }
        }
        Console.WriteLine("Массивы:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(array_1[i, j] + "\t");
            }
            Console.Write("\t");
            for (int j = 0; j < 5; j++)
            {
                Console.Write(array_2[i, j] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array_3[i, j] = array_1[i, j] * array_2[i, j];
            }
        }
        Console.WriteLine("Перемножение двух матриц 5х5:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(array_3[i, j] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}