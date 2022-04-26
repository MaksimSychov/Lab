using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Seventh2
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node(T data)
        {
            Data = data;
        }
        public Node<T> Column;
        public Node<T> Line;
        public int I { get; set; }
        public int J { get; set; }
        public Node<T> Next { get; set; }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;
        public int MaxCount { get { return IndexLine * IndexColumn; } }
        public int IndexLine { get; set; }
        public int IndexColumn { get; set; }
        public LinkedList(int indexLine, int indexColumn)
        {
            IndexLine = indexLine;
            IndexColumn = indexColumn;
        }
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }               
            tail = node;
            count++;
        }
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            Node<T> current = head;
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
        public void Change(int index, T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (index == 0)
                {
                    break;
                }
                index--;
                current = current.Next;
            }
            current.Data = value;
        }
        public bool Update(int i, int j, T data)
        {
            Node<T> current = head;
            int index = 1;
            while (index <= (IndexLine * IndexColumn))
            {
                if (current.I == i && current.J == j)
                {
                    current.Data = data;
                    return true;
                }
                else if (current.Column != null)
                {
                    current = current.Column;
                }
                else
                {
                    current = current.Line;
                }
                index++;
            }
            return true;
        }
        public void Swap(T first, T second)
        {
            Node<T> currentF = head;
            while (currentF != null)
            {
                if (currentF.Data.Equals(first))
                {
                    currentF.Data = second;
                    break;
                }
                currentF = currentF.Next;
            }
            Node<T> currentS = head;
            while (currentS != null)
            {
                if (currentS.Data.Equals(second))
                {
                    currentS.Data = first;
                    break;
                }
                currentS = currentS.Next;
            }
        }
        public T output(int i, int j)
        {
            Node<T> current = head;
            int indexLine = 1;
            int indexColumn = 1;
            while (current != tail.Column || current != tail.Line)
            {
                if (current.I == i && current.J == j)
                {
                    return current.Data;
                }
                else
                {
                    if (current.Column == null)
                    {
                        indexColumn = 1;
                        indexLine++;
                        current = current.Line;
                    }
                    else
                    {
                        indexColumn++;
                        current = current.Column;
                    }
                }
            }
            return tail.Column.Data;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    public static void Main()
    {
        Console.Write("Введите длину матрицы: ");
        int column = Convert.ToInt32(Console.ReadLine());
        int line = Convert.ToInt32(Console.ReadLine());
        var firstMatrix = new LinkedList<int>(column, line);
        var secondMatrix = new LinkedList<int>(column, line);
        for (int i = 0; i < column * line; i++)
        {
            firstMatrix.Add(0);
            secondMatrix.Add(0);
        }

        int select = 0, choise = 0;
        while (select != 6)
        {
            Console.Write("\nВыберите действие, которое нужно выполнить:\n1 - Заполнение матрицы\n2 - Вывод матрицы\n3 - Транспонирование матрицы\n4 - Суммирование матрицы\n5 - Умножение матрицы\n6 - Выход из программы\n");
            select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    while (choise < 1 || choise > 2)
                    {
                        Console.Write("\nВыберите матрицу для заполнения (Введите 1 или 2): ");
                        choise = int.Parse(Console.ReadLine());
                    }
                    if (choise == 1)
                    {
                        firstMatrix = Fill(firstMatrix);
                    } 
                    else if (choise == 2)
                    {
                        secondMatrix = Fill(secondMatrix);
                    } 
                    choise = 0;
                    break;
                case 2:
                    while (choise < 1 || choise > 2)
                    {
                        Console.Write("\nВыберите матрицу для вывода (Введите 1 или 2): ");
                        choise = int.Parse(Console.ReadLine());
                    }
                    if (choise == 1)
                    {
                        Output(firstMatrix);
                    } 
                    else if (choise == 2)
                    {
                        Output(secondMatrix);
                    } 
                    choise = 0;
                    break;
                case 3:
                    while (choise < 1 || choise > 2)
                    {
                        Console.Write("\nВыберите матрицу для транспонирования (Введите 1 или 2): ");
                        choise = int.Parse(Console.ReadLine());
                    }
                    if (choise == 1)
                    {
                        firstMatrix = Transpose(firstMatrix);
                    } 
                    else if (choise == 2)
                    {
                        secondMatrix = Transpose(secondMatrix);
                    } 
                    choise = 0;
                    break;
                case 4:
                    Summation(firstMatrix, secondMatrix);
                    break;
                case 5:
                    Multiplication(firstMatrix, secondMatrix);
                    break;
                case 6:
                    break;
            }
        }
    }
    static LinkedList<int> Fill(LinkedList<int> matrix)
    {
        Random rand = new Random();
        for (int i = 0; i < matrix.Count; i++)
        {
            int value = rand.Next(0, 10);
            int index = rand.Next(0, matrix.Count - 1);
            matrix.Change(index, value);
        }
        return matrix;
    }
    static void Output(LinkedList<int> matrix)
    {
        int limit = 0;
        Console.WriteLine();
        foreach (var item in matrix)
        {
            Console.Write("{0, -3}", item);
            limit++;
            if (limit == (int)Math.Sqrt(matrix.Count))
            {
                Console.WriteLine("\n");
                limit = 0;
            }
        }
    }
    static LinkedList<int> Transpose(LinkedList<int> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            int firstIndex = 1;
            int secondIndex = firstIndex + matrix.Count - 1;
            int count = 3;
            matrix.Swap(firstIndex, secondIndex);
            if (firstIndex % matrix.Count == matrix.Count - 1)
            {
                firstIndex += count;
                secondIndex = firstIndex + matrix.Count - 1;
                count++;
            }
            else
            {
                firstIndex++;
                secondIndex += 5;
            }
        }
        return matrix;
    }
    static void Summation(LinkedList<int> firstM, LinkedList<int> secondM)
    {
        var sum = firstM.Zip(secondM, (first, second) => first + second);
        int limit = 0;
        Console.WriteLine();
        foreach (var item in sum)
        {
            Console.Write("{0, -3}", item);
            limit++;
            if (limit == (int)Math.Sqrt(sum.Count()))
            {
                Console.WriteLine("\n");
                limit = 0;
            }
        }
    }
    static void Multiplication(LinkedList<int> firstM, LinkedList<int> secondM)
    {
        LinkedList<int> List3 = new LinkedList<int>(firstM.IndexColumn, secondM.IndexLine);
        int temp = 0;
        for (int k = 1; k <= firstM.IndexColumn; k++)
        {
            for (int i = 1; i <= firstM.IndexColumn; i++)
            {
                for (int j = 1; j <= secondM.IndexLine; j++)
                {
                    temp += firstM.output(k, j) * secondM.output(j, i);
                }
                List3.Add(temp);
                temp = 0;
            }
        }
        foreach (int i in List3)
        {
            Console.Write(i + " ");
        }
    }
}