using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Second
{
    public static void Main()
    {
        Console.Write("Введите пример: ");
        string example = Console.ReadLine();
        string brackets = String.Empty;
        foreach (char bracket in example)
        {
            if (bracket == '(' || bracket == ')')
            {
                brackets += bracket;
            }              
        }           
        Stack<char> stack = new Stack<char>();
        foreach (char bracket in brackets)
        {
            if (bracket == '(')
            {
                stack.Push(bracket);
            }   
            else if (bracket == ')' && stack.Count != 0)
            {
                stack.Pop();
            }
        }
        if (stack.Count == 0)
        {
            Console.WriteLine("Пример правильный!");
        }
        else
        {
            Console.WriteLine("В примере есть ошибки!");
        }          
    }
}