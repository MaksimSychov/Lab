using System;
using System.Linq;
using System.IO;
public class First
{
    static void shellSort(int[] array, int length, out ulong countOfTranspositions)
    {
        countOfTranspositions = 0;
        int[] steps = { 57, 23, 10, 4, 1 };
        foreach (int step in steps) 
        {
            for (int i = step; i < length; i++)
            {
                int j = i;
                int temp = array[i];
                while (j >= step && temp > array[j - step])
                {
                    array[j] = array[j - step];
                    j -= step;
                }
                array[j] = temp;
                if (j != i)
                {
                    countOfTranspositions++;
                }
            }
        }
        if (countOfTranspositions > 0) 
        {
            countOfTranspositions--;
        }
    }
    public static void Main()
    {
        ulong countOfComparisons = 0, countOfTranspositions;
        TimeSpan workTime = new TimeSpan();
        string indexOfNumber = String.Empty;
        int length = 100000;
        int[] array = new int[length];
        using (StreamReader readArray = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"E:\Университет\Lab7\Lab7_2\sorted.dat")))
        {
            try
            {
                try
                {
                    Console.WriteLine("Чтение массива из файла...");
                    for (int i = 0; i < array.Length; i++) 
                    {
                        array[i] = int.Parse(readArray.ReadLine());
                    }
                    Console.WriteLine("Проверка массива...");
                    shellSort(array, length, out countOfTranspositions);
                    if (countOfTranspositions == 0)
                    {
                        Console.WriteLine("Массив отсортирован\n");
                    }
                    else 
                    {
                        Console.WriteLine("Массив не отсортирован\n");
                    }
                }
                catch (ArgumentNullException)
                {
                    bool isEmpty = true;
                    foreach (int number in array) 
                    {
                        if (number != 0) 
                        {
                            isEmpty = false;
                        }
                    }
                    if (isEmpty)
                    {
                        Console.WriteLine("Файл пуст!\n");
                    }
                    else 
                    {
                        Console.WriteLine("Массив не заполнен\n");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Массив сломан\n");
            }
        }
        int select = 0;
        while (true)
        {
            Console.Write("Выберите алгоритм поиска:\nлинейный - (1)\nбинарный - (2)\nинтерполяционный - (3)\nвыход - (4)\n");
            select = int.Parse(Console.ReadLine());
            if (select == 4) 
            {
                break;
            }
            if (select != 1 && select != 2 && select != 3) 
            {
                continue;
            }
            Console.Write("Введите номер, который вы хотите найти: ");
            int numberToSearch = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    Console.WriteLine("\nЛинейный поиск:\n");
                    linearSearch(array, numberToSearch, out indexOfNumber, out countOfComparisons, out workTime);
                    break;
                case 2:
                    Console.WriteLine("\nБинарный поиск:\n");
                    binarySearch(array, numberToSearch, out indexOfNumber, out countOfComparisons, out workTime);
                    break;
                case 3:
                    Console.WriteLine("\nИнтерполяционный поиск:\n");
                    interpSearch(array, numberToSearch, out indexOfNumber, out countOfComparisons, out workTime);
                    break;
                default:
                    break;
            }
            if (indexOfNumber != String.Empty)
            {
                Console.WriteLine("Индексы числа: {0}", indexOfNumber);
            }
            else 
            {
                Console.WriteLine("Не найдено");
            } 
            Console.WriteLine("Время работы алгоритма: {0}", workTime);
            Console.WriteLine("Количество сравнений: {0}\n", countOfComparisons);
        }
    }
    public static void linearSearch(int[] array, int numberToSearch, out string indexOfNumber, out ulong countOfComparisons, out TimeSpan workTime)
    {
        indexOfNumber = String.Empty;
        countOfComparisons = 0;
        DateTime startTime = DateTime.Now;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == numberToSearch) 
            {
                indexOfNumber += i + " ";
            }
            countOfComparisons++;
        }
        DateTime endTime = DateTime.Now;
        workTime = endTime - startTime;
    }
    public static void binarySearch(int[] array, int numberToSearch, out string indexOfNumber, out ulong countOfComparisons, out TimeSpan workTime)
    {
        indexOfNumber = String.Empty;
        countOfComparisons = 0;
        int left = 0, right = array.Length - 1;
        DateTime startTime = DateTime.Now;
        while (right >= left)
        {
            int mid = (left + right) / 2;
            if (array[mid] == numberToSearch) 
            {
                indexOfNumber += mid + " ";
            }
            if (numberToSearch > array[mid])
            {
                right = mid - 1;
            }
            else 
            {
                left = mid + 1;
            }
            countOfComparisons++;
        }
        DateTime endTime = DateTime.Now;
        workTime = endTime - startTime;
    }
    public static void interpSearch(int[] array, int numberToSearch, out string indexOfNumber, out ulong countOfComparisons, out TimeSpan workTime)
    {
        indexOfNumber = String.Empty;
        countOfComparisons = 0;
        int left = 0, right = array.Length - 1;
        DateTime startTime = DateTime.Now;
        while (right >= left)
        {
            int mid = left + (right - left) * (numberToSearch - array[left]) / (array[right] - array[left]);
            if (numberToSearch > array[mid])
            {
                right = mid - 1;
                countOfComparisons++;
            }
            else if (numberToSearch < array[mid])
            {
                left = mid + 1;
                countOfComparisons++;
            }
            else
            {
                indexOfNumber += mid + " ";
                break;
            }
        }
        DateTime endTime = DateTime.Now;
        workTime = endTime - startTime;
    }
}