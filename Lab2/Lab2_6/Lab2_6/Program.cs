class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число: ");
        int n = int.Parse(Console.ReadLine());
        int[] exceptions = { 11, 12, 13, 14 };
        if (exceptions.Contains(n))
        {
            Console.WriteLine(n + " лет");
        }
        else if (n % 10 == 1)
        {
            Console.WriteLine(n + "год");
        }
        else if (n % 10 == 2 || n % 10 == 3 || n % 10 == 4)
        {
            Console.WriteLine(n + " года");
        }
        else
        {
            Console.WriteLine(n + " лет");
        }
        Console.ReadKey();
    }
}

