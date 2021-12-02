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
        int sumRec = 0;
        int minRec = int.MaxValue;
        for (int i = 0; i < k; i++)
        {
            array[i] = random.Next(k);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("");
        Console.WriteLine("Демонстрация работы функции \"sumIterative\":\t" + sumIterative(array));
        Console.WriteLine("Демонстрация работы функции \"sumRecursive\":\t" + sumRecursive(array, sumRec));
        Console.WriteLine("Демонстрация работы функции \"minIterative\":\t" + minIterative(array));
        Console.WriteLine("Демонстрация работы функции \"minRecursive\":\t" + minRecursive(array, minRec));
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
    static int sumRecursive(int[] array, int sumRec, int i = 0)
    {
        if (i >= array.Length)
        {
            return sumRec;
        }
        else
        {
            sumRec += array[i];
            i++;
        }
        return sumRecursive(array, sumRec, i);
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
    static int minRecursive(int[] array, int minRec, int i = 0)
    {
        if (i < array.Length)
        {
            if (array[i] < minRec)
            {
                minRec = array[i];
            }
            return minRecursive(array, minRec, i + 1);
        }
        return minRec;
    }
}