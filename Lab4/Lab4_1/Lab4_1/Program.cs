﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите предложение: ");
        string text = Console.ReadLine().ToLower();
        Console.WriteLine("Через обработку строки как массива символов: ");
        first_way(text);
        Console.WriteLine();
        Console.WriteLine("С помощью методов класса string: ");
        second_way(text);
        Console.ReadKey();
    }
    static void first_way(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            int n = 0;
            for (int j = 0; j < text.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }
                if (text[i] == text[j])
                {
                    n++;
                }
            }
            if (n == 0)
            {
                Console.Write(text[i] + " ");
            }
        }
    }
    static void second_way(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (text.IndexOf(text[i]) == text.LastIndexOf(text[i]))
            {
                Console.Write(text[i] + " ");
            }
        }
    }
}