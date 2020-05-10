using System;
using System.Collections;
using System.Collections.Generic;


namespace Lab12
{
    
    class HTEnumerator<T> : IEnumerator<Item<T>>
    {
        Item<T>[] items;
        int position = -1;
        public HTEnumerator(Item<T>[] items)
        {
            this.items = items;
        }

        public Item<T> Current
        {
            get
            {
                if (position == -1 || position >= items.Length)
                    throw new InvalidOperationException();
                return items[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (position < items.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }
        public void Dispose() { }
    }
    
}
