namespace _05.GenericCountMethodString
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                box.Values.Add(line);
            }

            var value = Console.ReadLine();
            var count = box.GreaterValuesThanValue(value);
            Console.WriteLine(count);
        }
    }
}