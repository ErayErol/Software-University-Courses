namespace _03.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> stack;

        public MyStack()
        {
            this.stack = new List<T>();
        }

        public void Push(params T[] element)
        {
            foreach (var item in element.ToList())
            {
                this.stack.Add(item);
            }
        }

        public void Pop()
        {
            if (this.stack.Any())
            {
                this.stack.RemoveAt(this.stack.Count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}