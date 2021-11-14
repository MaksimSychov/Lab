using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static void Main(string[] args)
    {
        int[,] array_1 = new int[9, 9];
        int MainDiagonal;
        int SideDiagonal;      

        //Заполнение массива
        Random random = new Random();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                array_1[i, j] = random.Next(0, 10);
            }
        }

        //Вывод массива
        Console.WriteLine("Матрица 9x9:");
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(array_1[i, j] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        //Главная диагональ
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i == j)
                {
                    MainDiagonal = array_1[i, j];
                    array_1[i, j] = array_1[i, 9 - 1 - i];
                    array_1[i, 9 - 1 - i] = MainDiagonal;
                }
            }
        }        

        //Побочная диагональ   
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i + j == 9 - 1)
                {
                    SideDiagonal = array_1[i, j];
                    array_1[i, j] = array_1[9 - 1 - i, i];
                    array_1[9 - 1 - i, i] = SideDiagonal;
                }
            }
        }

        //Отображение главной и побочной диагонали симметрично относительно вертикальной оси
        Console.WriteLine("Отображение главной и побочной диагонали симметрично относительно вертикальной оси:");
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Console.Write(array_1[i, j] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}