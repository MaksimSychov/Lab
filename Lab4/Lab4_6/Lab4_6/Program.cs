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
        Console.WriteLine("Введите строку вида \"a + b = c\": ");
        string text = Console.ReadLine();
        int count = 1;
        Regex regular = new Regex(@"-?\d+");
        MatchCollection nums = regular.Matches(text);
        foreach (Match match in nums)
        {
            int num = int.Parse(match.Value);
            Console.Write($"{count}) равняется " + num + " ");
            count++;
        }
        Console.ReadKey();
    }
}