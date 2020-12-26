using System;

namespace LongerLine
{
    class Program
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double secondX1 = double.Parse(Console.ReadLine());
            double secondY1 = double.Parse(Console.ReadLine());
            double secondX2 = double.Parse(Console.ReadLine());
            double secondY2 = double.Parse(Console.ReadLine());

            double first = LongestLine(x1, y1, x2, y2);
            double secound = LongestLine(secondX1, secondY1, secondX2, secondY2);

            if (first >= secound)
            {
                ClosestPoint(x1, y1, x2, y2);
            }
            else
            {
                ClosestPoint(secondX1, secondY1, secondX2, secondY2);
            }
        }

        static double LongestLine(double x1, double y1, double x2, double y2)
        {
            double sum = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            return sum;
        }

        static void ClosestPoint(double x1, double y1, double x2, double y2)
        {
            double first = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            double secound = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (first <= secound)
            {
                Console.WriteLine("({0}, {1})({2}, {3})", x1, y1, x2, y2);
            }
            else
            {
                Console.WriteLine("({0}, {1})({2}, {3})", x2, y2, x1, y1);
            }
        }
    }
}