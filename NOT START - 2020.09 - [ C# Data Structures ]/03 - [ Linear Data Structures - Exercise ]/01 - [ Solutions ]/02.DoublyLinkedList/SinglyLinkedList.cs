namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // This is the code from the Lab exercise on writing a simple SinglyLinkedList.
    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>
            {
                Item = item,
                Next = this.head
            };

            this.head = newNode;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>
            {
                Item = item
            };

            if (this.head is null)
                this.head = newNode;
            else
            {
                var current = this.head;

                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            var current = this.head;
            while (current.Next != null)
                current = current.Next;

            return current.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var headItem = this.head.Item;
            var newHead = this.head.Next;
            this.head.Next = null;
            this.head = newHead;
            this.Count--;

            return headItem;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            if (this.head.Next is null)
                return this.RemoveFirst();

            var current = this.head;

            while(current.Next.Next != null)
            {
                current = current.Next;
            }

            var lastItem = current.Next.Item;
            current.Next = null;
            this.Count--;

            return lastItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}