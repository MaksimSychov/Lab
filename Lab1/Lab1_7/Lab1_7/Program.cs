Console.Write("Введите a: ");
double a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите b: ");
double b = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите c: ");
double c = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Число = {0}{1}{2}", a, b, c);
Console.WriteLine("Reserved = {0}{1}{2}", c, b, a);
Console.ReadKey();