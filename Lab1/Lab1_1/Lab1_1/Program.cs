using System;
class Program
{
    static int a(double number)
    {
        int d = 0;
        return d = int.Parse(number.ToString()[number.ToString().IndexOf(',') + 1].ToString());
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Ответ: {0}", a(27.3198));
        Console.ReadKey();
    }
}