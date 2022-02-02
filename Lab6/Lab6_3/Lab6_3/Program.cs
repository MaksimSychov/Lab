using System;
using System.IO;
public class Third
{
    public static void Main()
    {
        string directory = @"E:\Университет\Lab6\Lab6_3";

        string firstFilePath = directory + "\\lab.txt";
        string secondFilePath = directory + "\\lab2.txt";

        string newText = String.Empty;
        int countOfVoidStrings = 0;

        string[] text = File.ReadAllLines(firstFilePath);
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != "")
            {
                newText += text[i] + "\n";
            }
            else if (text[i + 1] != "")
            {
                newText += "\n" + text[i + 1] + "\n";
                i++;
            }
            else
            {
                countOfVoidStrings++;
            }
        }

        File.WriteAllLines(secondFilePath, newText.Split('\n'));
        Console.WriteLine();
        Console.WriteLine("Count of void strings: " + countOfVoidStrings);
        Console.ReadLine();
    }
}