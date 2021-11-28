using System;
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
        String(text);               
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
    static void String(string text)
    {
        string[] words = text.Split(new char[] { ' ', '-', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int count = 1;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].EndsWith("."))
            {
                words[i] = words[i].Insert(words[i].Length, "(" + (count) + ")");
            }
            else if (words[i] == "-" || words[i] == " ")
            {
                continue;
            }
            else
            {
                words[i] = words[i].Insert(words[i].Length, "(" + (count) + ") ");
            }
            count++;
        }
        foreach (String str in words)
            Console.Write(str);
        Console.WriteLine();
    }
}