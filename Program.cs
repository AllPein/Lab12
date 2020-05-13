using System;
using Laba10;
using System.Collections.Generic;
using System.Linq;
namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = MainMenu();

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        FirstTask();
                        break;

                    case 2:
                        SecondTask();
                        break;

                    case 3:
                        ThirdTask();
                        break;
                    case 4:
                        FourthTask();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }

            }
        }
        static int Input(string msg, int left, int right)
        {
            int x;
            Console.Write(msg);
            bool flag = int.TryParse(Console.ReadLine(), out x) && (x >= left) && (x <= right);

            if (flag) return x;
            else
            {
                Console.WriteLine($"Введите число из диапозона {left} - {right}");
                return Input(msg, left, right);
            }

        }

        public static void PrintList(List<Person> list)
        {
            Console.WriteLine(list.Count > 0 ? "Текущий список: " : "Список пуст");
            int i = 0;
            foreach (var obj in list)
            {
                Console.WriteLine($"{i}. {obj.ToString()}");
                i++;
            }
        }
      
        public static void PrintLinkedList(LinkedList<Person> list)
        {
            Console.WriteLine(list.Count > 0 ? "Текущий список: " : "Список пуст");
            int i = 0;
            foreach (var obj in list)
            {
                Console.WriteLine($"{i}. {obj}");
                i++;
            }
        }
        static int MainMenu()
        {

            Console.WriteLine("1 - List \n" +
                "2 - LinkedList \n" +
                "3 - Tree \n" +
                "4 - HashTable \n" +
                "5 - Выход");

            int choice = Input("Выберите действие: ", 1, 5);
            return choice;
        }
        static int GetUserChoice(string msg, int left, int right)
        {
            Console.WriteLine(msg);
            int choice = Input("Выберите действие: ", left, right);
            return choice;
        }
        public static LinkedList<Person> AddToLinkedList(int index, LinkedList<Person> list)
        {
            var en = list.GetEnumerator();
            var newList = new LinkedList<Person>();
            int i = 0;
            if (index == 0)
            {
                newList.AddFirst(new Administrator("Lesha", 12000, 1, 12));
            }
            else
            {
                newList.AddFirst(list.First.Value);
            }
            while (en.MoveNext())
            {
                if (i == index && i != 0)
                {
                    newList.AddAfter(newList.Last, new Administrator("Lesha", 12000, 1, 12));
                }
                if (index == 0)
                {
                    newList.AddAfter(newList.Last, en.Current);
                    
                }
                else
                {
                    if (i != 0 ) newList.AddAfter(newList.Last, en.Current);
                }
                    i++;
            }

            return newList;
        }
      
        static public List<Person> DeleteElems(List<Person> list)
        {

            List<Person> nl = new List<Person>(list.Count);
            foreach (var elem in list)
            {
                nl.Add(elem);
            }

            nl = list.Where((a, i) => (i % 2 > 0) && (i != 0)).ToList();
            
            return nl;
        }
       
       
        static void FirstTask()
        {
            List<Person> list = new List<Person> { new Person("Sasha", 18), new Employee("Max", 12, 16000), new Engineer("Oleg", 12000, 4, 12), new Administrator("Kirill", 7000, 2, 11),
             new Person("Alex", 36), new Employee("Nikita", 24, 32000), new Engineer("Anya", 6000, 1, 14), new Administrator("Denis", 14000, 4, 20)};

            
           
            PrintList(list);
            Console.WriteLine("");

            Console.WriteLine("Удаление из списка элементов с четными номерами");
            Console.WriteLine("");

            list =  DeleteElems(list);

            Console.WriteLine("");
            PrintList(list);
            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();

            Console.Clear();
        }
        static void SecondTask()
        {
            LinkedList<Person> list = new LinkedList<Person>();
            list.AddFirst(new Person("Sasha", 18));
            list.AddAfter(list.Last, new Employee("Max", 16000, 12));
            list.AddAfter(list.Last, new Employee("Kolya", 16000, 22));
            list.AddAfter(list.Last, new Engineer("Oleg", 12000, 4, 21));
            list.AddAfter(list.Last, new Administrator("Kirill", 7000, 2, 22));
            list.AddAfter(list.Last, new Employee("Nikita", 32000, 24));

            PrintLinkedList(list);
            Console.WriteLine("");

            Console.WriteLine("Добавить элемент с заданным номером");
            int index = Input("Введите номер: ", 0, list.Count);

            list = AddToLinkedList(index, list);
            Console.WriteLine("");
            PrintLinkedList(list);
            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();

            Console.Clear();
        }
        static void ThirdTask()
        {
            BTree p = new BTree();
            p = BTree.IdealTree(7, p);
           
            Console.WriteLine("");
            BTree.Run(p, 0);

            Console.WriteLine("");
            Console.WriteLine("Поиск элемента с минимальным возрастом");
            Console.WriteLine("");
            Person minAgedPerson = BTree.FindMin(p);

            Console.WriteLine(minAgedPerson.ToString());
            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();

            Console.Clear();
        }
        static void FourthTask()
        {
            Person[] arr = new Person[3];
            arr[0] = new Person("Sasha", 18);
            arr[1] = new Employee("Max", 16000, 12);
            arr[2] = new Engineer("Maria", 1236000, 1, 21);

            HashTable<Person> ht = new HashTable<Person>();
            foreach (var el in arr) ht.Add(el);

            ht.Print();

            Console.WriteLine("Поиск в коллекции: \n");
            Person findPerson = new Person("Sasha", 18);
            if (ht.Search(findPerson)) Console.WriteLine("Объект найден");
            else Console.WriteLine("Объект не найден");


            Console.WriteLine("Удаление элемента из коллекции: \n");
            ht.Remove(new Person("Sasha", 18));
            ht.Print();

            Console.WriteLine("Перебор коллекции");
            foreach (var elem in ht)
            {
                if (elem != null)
                    Console.WriteLine(elem);
            }

            Console.WriteLine($"Количество элементов в коллекции: {ht.Count}");

            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
