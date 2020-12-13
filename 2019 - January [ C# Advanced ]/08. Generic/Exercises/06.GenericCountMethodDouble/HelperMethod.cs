namespace _06.GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public static class HelperMethod        
    {
        public static int GreaterValuesThanValue<T>(this List<T> list, T value)
            where T : IComparable<T>
        {
            var count = 0;
            foreach (var currentValue in list)
            {
                if (currentValue.CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}