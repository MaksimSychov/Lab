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
        Console.WriteLine("Введите предложение:");
        string text = Console.ReadLine().Trim();
        Console.WriteLine("Через обработку строки как массива символов:");
        Text_array(text);
        Console.WriteLine("С помощью регулярных выражений:");
        Console.WriteLine(Regular(text));
    }
    static void Text_array(string text)
    {
        string[] words = text.Split(new char[] { ' ' });
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (Char.IsUpper(word[0]) && Char.IsNumber(word[word.Length - 1]) && Char.IsNumber(word[word.Length - 2]))
            {
                Console.WriteLine(words[i]);
            }
        }
    }
    static string Regular(string text)
    {
        Regex regular = new Regex(@"([A-Z]{1})([a-z]*)([0-9]{2})");
        MatchCollection matches = regular.Matches(text);
        string newtext = "";
        foreach (Match match in matches)
        {
            newtext = newtext + match.Value + " ";
        }
        return newtext;
    }
}