namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {
            this._head = null;
            this.Count = 0;
        }

        public SinglyLinkedList(Node<T> head)
        {
            this._head = head;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>
            {
                Element = item,
                Next = this._head
            };

            this._head = newNode;
            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();
            var current = this._head;

            while (current != null)
            {
                current = current.Next;
            }
            return this._head.Element;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();
            var current = this._head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Element;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();
            var current = this._head;
            this._head = this._head.Next;
            this.Count--;
            return current.Element;
        }

        public void AddLast(T item)
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

        public T RemoveLast()
        {

            // Kiril solution

            this.EnsureNotEmpty(); // проверка за count да не е по малко от 0
            var removeThis = this.GetLast();
            var current = this._head;

            if (this.Count == 1)
            {
                this._head = null;
            }
            else
            {
                while (current != null)
                {
                    if (current.Next.Next == null)
                    {
                        current.Next = null;
                    }

                    current = current.Next;
                }
            }

            this.Count--;
            return removeThis;


            // My solution

            this.EnsureNotEmpty(); // проверка за count да не е по малко от 0
            var removeThis = this.GetLast();

            var node = new Node<T>();
            var index = this.Count;
            var temp = this._head;

            while (--index > 0)
            {
                for (int i = 0; i < index - 1; i++)
                {
                    temp = temp.Next;
                }

                if (index + 1 == this.Count)
                {
                    node.Element = temp.Element;
                }
                else
                {
                    var current = new Node<T>
                    {
                        Element = temp.Element,
                        Next = node
                    };

                    node = current;
                }

                temp = this._head;
            }

            this._head = node;
            this.Count--;
            return removeThis;
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