Console.Write("Введите a: ");
double a = Convert.ToDouble(Console.ReadLine());
Console.Write("Введите b ");
double b = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"{a} = {b}");
(a, b) = (b, a);
Console.WriteLine($"{a} = {b}");