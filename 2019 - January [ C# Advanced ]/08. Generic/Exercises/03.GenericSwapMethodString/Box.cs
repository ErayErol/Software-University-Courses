namespace _03.GenericSwapMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public Box()
        {
            this.Values = new List<T>();
        }

        public List<T> Values { get; set; }

        public void Swap(int firstIndex, int secondIndex)
        {
            bool isInRange =
                firstIndex >= 0
                && firstIndex < this.Values.Count
                && secondIndex >= 0
                && secondIndex < this.Values.Count;

            if (isInRange == false)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            var temp = this.Values[firstIndex];
            this.Values[firstIndex] = this.Values[secondIndex];
            this.Values[secondIndex] = temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}