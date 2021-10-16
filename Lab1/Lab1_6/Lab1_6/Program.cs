Console.Write("Введите число = ");
int numb = Convert.ToInt16(Console.ReadLine());
int res = (numb % 10) * (numb / 10 % 10) * (numb / 100 % 10) * (numb / 1000);
Console.WriteLine("Произведение цифр = " + res);