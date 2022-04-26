using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class First
{
    static TimeSpan workTime;
    static ulong countOfTranspositions = 0;
    static ulong countOfComparisons = 0;
    static DateTime startTime;
    static DateTime endTime;
    const int length = 100000;
    static int countOfCalls = 0;
    public static void Main()
    {
        Random rand = new Random();
        int[] originalArray = new int[length];
        int[] originalSortedArray = new int[length];
        int[] originalReversSortedArray = new int[length];
        int[] array = new int[length];
        int[] sortedArray = new int[length];
        int[] reverseSortedArray = new int[length];
        int[] arrayForCheck = new int[length];
        for (int i = 0; i < length; i++)
        {
            originalArray[i] = rand.Next(-999, 999);
            array[i] = originalArray[i];
            originalSortedArray[i] = array[i];
            originalReversSortedArray[i] = array[i];
        }
        Console.WriteLine("Создается первый массив\n");
        mergeSort(originalSortedArray, 0, originalSortedArray.Length - 1);
        Array.Reverse(originalSortedArray);
        Console.WriteLine("Создается отсортированный массив\n");
        mergeSort(originalReversSortedArray, 0, originalReversSortedArray.Length - 1);
        using (StreamReader readArray = new StreamReader(new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sorted.dat"), FileMode.OpenOrCreate)))
        {
            try
            {
                try
                {
                    bool sorted = true;
                    Console.WriteLine("Чтение массива из файла...");
                    for (int i = 0; i < arrayForCheck.Length; i++)
                    {
                        arrayForCheck[i] = int.Parse(readArray.ReadLine());
                    }                    
                    Console.WriteLine("Контрольный массив...");
                    for (int i = 0; i < arrayForCheck.Length - 1; i++)
                    {
                        if (arrayForCheck[i] < arrayForCheck[i + 1])
                        {
                            sorted = false;
                            break;
                        }
                    }                      
                    if (sorted)
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
                    foreach (int number in arrayForCheck)
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
                Console.WriteLine("Массив разбит\n");
            }
        }
        using (StreamWriter writeArray = new StreamWriter(new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sorted.dat"), FileMode.Create)))
        {
            Console.WriteLine("Запись массива в файл...");
            foreach (int number in originalReversSortedArray)
            {
                writeArray.Write(number + "\n");
            }
            Console.WriteLine("Массив записывается\n");
        }
        Console.WriteLine("Создается обратный массив\n");
        int select = 0;
        while (select != 4)
        {
            Console.WriteLine("Выберите массив:\n1 - случайный массив\n2 - отсортированный по возрастанию массив\n3 - отсортированный по убыванию массив\n4 - если вы хотите выйти\n");
            select = int.Parse(Console.ReadLine());
            countOfCalls = 0;
            switch (select)
            {
                case 1:
                    Console.WriteLine("Выбирается случайный массив\n");
                    SortingCall(array, originalArray);
                    SortingCall(array, originalArray);
                    SortingCall(array, originalArray);
                    break;
                case 2:
                    Array.Copy(originalSortedArray, sortedArray, length);
                    Console.WriteLine("Выбирается упорядоченный по возрастанию массив\n");
                    SortingCall(sortedArray, originalSortedArray);
                    SortingCall(sortedArray, originalSortedArray);
                    SortingCall(sortedArray, originalSortedArray);
                    break;
                case 3:
                    Array.Copy(originalReversSortedArray, reverseSortedArray, length);
                    Console.WriteLine("Выбирается упорядоченный по убыванию массив\n");
                    SortingCall(reverseSortedArray, originalReversSortedArray);
                    SortingCall(reverseSortedArray, originalReversSortedArray);
                    SortingCall(reverseSortedArray, originalReversSortedArray);
                    break;
            }
        }
    }
    static void SortingCall(int[] array, int[] originalArray)
    {
        if (countOfCalls == 3)
        {
            countOfCalls = 0;
        }          
        startTime = DateTime.Now;
        if (countOfCalls == 0)
        {
            mergeSort(array, 0, array.Length - 1);
            Console.WriteLine("Сортировка слиянием выполняется по адресу {0}\nCount транспозиций: {1}\nCount сравнений: {2}\n", workTime, countOfTranspositions, countOfComparisons);
        }
        else if (countOfCalls == 1)
        {
            pyramidalSort(array, 0, array.Length - 1);
            Console.WriteLine("Пирамидальная сортировка выполняется при {0}\nCount транспозиций: {1}\nCount сравнений: {2}\n", workTime, countOfTranspositions, countOfComparisons);
        }
        if (countOfCalls == 2)
        {
            quickSort(array, 0, array.Length - 1);
            Console.WriteLine("Быстрая сортировка выполняется по адресу {0}\nКоличество перемещений: {1}\nКоличество сравнений: {2}\n", workTime, countOfTranspositions, countOfComparisons);
        }
        endTime = DateTime.Now;
        workTime = endTime - startTime;
        countOfComparisons = 0;
        countOfTranspositions = 0;
        Array.Copy(originalArray, array, length);
        countOfCalls++;
    }
    static void mergeSort(int[] array, int left, int right)
    {
        if (right <= left)
        {
            return;
        }           
        int mid = (left + right) / 2;
        mergeSort(array, left, mid);
        mergeSort(array, mid + 1, right);
        merge(array, left, mid, right);
    }
    static void merge(int[] array, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left;
        int j = mid + 1; 
        int k = 0;

        for (k = 0; k < temp.Length; k++)
        {
            if (i > mid)
            {
                temp[k] = array[j++];
            }              
            else if (j > right)
            {
                temp[k] = array[i++];
            }
            else
            {
                temp[k] = (array[i] > array[j]) ? array[i++] : array[j++];
            }             
            countOfTranspositions++;
            countOfComparisons += 3;
        }
        k = 0;
        i = left;
        while (k < temp.Length && i <= right)
        {
            array[i++] = temp[k++];
        }         
    }
    static void pyramidalSort(int[] array, int left, int right)
    {
        int N = right - left + 1;
        for (int i = right; i >= left; i--)
        {
            Heapify(array, i, N);
        }

        while (N > 0)
        {
            Swap(ref array[left], ref array[N - 1]);
            countOfTranspositions++;
            Heapify(array, left, --N);
        }
    }
    static void Heapify(int[] array, int i, int N)
    {
        while (2 * i + 1 < N)
        {
            int k = 2 * i + 1;

            if (2 * i + 2 < N && array[2 * i + 2] <= array[k])
            {
                countOfComparisons++;
                k = 2 * i + 2;
            }
            if (array[i] > array[k])
            {
                Swap(ref array[i], ref array[k]);
                countOfTranspositions++;
                countOfComparisons++;
                i = k;
            }
            else
            {
                break;
            }
        }
    }
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static void quickSort(int[] array, int left, int right)
    {
        if (right <= left)
        {
            return;
        }
        int p = Partition(array, left, right);
        quickSort(array, left, p - 1);
        quickSort(array, p + 1, right);
    }
    static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left - 1;
        int j = right;

        while (i < j)
        {
            while (array[++i] > pivot)
            {
                countOfComparisons++;
            } 
            while (array[--j] < pivot)
            {
                countOfComparisons++;
                if (j == left)
                {
                    break;
                }
            }
            if (i < j)
            {
                Swap(ref array[i], ref array[j]);
                countOfTranspositions++;
                countOfComparisons++;
            }
            else
            {
                break;
            }
        }
        Swap(ref array[i], ref array[right]);
        countOfTranspositions++;
        return i;
    }
}
