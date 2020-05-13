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
        public bool Add(T val)
        {
            Item<T> item = new Item<T>(val);
            if (val == null) return false;
            int index = Math.Abs(item.GetHashCode()) % Size;
            if (items[index] == null) items[index] = item;
            else
            {
                Item<T> current = items[index];
                if (string.Compare(current.ToString(), item.ToString()) == 0)
                    return false;
                while (current.next != null)
                {
                    if (string.Compare(current.ToString(), item.ToString()) == 0)
                        return false;
                    current = current.next;
                }
                current.next = item;
            }
            return true;
        }
        public void Print()
        {
            if (items == null) 
            { 
                Console.WriteLine("Таблица пустая!"); 
                return; 
            }
            for (int i = 0; i < Size; i++)
            {
                if (items[i] != null)
                {
                    Item<T> item = items[i];
                    while (item != null)
                    {
                        Console.WriteLine(item.ToString());
                        item = item.next;
                    }
                    Console.WriteLine();
                }
            }

        }
        public bool Search(T val)
        {
            Item<T> item = new Item<T>(val);
            int code = Math.Abs(item.GetHashCode()) % Size;
            if (items[code].value.Equals(val)) return true;
            item = items[code];

            while (item != null)
            {
                if (items[code].value.Equals(val))
                    return true;
                item = item.next;
            }
            return false;
        }
        public T Remove(T val)
        {
            Item<T> item = new Item<T>(val);
            int code = Math.Abs(item.GetHashCode()) % Size;
            item = items[code];
            if (items[code] == null) return default(T);
            if (items[code] != null && (items[code].value.Equals(val)))
            {
                item = items[code];
                items[code] = items[code].next;
                return item.value;
            }
            while (item.next != null && (items[code].value.Equals(val)))
                item = item.next;
            if (item.next != null)
            {
                val = item.next.value;
                item.next = item.next.next;
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
        public static void Clear(ref HashTable<T> ht)
        {
            ht = null;
            GC.Collect();
        }
    }

}
    