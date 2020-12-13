using System;

namespace _03.LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double firstLine = GetLine(x1, y1, x2, y2);
            double secondLine = GetLine(x3, y3, x4, y4);

            if (firstLine >= secondLine)
            {
                PrintPoint(x1, y1, x2, y2);
            }
            else
            {
                PrintPoint(x3, y3, x4, y4);
            }
        }

        static double GetLine(double x1, double y1, double x2, double y2)
        {
            double temp = Math.Pow(Math.Abs(x2 - x1), 2) + Math.Pow(Math.Abs(y2 - y1), 2);
            temp = Math.Pow(temp, 2);

            return temp;
        }

        static void PrintPoint(double x3, double y3, double x4, double y4)
        {
            double first = Math.Abs(x3) + Math.Abs(y3);
            double second = Math.Abs(x4) + Math.Abs(y4);
            if (first <= second)
            {
                Console.Write($"({x3}, {y3})");
                Console.WriteLine($"({x4}, {y4})");

            }
            else
            {
                Console.Write($"({x4}, {y4})");
                Console.WriteLine($"({x3}, {y3})");
            }
        }
    }
}