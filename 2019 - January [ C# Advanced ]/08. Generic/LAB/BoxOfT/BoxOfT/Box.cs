namespace BoxOfT
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void Add(T value)
        {
            this.data.Add(value);
        }

        public T Remove()
        {
            if (this.Count == 0)
            {
                throw new NotImplementedException();
            }

            var index = this.data.Count - 1;
            var lastElement = this.data[index];
            this.data.RemoveAt(index);
            return lastElement;
        }

        public int Count 
            => this.data.Count;
    }
}