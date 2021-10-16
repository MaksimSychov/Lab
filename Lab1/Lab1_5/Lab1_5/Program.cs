Console.Write("Введите a= ");
int a = int.Parse(Console.ReadLine());
Console.Write("Введите b= ");
int b = int.Parse(Console.ReadLine());
double p = a + b + Math.Sqrt((a * a) + (b * b));
double s = (a * b) / 2;
Console.WriteLine("S=" + s);
Console.WriteLine("P=" + p);
Console.ReadKey();