using System;
using System.Collections.Generic;
using System.Text;
using Laba10;
namespace Lab12
{
    class Point
    {
        public Person data;
        public Point left,
                     right;
        public Point()
        {
            data = new Person("Sasha", 10);
            left = null;
            right = null;
        }
        public Point(Person d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data.ToString() + " ";
        }
        public static void Run(Point p, int l)
        {
            if (p != null)
            {
                Run(p.left, l + 3);//переход к левому поддереву
                                        //формирование отступа
                for (int i = 0; i < l; i++) Console.Write("     ");
                Console.WriteLine(p.data);//печать узла
                Run(p.right, l + 3);//переход к правому поддереву
            }
        }

        public static Point Add(Point root, Person d)
        {
            Point p = root;
            Point r = null;
            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                if (d.Age == p.data.Age && d.Name == p.data.Name) ok = true;
                else if (d.Age < p.data.Age) p = p.left;
                else p = p.right;
            }
            if (ok) return p;


            Point newPoint = new Point(d);

            if (d.Age < r.data.Age) r.left = newPoint;
            else r.right = newPoint;
            return newPoint;
        }
        public static Point IdealTree(int size, Point p)
        {
            Random rnd = new Random();
            string[] names = new string[] { "Sasha", "Oleg", "Olya", "Katya", "Kirill", "Lesha", "Artur", "Daniil", "Tanya", "Ivan", "Egor", "Andrey", "Vladimir" };

            Point r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            r = new Point(new Person(names[rnd.Next(0, 12)], rnd.Next(1,100)));
            r.left = IdealTree(nl, r.left);
            r.right = IdealTree(nr, r.right);
            return r;
        }

        public static Person FindMin(Point p)
        {
            if (p == null)
                return new Person("asd", 12);

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
