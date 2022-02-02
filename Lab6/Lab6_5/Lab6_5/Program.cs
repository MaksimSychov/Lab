using System;
using System.IO;
public class Fifth
{
    public static void Main()
    {
        string[] fileNames = Directory.GetFiles(@"E:\Университет\Lab6\Lab6_5\images");
        Console.WriteLine("Текущие файлы в директории:");
        for (int i = 0; i < fileNames.Length; i++)
        {
            Console.WriteLine(fileNames[i]);
        }
        Console.WriteLine("Введите имя файла:");
        string fileName = @"E:\Университет\Lab6\Lab6_5\images\" + Console.ReadLine();
        using (var reader = new BinaryReader(File.OpenRead(fileName)))
        {
            reader.BaseStream.Position = 2;
            Console.WriteLine($"Размер файла в байтах: {reader.ReadInt32()}");
            reader.BaseStream.Position = 18;
            Console.WriteLine($"Ширина изображения в пикселях: {reader.ReadInt32()}");
            reader.BaseStream.Position = 22;
            Console.WriteLine($"Высота изображения в пикселях: {reader.ReadInt32()}");
            reader.BaseStream.Position = 28;
            Console.WriteLine($"Количество бит на пиксель: {reader.ReadInt16()}");
            reader.BaseStream.Position = 38;
            Console.WriteLine($"Горизонтальное разрешение, пиксел/м: {reader.ReadInt32()}");
            reader.BaseStream.Position = 42;
            Console.WriteLine($"Вертикальное разрешение, пиксел/м: {reader.ReadInt32()}");
            reader.BaseStream.Position = 30;
            Console.WriteLine($"Тип сжатия: {reader.ReadInt32()}");
        }
    }
}