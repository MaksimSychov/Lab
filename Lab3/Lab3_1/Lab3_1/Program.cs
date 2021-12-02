using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        Console.Write("Введите число элементов массива: ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];       
        int limit_1 = 1;
        int limit_2 = 1;
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(-30, 45);
            if (limit_1 > 10)
            {
                Console.Write("\n");
                limit_1 = 1;
            }
            limit_1++;
            Console.Write(array[i] + "\t");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Элементы массива в обратном направлении без отрицательных чисел: ");
        array = array.Reverse().ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
                continue;
            if (limit_2 > 10)
            {
                Console.Write("\n");
                limit_2 = 1;
            }
            limit_2++;
            Console.Write(array[i] + "\t");
        }
        Console.ReadKey();
    }
}