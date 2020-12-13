using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = CalcRectangleArea(width, height);
            Console.WriteLine(area);
        }

        static double CalcRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}