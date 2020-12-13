namespace _02.CircleArea_Precision_12_
{
    using System;

    class CircleArea
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * r * r;
            Console.WriteLine("{0:f12}", area);
        }
    }
}