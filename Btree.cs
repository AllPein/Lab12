using System;
using System.Collections.Generic;
using System.Text;
using Laba10;
namespace Lab12
{
    class BTree
    {
        public Person data;
        public BTree left,
                     right;
        public BTree()
        {
            data = new Person("Sasha", 10);
            left = null;
            right = null;
        }
        public BTree(Person d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data.ToString() + " ";
        }
        public static void Run(BTree p, int l)
        {
            if (p != null)
            {
                Run(p.left, l + 3);
                for (int i = 0; i < l; i++) Console.Write("     ");
                Console.WriteLine(p.data);
                Run(p.right, l + 3);
            }
        }

        public static BTree Add(BTree root, Person d)
        {
            BTree p = root;
            BTree r = null;
            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                if (d.Age == p.data.Age && d.Name == p.data.Name) ok = true;
                else if (d.Age < p.data.Age) p = p.left;
                else p = p.right;
            }
            if (ok) return p;


            BTree newBTree = new BTree(d);

            if (d.Age < r.data.Age) r.left = newBTree;
            else r.right = newBTree;
            return newBTree;
        }
        public static BTree IdealTree(int size, BTree p)
        {
            Random rnd = new Random();
            string[] names = new string[] { "Sasha", "Oleg", "Olya", "Katya", "Kirill", "Lesha", "Artur", "Daniil", "Tanya", "Ivan", "Egor", "Andrey", "Vladimir" };

            BTree r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            r = new BTree(new Person(names[rnd.Next(0, 12)], rnd.Next(1,100)));
            r.left = IdealTree(nl, r.left);
            r.right = IdealTree(nr, r.right);
            return r;
        }

        public static Person FindMin(BTree p)
        {
            if (p == null)
                return default(Person);

            Person right = FindMin(p.right);
            Person left = FindMin(p.left);

            if (p.data.Age < left.Age)
                if (p.data.Age  < right.Age) return p.data;
                else return right;


            else if (left.Age < right.Age) return left;
            else return right;

        }
    }
}
