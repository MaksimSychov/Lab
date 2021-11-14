using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int[,] array_1 = new int[3, 3];
        int[,] array_2 = new int[3, 3];
        Random random = new Random();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                array_1[i, j] = random.Next(9);
                array_2[i, j] = random.Next(9);
            }
        }
        Console.WriteLine("Двумерные массивы:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(array_1[i, j] + " ");
            }
            Console.Write("\t");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(array_2[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Выберите действие:\n1) Сложение (+)\n2) Вычитание (-)\n3) Среднее значение (/)");
        int[,] result = new int[3, 3];
        bool flag = false;
        double[] result_Average = new double[2];
        switch (Console.ReadLine())
        {
            case "+":
                result = Sum(array_1, array_2);
                flag = true;
                break;
            case "-":
                result = Difference(array_1, array_2);
                flag = true;
                break;
            case "/":
                result_Average = Average(array_1, array_2);
                break;
        }
        if (flag)
        {
            Console.WriteLine("Результирующий массив:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i, j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Среднее значение:\nПервый массив = {0}\nВторой массив = {1}", result_Average[0], result_Average[1]);
        }
    }
    static int[,] Sum(int[,] array_1, int[,] array_2)
    {
        int[,] result = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result[i, j] = array_1[i, j] + array_2[i, j];
            }
        }
        return result;
    }
    static int[,] Difference(int[,] array_1, int[,] array_2)
    {
        int[,] result = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result[i, j] = array_1[i, j] - array_2[i, j];
            }
        }
        return result;
    }
    static double[] Average(int[,] array_1, int[,] array_2)
    {
        double[] result = new double[2];
        double sum_1 = 0;
        double sum_2 = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                sum_1 = sum_1 + array_1[i, j];
            }
        }
        result[0] = sum_1 / array_1.Length;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                sum_2 = sum_2 + array_2[i, j];
            }
        }
        result[1] = sum_2 / array_2.Length;
        return result;
    }
}