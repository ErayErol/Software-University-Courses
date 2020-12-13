namespace _05.GenericCountMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
        where T : IComparable<T>
    {
        public Box()
        {
            this.Values = new List<T>();
        }

        public List<T> Values { get; set; }

        public int GreaterValuesThanValue(T value)
        {
            var count = 0;
            foreach (var currentValue in this.Values)
            {
                if (currentValue.CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
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