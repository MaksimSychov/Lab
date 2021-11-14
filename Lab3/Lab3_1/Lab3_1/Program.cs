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
        int[] list = new int[k];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = random.Next(-30, 45);
        }
        Console.WriteLine("Вывод массива:");
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Элементы массива в обратном направлении без отрицательных чисел: ");
        list = list.Reverse().ToArray();
        for (int i = 0, count = 0; i < list.Length; i++)
        {
            if (list[i] >= 0)
            {
                Console.Write(list[i] + " ");
                count++;
            }   
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}