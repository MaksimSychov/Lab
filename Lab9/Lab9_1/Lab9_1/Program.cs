using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


class First
{
    enum Pos
    {
        П,
        С,
        А
    }
    struct Worker
    {
        public string surname;
        public Pos position;
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
            Console.WriteLine("{0, -20}: {1, -15} {2, -15}", time, operation, name);
        }
    }
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        int count;
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if (head == null)
            {
                head = node;
            }               
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }                   
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }                  
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }    
                count--;
                return true;
            }
            return false;
        }
        public void Change(T dataToChange, T newData)
        {
            DoublyNode<T> node = new DoublyNode<T>(dataToChange);
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(dataToChange))
                {
                    break;
                }               
                current = current.Next;
            }
            current.Data = newData;
        }
        public int Count { get { return count; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }                
                current = current.Next;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    static void Main(string[] args)
    {
        string choose = String.Empty;
        Console.Write("Введите 1, если вы хотите использовать таблицу с двойным списком\nВведите 2, если хотите использовать коллекцию .NET List\n");
        choose = Console.ReadLine();
        if (choose == "1")
        {
            Console.Write("Использование двусвязного списка\n");
            var logOfSession = new DoublyLinkedList<Log>();
            DateTime firstTime = DateTime.Now;
            DateTime secondTime = DateTime.Now;
            TimeSpan downtime = secondTime - firstTime;

            Worker Иванов;
            Иванов.surname = "Иванов И.И.";
            Иванов.position = Pos.П;
            Иванов.year = 1975;
            Иванов.salary = 4170.50M;

            Worker Петренко;
            Петренко.surname = "Петренко П.П.";
            Петренко.position = Pos.С;
            Петренко.year = 1996;
            Петренко.salary = 790.10M;

            Worker Сидоревич;
            Сидоревич.surname = "Сидоревич М.С.";
            Сидоревич.position = Pos.А;
            Сидоревич.year = 1990;
            Сидоревич.salary = 2200.00M;

            var table = new DoublyLinkedList<Worker>();
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
                    foreach (var item in table)
                    {
                        item.showTable();
                    }
                    Console.WriteLine($"{"|Перечисляемый тип: П - преподаватель, С - студент, А - аспирант",-75}|");
                    Console.WriteLine(new String('-', 76));
                }
                else if (selector == 2)
                {
                    Console.Write("Введите фамилию: ");
                    string surname = Console.ReadLine();
                    var position = new Pos();
                    int year = 0;
                    decimal salary = 0;
                    do
                    {
                        Console.Write("Введите должность (П - преподаватель, С - студент, А - аспирант): ");
                        string pos = Console.ReadLine();
                        if (pos == "П")
                        {
                            position = Pos.П;
                            error = false;
                        }
                        else if (pos == "С")
                        {
                            position = Pos.С;
                            error = false;
                        }
                        else if (pos == "А")
                        {
                            position = Pos.А;
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
                else if (selector == 3)
                {
                    string s = String.Empty;
                    bool deleted = false;
                    string surname = string.Empty;
                    do
                    {
                        Console.WriteLine("Введите полное имя, которое вы хотите удалить: ");
                        s = Console.ReadLine();
                        foreach (var item in table)
                        {
                            if (item.surname == s)
                            {
                                table.Remove(item);
                                deleted = true;
                                surname = s;
                                error = false;
                                break;
                            }
                        }
                        if (!deleted)
                        {
                            Console.WriteLine("Таких работников нет!");
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
                else if (selector == 4)
                {
                    string s = String.Empty;
                    string oldSurname = string.Empty;
                    string surname = string.Empty;
                    var position = new Pos();
                    int year = 0;
                    decimal salary = 0;
                    bool exist = true;
                    do
                    {
                        Console.WriteLine("Напишите полное имя работника, которого вы хотите изменить: ");
                        s = Console.ReadLine();
                        foreach (var item in table)
                        {
                            if (item.surname == s)
                            {
                                oldSurname = item.surname;
                                Console.Write("Введите полное имя: ");
                                surname = Console.ReadLine();
                                do
                                {
                                    Console.Write("Введите должность (П - преподаватель, С - студент, А - аспирант): ");
                                    string pos = Console.ReadLine();
                                    if (pos == "П")
                                    {
                                        position = Pos.П;
                                        error = false;
                                    }
                                    else if (pos == "С")
                                    {
                                        position = Pos.С;
                                        error = false;
                                    }
                                    else if (pos == "А")
                                    {
                                        position = Pos.А;
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

                                Worker newWorker;
                                newWorker.surname = surname;
                                newWorker.position = position;
                                newWorker.year = year;
                                newWorker.salary = salary;
                                table.Change(item, newWorker);
                                exist = true;
                            }
                        }
                    }
                    while (error);
                    error = true;

                    if (!exist)
                    {
                        Console.WriteLine("Введите правильное полное имя!");
                    }

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
                else if (selector == 5)
                {
                    Pos pos = new Pos();
                    do
                    {
                        Console.WriteLine("Введите кого вы хотите найти (П - преподаватель, С - студент, А - аспирант): ");
                        string select = Console.ReadLine();
                        Console.WriteLine();
                        if (select == "П" || select == "С" || select == "А")
                        {
                            if (select == "П")
                            {
                                pos = Pos.П;
                            }
                            if (select == "С")
                            {
                                pos = Pos.С;
                            }
                            if (select == "А")
                            {
                                pos = Pos.А;
                            }
                            foreach (var item in table)
                            {
                                if (item.position == pos)
                                {
                                    item.showTable();
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
                else if (selector == 6)
                {
                    foreach (var item in logOfSession)
                    {
                        item.logOutput();
                    }
                    Console.WriteLine();
                    Console.WriteLine(downtime + " - Самый долгий период бездействия пользователя");
                    Console.WriteLine();
                }
                else if (selector == 7)
                {
                    working = false;
                }
                else if (selector < 1 || selector > 7)
                {
                    Console.WriteLine("Выберите действие от 1 до 7!");
                    Console.WriteLine();
                }
            }
            while (working);
            Console.WriteLine();
        }            
        else if (choose == "2")
        {
            Console.Write("Использование коллекции .NET List\n");
            var logOfSession = new List<Log>(50);
            DateTime firstTime = DateTime.Now;
            DateTime secondTime = DateTime.Now;
            TimeSpan downtime = secondTime - firstTime;

            Worker Иванов;
            Иванов.surname = "Иванов И.И.";
            Иванов.position = Pos.П;
            Иванов.year = 1975;
            Иванов.salary = 4170.50M;

            Worker Петренко;
            Петренко.surname = "Петренко П.П.";
            Петренко.position = Pos.С;
            Петренко.year = 1996;
            Петренко.salary = 790.10M;

            Worker Сидоревич;
            Сидоревич.surname = "Сидоревич М.С.";
            Сидоревич.position = Pos.А;
            Сидоревич.year = 1990;
            Сидоревич.salary = 2200.00M;

            var table = new List<Worker>();
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
                    var position = Pos.А;
                    int year = 0;
                    decimal salary = 0;
                    do
                    {
                        Console.Write("Введите должность (П - преподаватель, С - студент, А - аспирант): ");
                        string pos = Console.ReadLine();
                        if (pos == "П")
                        {
                            position = Pos.П;
                            error = false;
                        }
                        else if (pos == "С")
                        {
                            position = Pos.С;
                            error = false;
                        }
                        else if (pos == "А")
                        {
                            position = Pos.А;
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
                    var position = Pos.А;
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
                                    position = Pos.П;
                                    error = false;
                                }
                                else if (pos == "С")
                                {
                                    position = Pos.С;
                                    error = false;
                                }
                                else if (pos == "А")
                                {
                                    position = Pos.А;
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
                    var pos = Pos.П;
                    do
                    {
                        Console.WriteLine("Введите кого вы хотите найти (П - преподаватель, С - студент, А - аспирант): ");
                        string select = Console.ReadLine();
                        Console.WriteLine();
                        if (select == "П" || select == "С" || select == "А")
                        {
                            if (select == "П")
                            {
                                pos = Pos.П;
                            }
                            if (select == "С")
                            {
                                pos = Pos.С;
                            }
                            if (select == "А")
                            {
                                pos = Pos.А;
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
        else 
        {
            Console.WriteLine("Выберите действие 1 или 2!");
            Console.WriteLine();
        }
    }
}