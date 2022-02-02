using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
public class First
{
    enum Type
    {
        П,
        С,
        А
    }

    struct Worker
    {
        public string surname;
        public Type position;
        public int year;
        public decimal salary;

        public void showTable()
        {
            Console.WriteLine($"|{surname,-24}|{position,-12}|{year,-20}|{salary,-15}|");
            Console.WriteLine(new String('-', 76));
        }
    }

    struct Log
    {
        public DateTime time;
        public string operation;
        public string name;

        public void logOutput()
        {
            Console.WriteLine("{0, -20} : {1, -15} {2, -15}", time, operation, name);
        }
    }

    public static void CreateFile(string directory, string path)
    {
        var directoryInfo = new DirectoryInfo(directory);
        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }
        FileStream file = new FileStream(path, FileMode.OpenOrCreate);
        file.Close();
    }

    public static void Main(string[] args)
    {
        var table = new List<Worker>();

        string directory = @"E:\Университет\Lab7\Lab7_1";
        string path = directory + "\\lab.dat";
        CreateFile(directory, path);

        using (StreamReader readFile = new StreamReader(path))
        {
            while (!readFile.EndOfStream)
            {
                string surname = readFile.ReadLine();
                string pos = readFile.ReadLine();
                var position = Type.А;
                if (pos == "П")
                {
                    position = Type.П;
                }
                else if (pos == "С")
                {
                    position = Type.С;
                }
                else if (pos == "А")
                {
                    position = Type.А;
                }
                int year = int.Parse(readFile.ReadLine());
                decimal salary = decimal.Parse(readFile.ReadLine());
                Worker newWorker;
                newWorker.surname = surname;
                newWorker.position = position;
                newWorker.year = year;
                newWorker.salary = salary;
                table.Add(newWorker);
            }
        }

        var logOfSession = new List<Log>(50);
        DateTime firstTime = DateTime.Now;
        DateTime secondTime = DateTime.Now;
        TimeSpan downtime = secondTime - firstTime;

        Worker Иванов;
        Иванов.surname = "Иванов И.И.";
        Иванов.position = Type.П;
        Иванов.year = 1975;
        Иванов.salary = 4170.50M;

        Worker Петренко;
        Петренко.surname = "Петренко П.П.";
        Петренко.position = Type.С;
        Петренко.year = 1996;
        Петренко.salary = 790.10M;

        Worker Сидоревич;
        Сидоревич.surname = "Сидоревич М.С.";
        Сидоревич.position = Type.А;
        Сидоревич.year = 1990;
        Сидоревич.salary = 2200.00M;

        table.Add(Иванов);
        table.Add(Петренко);
        table.Add(Сидоревич);

        bool working = true;
        bool error = true;
        do
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Просмотр таблицы");
            Console.WriteLine("2 - Добавить запись");
            Console.WriteLine("3 - Удалить запись");
            Console.WriteLine("4 - Обновить запись");
            Console.WriteLine("5 - Поиск записей");
            Console.WriteLine("6 - Просмотреть лог");
            Console.WriteLine("7 - Выход");
            int selector = int.Parse(Console.ReadLine());
            if (selector == 1)
            {
                Console.WriteLine(new String('-', 76));
                Console.WriteLine($"{"|Отдел кадров",-75}|");
                Console.WriteLine(new String('-', 76));
                Console.WriteLine($"{"|Фамилия",-25}|{"Должность",-12}|{"Год рождения",-20}|{"Оклад (грн)",-15}|");
                Console.WriteLine(new String('-', 76));
                for (int i = 0; i < table.Count; i++)
                {
                    table[i].showTable();
                }
                Console.WriteLine($"{"|Перечисляемый тип: П - преподаватель, С - студент, А - аспирант",-75}|");
                Console.WriteLine(new String('-', 76));
            }
            if (selector == 2)
            {
                Console.Write("Введите фамилию: ");
                string surname = Console.ReadLine();
                var position = Type.А;
                int year = 0;
                decimal salary = 0;
                do
                {
                    Console.Write("Введите должность (П - преподаватель, С - студент, А - аспирант): ");
                    string pos = Console.ReadLine();
                    if (pos == "П")
                    {
                        position = Type.П;
                        error = false;
                    }
                    else if (pos == "С")
                    {
                        position = Type.С;
                        error = false;
                    }
                    else if (pos == "А")
                    {
                        position = Type.А;
                        error = false;
                    }
                    else
                    {
                        Console.WriteLine("Введите П, С или А!");
                        Console.WriteLine();
                    }
                }
                while (error);
                error = true;
                do
                {
                    Console.Write("Введите год рождения: ");
                    try
                    {
                        year = int.Parse(Console.ReadLine());
                        error = false;
                    }
                    catch (FormatException)
                    {
                        year = 0;
                        Console.WriteLine("Введены неверные данные!");
                    }
                    catch (OverflowException)
                    {
                        year = 0;
                        Console.WriteLine("Введены неверные данные!");
                    }
                }
                while (error);
                error = true;
                do
                {
                    Console.Write("Введите оклад (грн): ");
                    try
                    {
                        salary = decimal.Parse(Console.ReadLine());
                        error = false;
                    }
                    catch (FormatException)
                    {
                        salary = 0;
                        Console.WriteLine("Введены неверные данные!");
                    }
                    catch (OverflowException)
                    {
                        salary = 0;
                        Console.WriteLine("Введены неверные данные!");
                    }
                }
                while (error);
                error = true;

                Worker newWorker;
                newWorker.surname = surname;
                newWorker.position = position;
                newWorker.year = year;
                newWorker.salary = salary;
                table.Add(newWorker);

                Log newLog;
                newLog.time = DateTime.Now;
                newLog.operation = "Добавлена запись";
                newLog.name = surname;
                logOfSession.Add(newLog);

                firstTime = newLog.time;
                TimeSpan secondDowntime = firstTime - secondTime;
                if (downtime < secondDowntime)
                {
                    downtime = secondDowntime;
                }
                secondTime = newLog.time;
                Console.WriteLine();
            }
            if (selector == 3)
            {
                int number = 0;
                string surname = string.Empty;
                do
                {
                    Console.WriteLine("Выберите номер строки для удаления: ");
                    number = int.Parse(Console.ReadLine());
                    if (number > 0 && number <= table.Count)
                    {
                        surname = table[number - 1].surname;
                        table.RemoveAt(number - 1);
                        error = false;
                    }
                    else
                    {
                        Console.WriteLine("Введите правильный номер!");
                    }
                }
                while (error);
                error = true;

                Log newLog;
                newLog.time = DateTime.Now;
                newLog.operation = "Запись удалена";
                newLog.name = surname;
                logOfSession.Add(newLog);

                firstTime = newLog.time;
                TimeSpan secondDowntime = firstTime - secondTime;
                if (downtime < secondDowntime)
                {
                    downtime = secondDowntime;
                }
                secondTime = newLog.time;
                Console.WriteLine();
            }
            if (selector == 4)
            {
                string oldSurname = string.Empty;
                string surname = string.Empty;
                var position = Type.А;
                int year = 0;
                decimal salary = 0;
                int number = 0;
                do
                {
                    Console.WriteLine("Выберите номер строки для обновления: ");
                    number = int.Parse(Console.ReadLine());
                    if (number > 0 && number <= table.Count)
                    {
                        oldSurname = table[number - 1].surname;
                        Console.Write("Введите фамилию: ");
                        surname = Console.ReadLine();
                        do
                        {
                            Console.Write("Введите должность (П - преподаватель, С - студент, А - аспирант): ");
                            string pos = Console.ReadLine();
                            if (pos == "П")
                            {
                                position = Type.П;
                                error = false;
                            }
                            else if (pos == "С")
                            {
                                position = Type.С;
                                error = false;
                            }
                            else if (pos == "А")
                            {
                                position = Type.А;
                                error = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите П, С или А!");
                                Console.WriteLine();
                            }
                        }
                        while (error);
                        error = true;
                        do
                        {
                            Console.Write("Введите год рождения: ");
                            try
                            {
                                year = int.Parse(Console.ReadLine());
                                error = false;
                            }
                            catch (FormatException)
                            {
                                year = 0;
                                Console.WriteLine("Введены неверные данные!");
                            }
                            catch (OverflowException)
                            {
                                year = 0;
                                Console.WriteLine("Введены неверные данные!");
                            }
                        }
                        while (error);
                        error = true;
                        do
                        {
                            Console.Write("Введите оклад (грн): ");
                            try
                            {
                                salary = decimal.Parse(Console.ReadLine());
                                error = false;
                            }
                            catch (FormatException)
                            {
                                salary = 0;
                                Console.WriteLine("Введены неверные данные!");
                            }
                            catch (OverflowException)
                            {
                                salary = 0;
                                Console.WriteLine("Введены неверные данные!");
                            }
                        }
                        while (error);
                    }
                    else
                    {
                        Console.WriteLine("Введите правильный номер!");
                    }
                }
                while (error);
                error = true;

                Worker editWorker;
                editWorker.surname = surname;
                editWorker.position = position;
                editWorker.year = year;
                editWorker.salary = salary;
                table.Insert(number - 1, editWorker);
                table.Remove(table[number]);

                Log newLog;
                newLog.time = DateTime.Now;
                newLog.operation = "Обновлена запись";
                newLog.name = oldSurname + " --> " + surname;
                logOfSession.Add(newLog);

                firstTime = newLog.time;
                TimeSpan secondDowntime = firstTime - secondTime;
                if (downtime < secondDowntime)
                {
                    downtime = secondDowntime;
                }
                secondTime = newLog.time;
                Console.WriteLine();
            }
            if (selector == 5)
            {
                var pos = Type.П;
                do
                {
                    Console.WriteLine("Введите кого вы хотите найти (П - преподаватель, С - студент, А - аспирант): ");
                    string select = Console.ReadLine();
                    Console.WriteLine();
                    if (select == "П" || select == "С" || select == "А")
                    {
                        if (select == "П")
                        {
                            pos = Type.П;
                        }
                        if (select == "С")
                        {
                            pos = Type.С;
                        }
                        if (select == "А")
                        {
                            pos = Type.А;
                        }
                        for (int i = 0; i < table.Count; i++)
                        {
                            if (table[i].position == pos)
                            {
                                table[i].showTable();
                            }
                        }
                        error = false;
                    }
                    else
                    {
                        Console.WriteLine("Введите П, С или А!");
                    }
                }
                while (error);
                error = true;
                Console.WriteLine();
            }
            if (selector == 6)
            {
                for (int i = 0; i < logOfSession.Count; i++)
                {
                    logOfSession[i].logOutput();
                }
                Console.WriteLine();
                Console.WriteLine(downtime + " - Самый долгий период бездействия пользователя");
                Console.WriteLine();
            }
            if (selector == 7)
            {
                using (StreamWriter newText = new StreamWriter(path, false))
                {
                    for (int i = 0, k = 1; i < table.Count; i++)
                    {
                        newText.WriteLine(k + "){0}\n{1}\n{2}\n{3}\n", table[i].surname, table[i].position, table[i].year, table[i].salary);
                        k++;
                    }
                }
                working = false;
            }
            if (selector < 1 || selector > 7)
            {
                Console.WriteLine("Выберите действие от 1 до 7!");
                Console.WriteLine();
            }
        }
        while (working);
        Console.WriteLine();
    }
}