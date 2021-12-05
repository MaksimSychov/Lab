using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите предложение: ");
        string text = Console.ReadLine();
        Console.WriteLine("Через обработку строки как массива символов:");
        Array(text);
        Console.WriteLine("С помощью метода класса string:");
        Console.WriteLine(String(text));
        Console.ReadKey();
    }
    static void Array(string text)
    {
        int count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsLetter(text[i]) && (text[i + 1] == ' ' || text[i + 1] == '-' || text[i + 1] == '.' || text[i + 1] == ','))
            {
                count++;
                Console.Write($"{text[i]}({count})");
            }
            else
            {
                Console.Write(text[i]);
            }
        }
        Console.WriteLine();
    }
    static string String(string text)
    {
        string newtext = text;
        for (int i = 1, n = 1, count = 1; i < text.Length; i++)
        {
            if (Char.IsLetter(text[i]) && (text[i + 1] == ' ' || text[i + 1] == '-' || text[i + 1] == '.' || text[i + 1] == ','))
            {
                string number = $"({count++})";
                newtext = newtext.Insert(i + n, number);
                n += number.Length;
            }
        }
        return newtext;
    }
}