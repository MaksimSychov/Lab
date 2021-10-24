Console.Write("Введи число от 1 до 10000: ");
int a = int.Parse(Console.ReadLine());
if (a > 0 && a < 10001)
{
    for (int i = 1; i <= a; i++)
    {
        if (a % 2 == 0)
        {
            if (a % i == 0 && i % 2 == 0)
            {               
                Console.Write("{0} ", i);               
            }
        } else
        {
            Console.Write("Не найдено чётного делителя!");
            break;
        }
    }
} else
{
    Console.Write("Ошибка, число должно быть больше нуля и меньше 10001!");
}
Console.ReadKey();