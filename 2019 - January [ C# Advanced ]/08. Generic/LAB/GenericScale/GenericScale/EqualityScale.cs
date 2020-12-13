namespace GenericScale
{
    using System;

    public class EqualityScale<T>
        where T : IComparable<T>
    {
        public EqualityScale(T left, T right)
        {
            this.First = left;
            this.Second = right;
        }

        public T First { get; set; }

        public T Second { get; set; }

        public bool AreEqual()
        {
            return this.First.Equals(this.Second);
        }

        public bool IsFirstGreater()
        {
            return this.First.CompareTo(this.Second) > 0;
        }
    }
}