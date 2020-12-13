namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] items = new T[length];

            for (int i = 0; i < length; i++)
            {
                items[i] = item;
            }

            return items;
        }
    }
}