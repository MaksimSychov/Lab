Console.Write("Ввести a1:  ");
double a1 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести b1:  ");
double b1 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести c1:  ");
double c1 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести a2:  ");
double a2 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести b2:  ");
double b2 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести c2:  ");
double c2 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести a3:  ");
double a3 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести b3:  ");
double b3 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести c3:  ");
double c3 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести d1:  ");
double d1 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести d2:  ");
double d2 = Convert.ToDouble(Console.ReadLine());
Console.Write("Ввести d3:  ");
double d3 = Convert.ToDouble(Console.ReadLine());

double opredelitel = (a1 * b2 * c3) + (a2 * b3 * c1) + (a3 * b1 * c2) - (a3 * b2 * c1) - (a1 * b3 * c2) - (a2 * b1 * c3);
if (opredelitel == 0)
{
    Console.WriteLine("Ошибка");
} else
{
    double deltax = (d1 * ((b2 * c3) - (b3 * c2))) + (-d2 * ((b1 * c3) - (b3 * c1))) + (d3 * ((b1 * c2) - (b2 * c1)));
    double deltay = (-d1 * ((a2 * c3) - (a3 * c2))) + (d2 * ((a1 * c3) - (a3 * c1))) + (-d3 * ((a1 * c2) - (a2 * c1)));
    double deltaz = (d1 * ((a2 * b3) - (a3 * b2))) + (-d2 * ((a1 * b3) - (a3 * b1))) + (d3 * ((a1 * b2) - (a2 * b1)));
    double x = deltax / opredelitel;
    double y = deltay / opredelitel;
    double z = deltaz / opredelitel;

    Console.WriteLine("x = {0}, y = {1}, z = {2}", x, y, z);
    Console.ReadKey();
}

