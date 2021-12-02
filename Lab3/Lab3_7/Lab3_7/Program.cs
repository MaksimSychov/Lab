using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите номер члена ряда Фибоначчи: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number < 0)
        {
            Console.WriteLine("Введите положительное число!");
        }
        else
        {
            Console.WriteLine("Число ряда Фибоначчи: " + Fibonacci(number));
        }
        Console.ReadKey();
    }
    static int Fibonacci(int number)
    {
        if (number == 0 | number == 1)
        {
            return 1;
        }
        return Fibonacci(number - 1) + Fibonacci(number - 2);
    }
}