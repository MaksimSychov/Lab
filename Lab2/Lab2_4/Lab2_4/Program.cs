class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите q: ");
        double q = double.Parse(Console.ReadLine());
        if (q <= 0)
        {
            Console.WriteLine("q должно быть > 0");
        }
        else
        {
            Console.Write("Введите x: ");
            double x = double.Parse(Console.ReadLine());
            double result = 1;
            double y = 1;
            y = (Math.Pow(x, 2) / factorial(2));
            int i = 1;
            while (y >= q)
            {
                result = i % 2 == 1 ? result - y : result + y;
                i++;
                y = (Math.Pow(x, (2 * i)) / factorial(2 * i));
            }
            Console.WriteLine("cos(x) = " + result);
            Console.WriteLine("Количество учтенных слагаемых: " + i);
            Console.ReadKey();
        }
    }
    public static double factorial(double i)
    {
        if (i == 0)
        {
            return 1;
        }
        else
        {
            return i * factorial(i - 1);
        }
    }
}