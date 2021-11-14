class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество элементов массива: ");
        int n = int.Parse(Console.ReadLine());
        if (n % 2 == 0)
        {
            int[] array = new int[n];
            //Заполнение массива
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(25);
            }
            Console.WriteLine("Массив:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            bool T = true;
            if (n == 0 || n == 1)
            {
                T = false;
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])  //если текущий элемент массива больше, чем следующий, то T=false 
                {
                    T = false;
                }
            }
            Console.WriteLine(T);
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Число должно быть чётное!");
        }
    }
}