namespace _01.GenericBoxofString
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var value = Console.ReadLine();
                var box = new Box<string>(value);
                Console.WriteLine(box);
            }
        }
    }
}