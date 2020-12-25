namespace _07.CustomLinkedList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var x = new CustomLinkedList<int>();
            x.Add(1);

            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
        }
    }
}