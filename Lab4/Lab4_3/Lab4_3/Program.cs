using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите предложение и завершите его точкой:");
        string text = Console.ReadLine().Trim();
        Console.WriteLine("Через обработку строки как массива символов:");
        Console.WriteLine(Array(text));
        Console.WriteLine("С помощью методов классов string и StringBuilder:");
        Console.WriteLine(Method(text));
    }
    static char[] separators = { ' ', '.' };
    static string Array(string text)
    {
        string newtext = "";
        List<string> words = new List<string>();
        for (int i = 1, j = 0; i < text.Length; i++)
        {
            List<char> list = new List<char>();
            if (separators.Contains(text[i]) & !separators.Contains(text[i - 1]))
            {
                while(j < i)
                {
                    list.Add(text[j]);
                    j++;
                }
                char[] char_arr = list.ToArray();
                string temp_str = new string(char_arr);
                words.Add(temp_str);
            }
        }
        for (int i = words.Count - 1; i >= 0; i--)
        {

            newtext = i == 0 ? newtext + words[i] + "." : newtext + words[i] + " ";
        }
        return newtext.Trim();
    }
    static string Method(string text)
    {
        string newtext = "";
        string[] words = text.Split(separators);
        for (int i = words.Length - 1; i >= 0; i--)
        {
            newtext = i == 0 ? newtext + words[i] + "." : newtext + words[i] + " ";
        }
        return newtext.Trim();
    }
}