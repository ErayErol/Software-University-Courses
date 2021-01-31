namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            this._head = null;
            this.Count = 0;
        }

        public Queue(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._head;

            while (current != null)
            {
                if (current.Element.Equals(item))
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
            var current = this._head;
            this._head = this._head.Next;
            this.Count--;
            return current.Element;
        }

        // TODO: O(1)
        public void Enqueue(T item)
        {
            var current = this._head;
            var newNode = new Node<T>(item);

            if (current == null)
            {
                this._head = newNode;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();
            return this._head.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}