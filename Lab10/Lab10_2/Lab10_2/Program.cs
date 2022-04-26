using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Second
{
    public static void Main()
    {
        int[] values = { 1, 2, 5, 10, 20, 50, 100 };
        int[] bills = new int[100];
        Random rand = new Random();
        Console.Write("Купюры: ");
        for (int i = 0; i < bills.Length; i++)
        {
            bills[i] = values[rand.Next(0, values.Length)];
            Console.Write(bills[i] + " ");
        }
        Console.Write("\n\nОтсортированные купюры: ");
        Sort(bills, 0, bills.Length - 1);
        foreach (int i in bills)
        {
            Console.Write(i + " ");
        }         
    }
    static void Sort(int[] array, int left, int right)
    {
        int min = 0, max = 0;
        for (int i = left; i <= right; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }                
            else if (array[i] > max)
            {
                max = array[i];
            }   
        }
        int bn = max - min + 1;
        int[] buckets = new int[bn];

        for (int i = left; i <= right; i++)
        {
            buckets[array[i] - min]++;
        }         
        int idx = 0;
        for (int i = min; i <= max; i++)
        {
            for (int j = 0; j < buckets[i - min]; j++)
            {
                array[idx++] = i;
            }              
        }
    }
}