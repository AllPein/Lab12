using System;
using System.Collections.Generic;
using System.Text;
using Laba10;
namespace Lab12
{
    class HashTable<T>:ICloneable
    {
        public Item<T>[] items;
        public int Size;
        public int Count
        {
            get
            {
                int k = 0;
                foreach (var elem in this.items)
                {
                    if (elem != null) k++;
                }
                return k;
            }
        }
        public HashTable(int size = 10)
        {
            Size = size;
            items = new Item<T>[Size];
        }
        public HashTable(HashTable<T> hashTable)
        {
            Size = hashTable.Size;
            items = hashTable.items;
        }
        public HashTable()
        {
            items = new Item<T>[0];
        }
        public bool Add(T s)
        {
            Item<T> point = new Item<T>(s);
            if (s == null) return false;
            int index = Math.Abs(point.GetHashCode()) % Size;
            if (items[index] == null) items[index] = point;
            else
            {
                Item<T> cur = items[index];
                if (string.Compare(cur.ToString(), point.ToString()) == 0)
                    return false;
                while (cur.next != null)
                {
                    if (string.Compare(cur.ToString(), point.ToString()) == 0)
                        return false;
                    cur = cur.next;
                }
                cur.next = point;
            }
            return true;
        }
        public void Print()
        {
            if (items == null) { Console.WriteLine("Таблица пустая!"); return; }
            for (int i = 0; i < Size; i++)
            {
                if (items[i] != null)
                {
                    Item<T> p = items[i];
                    while (p != null)
                    {
                        Console.WriteLine(p.ToString());
                        p = p.next;
                    }
                    Console.WriteLine();
                }
            }

        }
        public bool FindPoint(T val)
        {
            Item<T> lp = new Item<T>(val);
            int code = Math.Abs(lp.GetHashCode()) % Size;
            if (items[code].value.Equals(val)) return true;
            lp = items[code];
            while (lp != null)
            {
                if (items[code].value.Equals(val))
                    return true;
                lp = lp.next;
            }
            return false;
        }
        public T DelPoint(T val)
        {
            Item<T> lp = new Item<T>(val);
            int code = Math.Abs(lp.GetHashCode()) % Size;
            lp = items[code];
            if (items[code] == null) return default(T);
            if (items[code] != null && (items[code].value.Equals(val)))
                {
                lp = items[code];
                items[code] = items[code].next;
                return lp.value;
            }
            while (lp.next != null && (items[code].value.Equals(val)))
                lp = lp.next;
            if (lp.next != null)
            {
                val = lp.next.value;
                lp.next = lp.next.next;
                return val;
            }
            return default(T);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public object DeepClone()
        {
            return new HashTable<T> { items = this.items };
        }
        public IEnumerator<Item<T>> GetEnumerator()
        {
            return new HTEnumerator<T>(this.items);
        }
        public static void Clear(HashTable<T> ht)
        {
            ht = null;
            GC.Collect();
        }
    }

}
    