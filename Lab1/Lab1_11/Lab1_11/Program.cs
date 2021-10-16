Console.Write("Введите a: ");
double a = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите b: ");
double b = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите x: ");
double x = Convert.ToInt32(Console.ReadLine());

double e = 2.72;

Console.Write("Введите k: ");
int k = Convert.ToInt32(Console.ReadLine());

int z = (int)Math.Sqrt(a * x * Math.Sin(k) * (2 * x) + Math.Pow(e, -2 * x) * (x + b));
double w = (Math.Pow(Math.Cos(Math.Pow(k, 3)), 2) - x) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

Console.WriteLine("z = {0}, w = {1}", z, w);
Console.ReadKey();