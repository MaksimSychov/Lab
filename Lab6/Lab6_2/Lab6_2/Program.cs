using System;
using System.IO;
using System.Text.RegularExpressions;
public class Second
{
    public static void Main()
    {
        string directory = @"E:\Университет\Lab6\Lab6_2";
        string firstFilePath = directory + "\\lab.dat";
        string secondFilePath = directory + "\\lab2.dat";

        string setOfCouples = String.Empty;
        string secondNumbers = String.Empty;
        string textFromFile = String.Empty;

        var directoryInfo = new DirectoryInfo(directory);
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        using (BinaryWriter writeToTheFirstFile = new BinaryWriter(new FileStream(firstFilePath, FileMode.OpenOrCreate)))
        {
            for (int N = 1; N <= 100; N++)
            {
                setOfCouples += N + " - 2^" + N + "\n";
            }
            writeToTheFirstFile.Write(setOfCouples);
            Console.WriteLine("Набор записывается в файл");
            writeToTheFirstFile.Close();
        }

        using (BinaryReader readFromTheFirstFile = new BinaryReader(new FileStream(firstFilePath, FileMode.Open)))
        {
            textFromFile = readFromTheFirstFile.ReadString();
            Regex numbers = new Regex(@"(\b2)(\^)(\d*\b)");
            MatchCollection matches = numbers.Matches(textFromFile);
            foreach (Match match in matches)
            {
                secondNumbers += match.Value + "\n";
            }
            Console.WriteLine("Числа найдены");
            readFromTheFirstFile.Close();
        }

        using (BinaryWriter writeToTheSecondFile = new BinaryWriter(new FileStream(secondFilePath, FileMode.Create)))
        {
            writeToTheSecondFile.Write(secondNumbers);
            Console.WriteLine("Числа записываются в файл");
            writeToTheSecondFile.Close();
        }
        Console.ReadKey();
    }
}