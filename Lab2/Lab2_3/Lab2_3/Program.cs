int[] f = new int[20];
int result = 0;
f[0] = 1;
f[1] = 1;
for (int i = 2; i < f.Length; i++)
{
    f[i] = f[i - 1] + f[i - 2];
    if (f[i] > 10000)
    {
        break;
    }
}
for (int i = 0; i < f.Length; i++)
{
    if (f[i] > 999 && f[i] < 10000)
    {
        result++;
    }
}
Console.WriteLine("Количество четырехзначных чисел в ряде Фибоначчи = " + result);
Console.ReadKey();