namespace _04.FloatingEquality
{
    using System;

    class FloatingEquality
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            var bigger = Math.Max(first, second);
            var smaller = Math.Min(first, second);

            var eps = bigger - smaller;

            if (eps < 0.000001)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}