using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


public class Seventh
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        int count;
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
        public int Count { get { return count; } }
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
        string[] words;
        int select = 0;
        using (StreamReader text = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"E:\Университет\Lab9\Lab9_6\sixth.txt")))
        {
            words = text.ReadToEnd().ToLower().Split(new char[] { ' ', ',', '-', '.', ';', ':', '?', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }          
        while (select != 1 && select != 2)
        {
            Console.Write("Введите 1, чтобы использовать .NET list\nВведите 2, чтобы использовать new list\n");
            select = int.Parse(Console.ReadLine());
        }
        if (select == 1)
        {
            List<string> list = new List<string>();
            foreach (string word in words)
            {
                if (!list.Contains(word))
                {
                    list.Add(word);
                }                 
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }              
        }
        else if (select == 2)
        {
            LinkedList<string> list = new LinkedList<string>();
            foreach (string word in words)
            {
                if (!list.Contains(word))
                {
                    list.Add(word);
                }             
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }             
        }
    }
}