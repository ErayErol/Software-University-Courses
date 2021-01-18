namespace DynamicList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DynamicList<T> : IList<T>
    {
        private class Node
        {
            public Node(T initialValue)
            {
                this.Value = initialValue;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public DynamicList()
        {
        }

        public DynamicList(IEnumerable<T> initialSet)
        {
            foreach (var item in initialSet)
            {
                this.Add(item);
            }
        }

        // O(n)
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.GetNode(index).Value;
            }
            set
            {
                this.ValidateIndex(index);
                this.GetNode(index).Value = value;
            }
        }

        // O(1)
        // Implementation where the tail is not stored will have O(n) complexity instead.
        public void Add(T item)
        {
            if (this.Count == 0)
            {
                var newNode = new Node(item);

                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.Next = new Node(item);
                this.tail = this.tail.Next;
            }

            this.Count++;
        }

        // O(1)
        public void Clear()
        {
            if (this.Count > 0)
            {
                this.head = null;
                this.tail = null;
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

            var current = this.head;
            for (var i = 0; i < this.Count && current != null; i++, current = current.Next)
            {
                array[arrayIndex + i] = current.Value;
            }
        }

        // O(n)
        public int IndexOf(T item)
        {
            var current = this.head;

            for (var i = 0; i < this.Count && current != null; i++, current = current.Next)
            {
                if ((item == null && current.Value == null) || current.Value.Equals(item))
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

            var previousNode = this.GetNode(index - 1);

            var newNode = new Node(item);
            newNode.Next = previousNode.Next;
            previousNode.Next = newNode;

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

            var previousItem = this.GetNode(index - 1);
            previousItem.Next = previousItem.Next.Next;

            if (index == --this.Count)
            {
                this.tail = previousItem;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            for (var i = 0; i < this.Count && current != null; i++)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // O(n)
        private Node GetNode(int index)
        {
            var current = this.head;
            for (var i = 0; i < index; i++)
            {
                if (current == null)
                {
                    throw new InvalidOperationException();
                }

                current = current.Next;
            }

            return current;
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
