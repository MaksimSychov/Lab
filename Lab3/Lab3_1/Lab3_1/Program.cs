using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        Console.Write("Введите число элементов массива: ");
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-30, 45);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Элементы массива в обратном направлении без отрицательных чисел: ");
        array = array.Reverse().ToArray();
        for (int i = 0, count = 0; i < array.Length; i++)
        {
            if (array[i] >= 0)
            {
                Console.Write(array[i] + " ");
                count++;
            }   
        }
        Console.ReadKey();
    }
}