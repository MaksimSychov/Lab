using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество элементов массива: ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];
        Random random = new Random();
        for (int i = 0; i < k; i++)
        {
            array[i] = random.Next(k);
        }
        Console.WriteLine("Массив:");
        for (int i = 0; i < k; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Демонстрация работы функции \"sumIterative\":\t" + sumIterative(array));
        Console.WriteLine("Демонстрация работы функции \"sumRecursive\":\t" + sumRecursive(array));
        Console.WriteLine("Демонстрация работы функции \"minIterative\":\t" + minIterative(array));
        Console.WriteLine("Демонстрация работы функции \"minRecursive\":\t" + minRecursive(array, array[0]));
        Console.ReadKey();
    }
    static int sumIterative(int[] array)
    {
         int result = 0;
         for (int i = 0; i < array.Length; i++)
         {
            result = result + array[i];
         }
         return result;
    }
    static int sumRecursive(int[] array, int i = 0)
    {
        if (array.Length == 0)
        {
            return 0;
        }
        return array[0] + sumRecursive(array, i + 1);
    }
    static int minIterative(int[] array)
    {
        int min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (min > array[i])
                min = array[i];
        }
        return min;
    }
    static int minRecursive(int[] array, int min)
    {
        if (array.Length == 0)
        {
            return min;
        }
        if (min > array[0])
        {
            min = array[0];
        }
        return minRecursive(array[1..], min);
    }
}