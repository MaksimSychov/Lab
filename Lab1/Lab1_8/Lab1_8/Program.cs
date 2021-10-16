double x, res;
Console.WriteLine("Уравнение: 3 * x^4 - 5 * x^3 + 2 * x^2 - x + 7 \nВведите х:");
x = Convert.ToDouble(Console.ReadLine());
res = (((3 * x - 5) * x + 2) * x - 1) * x + 7;
Console.WriteLine("Ответ: {0}", res);
Console.ReadKey();