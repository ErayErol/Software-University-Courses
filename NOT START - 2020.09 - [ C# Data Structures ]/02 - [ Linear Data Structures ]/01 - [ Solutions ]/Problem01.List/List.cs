using System.Runtime.CompilerServices;

namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List(int capacity = DEFAULT_CAPACITY)
        {
            if (capacity <= 0)
            {
                throw new IndexOutOfRangeException($"{capacity} is not a valid capacity!");
            }

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this._items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Grow();
            this._items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Grow();

            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this.Count--;
            this.Shrink();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Grow()
        {
            if (this.Count == this._items.Length)
            {
                var newArray = new T[this._items.Length * 2];
                DoNewLength(newArray, this._items.Length);
            }
        }

        private void Shrink()
        {
            if (this.Count == this._items.Length / 2)
            {
                var newArray = new T[this._items.Length / 2];
                DoNewLength(newArray, newArray.Length);
            }
        }

        private void DoNewLength(T[] newArray, int length)
        {
            for (int i = 0; i < length; i++)
            {
                newArray[i] = this._items[i];
            }

            this._items = newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException($"The given {index} is out of range!");
            }
        }
    }
}