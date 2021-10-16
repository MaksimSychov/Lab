using System;
class Program
{
    static void Main()
    {
        Console.Write("часы: ");
        int h = Convert.ToInt32(Console.ReadLine());
        if (h > 23 || h < 0)
        {
            Console.WriteLine("Ошибка");
        } else
        {
            Console.Write("минуты: ");
            int m = Convert.ToInt32(Console.ReadLine());
            if (m > 59 || m < 0)
            {
                Console.WriteLine("Ошибка");
            } else
            {
                Console.Write("секунды: ");
                int s = Convert.ToInt32(Console.ReadLine());
                if (s > 59 || s < 0)
                {
                    Console.WriteLine("Ошибка");
                } else
                {
                    int sum = (h * 3600) + (m * 60) + s;
                    int corner = (sum / 10) % 360;
                    Console.WriteLine("Угол = " + corner + " градусов");
                }
                
            }
        }
    }
       
}