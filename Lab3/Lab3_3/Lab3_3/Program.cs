﻿using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество элементов массива: ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Cдвигать массив влево: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[k];
        int[] array_n = new int[k];
        Console.WriteLine("Массив:");
        for (int i = 0; i < k; i++)
        {
            array[i] = i;
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        for (int i = 0; i < k; i++)
        {
            array_n[i] = (i + n) % array.Length;
            Console.Write(array_n[i] + " ");
        }
        Console.ReadKey();
    }
}