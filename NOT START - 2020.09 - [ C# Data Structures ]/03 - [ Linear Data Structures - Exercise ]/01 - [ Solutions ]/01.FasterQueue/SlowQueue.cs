namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // This is the code from the Lab exercise on writing a simple Queue.
    public class SlowQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var headItem = this._head.Item;
            var newHead = this._head.Next;
            this._head.Next = null;
            this._head = newHead;

            this.Count--;

            return headItem;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>
            {
                Item = item,
                Next = null
            };

            if (this._head is null)
            {
                this._head = newNode;
            }
            else
            {
                var current = this._head;

                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}