using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите размерность массива:");
        int k = int.Parse(Console.ReadLine());
        int[,] array = new int[k, k];
        Random random = new Random();
        Console.WriteLine("Двумерный массив:");
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < k; j++)
            {
                array[i, j] = random.Next(k * k);
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        for (int n = 0; n < 3; n++)
        {
            for (int i = 0; i < Math.Floor(Convert.ToDouble(k) / 2); i++)
            {
                for (int j = 0; j < Math.Ceiling(Convert.ToDouble(k) / 2); j++)
                {
                    int temp = array[i, j];
                    array[i, j] = array[j, k - 1 - i];
                    array[j, k - 1 - i] = array[k - 1 - i, k - 1 - j];
                    array[k - 1 - i, k - 1 - j] = array[k - 1 - j, i];
                    array[k - 1 - j, i] = temp;
                }
            }
        }
        Console.WriteLine("Поворот двумерного массива на 90 градусов вправо: ");
        for (int i = 0; i < k; i++)
        {
            for (int j = 0; j < k; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}