using System;
using System.Collections;
namespace Table {
    public class Lab1_10 {
        public enum Type
        {
            П, С, А
        }
        public class Item
        {
            public String familiya;
            public Type dolgnost;
            public double year;
            public double oklad;
            public Item(string familiya, Type dolgnost, double year, double oklad)
            {
                this.familiya = familiya;
                this.dolgnost = dolgnost;
                this.year = year;
                this.oklad = oklad;
            }
            public void Print()
            {
                Console.WriteLine($"|{this.familiya,-24}|{this.dolgnost,-12}|{this.year,-20}|{this.oklad,-15}|");
                //Console.WriteLine('|'+this.ItemName + "\t|" + this.ItemType + "\t|" + this.price + "\t|" + this.amount+'|');
            }
        }
        private static void Main()
        {
            ArrayList list = new ();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите данные:");
                Console.WriteLine("Фамилия:");
                string familiya = Console.ReadLine();
                Type dolgnost;
                while (true)
                {
                    Console.WriteLine("Должнось (П, С, А):");
                    string tmp = Console.ReadLine();
                    if (tmp == "П" || tmp == "P")
                    {
                        dolgnost = Type.П;
                        break;
                    }
                    else if (tmp == "С" || tmp =="C") 
                    {
                        dolgnost = Type.С;
                        break;
                    }
                    else if (tmp == "А" || tmp == "A")
                    {
                        dolgnost = Type.А;
                        break;
                    }
                    else Console.WriteLine("Некорректный ввод значения. Введите еще раз.");
                }
                Console.WriteLine("Год рождения:");
                double year = double.Parse(Console.ReadLine());
                Console.WriteLine("Оклад (грн):");
                double oklad = double.Parse(Console.ReadLine());
                Item value = new(familiya, dolgnost, year, oklad);
                list.Add(value);
                while (true)
                {
                    Console.WriteLine("Добавить элементы в таблицу?\nда - продолжить\nнет - вывод таблицы");
                    string input = Console.ReadLine();
                    if (input == "да" || input == "нет")
                    {
                        if (input == "нет")
                        {
                            flag = false;
                            break;
                        }
                        break;
                    }
                    else Console.WriteLine("Ошибка ввода. Попробуйте еще раз.");
                } 
            }
            Console.WriteLine(new String('-', 76));
            Console.WriteLine($"{"|Отдел кадров",-75}|");
            Console.WriteLine(new String('-', 76));
            Console.WriteLine($"{"|Фамилия",-25}|{"Должность",-12}|{"Год рождения",-20}|{"Оклад (грн)",-15}|");
            Console.WriteLine(new String('-', 76));
            foreach (Item item in list)
            {
                item.Print();
                Console.WriteLine(new String('-', 76));
            }
            Console.WriteLine($"{"|Перечисляемый тип: П - преподаватель, С - студент, А - аспирант",-75}|");
            Console.WriteLine(new String('-', 76));
        }
    }
}