namespace StaticList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class StaticList<T> : IList<T>
    {
        private const int INITIAL_CAPACITY = 2;
        private T[] items;

        public int Capacity { get; private set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public StaticList(int capacity = INITIAL_CAPACITY)
        {
            this.items = new T[capacity];
            this.Capacity = capacity;
        }

        public StaticList(IEnumerable<T> initialSet)
        {
            this.items = Enumerable.ToArray(initialSet);
            this.Capacity = this.items.Length;
            this.Count = this.items.Length;
        }

        // O(1)
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        // O(1)
        // O(n) - if resize should happen.
        public void Add(T item)
        {
            this.ResizeIfNecessary();
            this.items[this.Count++] = item;
        }

        // O(n)
        public void Clear()
        {
            if (this.Count > 0)
            {
                for (var i = 0; i < this.Count; i++)
                {
                    this.items[i] = default;
                }
                this.Count = 0;
            }
        }

        // O(n)
        public bool Contains(T item)
        {
            return this.IndexOf(item) >= 0;
        }

        // O(n)
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (array.Length - arrayIndex < this.Count)
            {
                throw new InvalidOperationException();
            }

            for (var i = 0; i < this.Count; i++)
            {
                array[arrayIndex + i] = this.items[i];
            }
        }

        // O(n)
        public int IndexOf(T item)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if ((item == null && this.items[i] == null) || this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        // O(n)
        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.ResizeIfNecessary();

            for (var i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
            this.items[index] = item;
            this.Count++;
        }

        // O(n)
        public bool Remove(T item)
        {
            var index = this.IndexOf(item);
            if (index < 0) return false;

            this.RemoveAt(index);
            return true;
        }

        // O(n)
        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (var i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ResizeIfNecessary()
        {
            if (this.Count == this.Capacity)
            {
                this.Resize();
            }
        }

        // O(n)
        private void Resize()
        {
            var newCapacity = this.Capacity * 2;
            var newArray = new T[newCapacity];
            for (var i = 0; i < this.Count; i++)
            {
                newArray[i] = this.items[i];
            }

            this.items = newArray;
            this.Capacity = newCapacity;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
