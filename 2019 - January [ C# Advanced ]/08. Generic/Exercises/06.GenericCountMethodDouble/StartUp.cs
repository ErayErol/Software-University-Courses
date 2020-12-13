namespace _06.GenericCountMethodDouble
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            //var nums = Console.ReadLine().Split().Select(int.Parse).ToList().GreaterValuesThanValue(10);

            var n = int.Parse(Console.ReadLine());
            var box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var line = double.Parse(Console.ReadLine());
                box.Values.Add(line);
            }

            var value = double.Parse(Console.ReadLine());
            var count = box.GreaterValuesThanValue(value);
            Console.WriteLine(count);
        }
    }
}