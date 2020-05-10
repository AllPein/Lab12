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
        public Item(T val)
        {
            value = val;
            key = GetHashCode();
            next = null;
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

