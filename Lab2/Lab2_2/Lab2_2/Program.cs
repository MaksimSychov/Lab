double epsUnsign = 1, eps = 1, piEps;
decimal pi4 = 1;
Console.Write("Задайте точность вычисления ПИ:");
while (!double.TryParse(Console.ReadLine(), out piEps));
for (int i = 3; epsUnsign > piEps; i += 2)
{
    epsUnsign = 1d / i;
    eps = (-1) * epsUnsign * Math.Sign(eps);
    pi4 = pi4 + (decimal)eps;
}
Console.WriteLine("Значение числа ПИ с точностью\t" + piEps + "\t=  " + pi4 * 4);
Console.ReadKey();