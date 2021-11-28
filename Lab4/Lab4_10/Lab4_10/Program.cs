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
		Console.WriteLine("Введите текст: ");
		string text = Console.ReadLine();
		Regex data = new Regex(@"(\b\d{2}-\d{2}-\d{4}\b)");
		MatchCollection matches = data.Matches(text);
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                Console.WriteLine("Найдена дата: " + match.Value);
            }
        }
        else
        {
            Console.WriteLine("Данной даты не существует!");
        }
    }
}