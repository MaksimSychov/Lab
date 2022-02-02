using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
public class Fourth
{
    public static void Main()
    {
        string directory = @"E:\Университет\Lab6\Lab6_4\Lab6_Temp";
        string firstFilePath = @"E:\Университет\Lab6\Lab6_1\lab.dat";
        string copyFilePath = @"E:\Университет\Lab6\Lab6_4\Lab6_Temp\lab.dat";
        string backupFilePath = directory + "\\lab_backup.dat";

        var directoryInfo = new DirectoryInfo(directory);
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        if (File.Exists(copyFilePath))
        {
            File.Delete(copyFilePath);
        }
        File.Copy(firstFilePath, copyFilePath);
        List<byte> byteList = new List<byte>();
        string text;
        using (StreamReader sr = new StreamReader(firstFilePath, System.Text.Encoding.UTF8))
        {
            text = sr.ReadToEnd();
        }
        using (FileStream fstream = new FileStream(backupFilePath, FileMode.OpenOrCreate))
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(text);
            fstream.Write(array, 0, array.Length);
            Console.WriteLine("Текст из файла \"lab.dat\" записан в файл \"lab_backup.dat\"");
        }

        FileInfo fileInf = new FileInfo(backupFilePath);
        Console.WriteLine();
        Console.WriteLine("Информация о файле lab.dat");
        Console.WriteLine("Размер файла: " + fileInf.Length);
        Console.WriteLine("Время последнего изменения: " + fileInf.LastWriteTime);
        Console.WriteLine("Время последнего доступа: " + fileInf.LastAccessTime);

        Console.ReadKey();
    }
}