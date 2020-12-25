namespace LAB
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var customList = new CustomList();
            customList.Add(1);
            customList.Add(12);
            customList.Add(3);
            customList.Add(14);
            customList.Add(5);
            if (customList.Contain(15))
            {
                Console.WriteLine("yes");
            }
        }
    }
}
