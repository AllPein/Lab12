using System;
using System.Collections.Generic;
using System.Text;

namespace Lab12
{
    class Item<T>
    {
        public int key;
        public T value;
        public Item<T> next;
        static Random rnd = new Random();
        public Item(T val)
        {
            value = val;
            key = GetHashCode();
            next = null;
        }

        internal HTEnumerator<T> HTEnumerator
        {
            get => default;
            set
            {
            }
        }

        internal HashTable<T> HashTable
        {
            get => default;
            set
            {
            }
        }

        public override string ToString()
        {
            return key + " : " + value.ToString();
        }

        public override int GetHashCode()
        {
            return value.ToString().Length;
        }
    }

}

