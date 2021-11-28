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
        int number = 1;
        string[] text_array = new string[7];
        for (int i = 0; i < text_array.Length; i++)
        {
            Console.Write(number + ".");
            Console.WriteLine("Введите строку: ");
            text_array[i] = Console.ReadLine();
            number++;
        }
        Console.WriteLine("Через обработку строки как массива символов:");
        Conclusion(List_com_array(text_array), The_smallest_number_of_spaces_array(text_array));
        Console.WriteLine("С помощью методов класса string:");
        Conclusion(List_com_method(text_array), The_smallest_number_of_spaces_method(text_array));
    }
    static void Conclusion(string[] list_com, int the_smallest_number_of_spaces)
    {
        Console.WriteLine("Строки содержащие \".com\":");
        for (int i = 0; i < list_com.Length; i++)
        {
            Console.WriteLine(list_com[i]);
        }
        Console.WriteLine($"{the_smallest_number_of_spaces} строка содержит меньше всего пробелов.");
    }
    static string[] List_com_array(string[] text_array)
    {
        List<string> list_com = new List<string>();
        for (int i = 0; i < text_array.Length; i++)
        {
            string temp_string = text_array[i].ToLower();
            for (int j = 0; j < text_array[i].Length - 3; j++)
            {
                if (temp_string[j].Equals('.') & temp_string[j + 1].Equals('c') & temp_string[j + 2].Equals('o') & temp_string[j + 3].Equals('m'))
                {
                    list_com.Add(text_array[i]);
                }
            }
        }
        return list_com.ToArray();
    }
    static int The_smallest_number_of_spaces_array(string[] text_array)
    {
        List<int> counts = new List<int>();
        for (int i = 0; i < text_array.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < text_array[i].Length; j++)
            {
                if (text_array[i][j].Equals(' '))
                {
                    count++;
                }
            }
            counts.Add(count);
        }
        int the_smallest_number_of_spaces = counts.IndexOf(counts.Min()) + 1;
        return the_smallest_number_of_spaces;
    }
    static string[] List_com_method(string[] text_array)
    {
        List<string> list_com = new List<string>();
        for (int i = 0; i < text_array.Length; i++)
        {
            if (text_array[i].ToLower().Contains(".com"))
            {
                list_com.Add(text_array[i]);
            }
        }
        return list_com.ToArray();
    }
    static int The_smallest_number_of_spaces_method(string[] text_array)
    {
        List<int> counts = new List<int>();
        for (int i = 0; i < text_array.Length; i++)
        {
            int count = text_array[i].Count(Char.IsWhiteSpace);
            counts.Add(count);
        }
        int the_smallest_number_of_spaces = counts.IndexOf(counts.Min()) + 1;
        return the_smallest_number_of_spaces;
    }
}