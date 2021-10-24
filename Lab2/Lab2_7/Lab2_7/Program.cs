Console.WriteLine("Введите x: ");
double x = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите y: ");
double y = Convert.ToDouble(Console.ReadLine());
if (x > 0)
{
    if (y > 0)
        Console.WriteLine("Ответ: I четверть");
    else if (y < 0)
        Console.WriteLine("Ответ: IV четверть");
    else if (y == 0)
        Console.WriteLine("Ответ: 0");
}
else if (x < 0)
{
    if (y > 0)
        Console.WriteLine("Ответ: II четверть");
    else if (y < 0)
        Console.WriteLine("Ответ: III четверть");
    else if (y == 0)
        Console.WriteLine("Ответ: 0");
}
else if (x == 0) 
{
    Console.WriteLine("Ответ: 0");
}
Console.ReadKey();