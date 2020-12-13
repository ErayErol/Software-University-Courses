using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            var operation = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rectaglesCount = operation[0];
            int intersectionCount = operation[1];

            for (int i = 0; i < rectaglesCount; i++)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string name = commands[0];
                double width = double.Parse(commands[1]);
                double height = double.Parse(commands[2]);
                double x = double.Parse(commands[3]);
                double y = double.Parse(commands[4]);

                Rectangle rectangle = new Rectangle(name, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < intersectionCount; i++)
            {
                var commands = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string firstId = commands[0];
                string secondId = commands[1];

                Rectangle firstRectangle = rectangles.FirstOrDefault(x => x.Id == firstId);
                Rectangle secondRectangle = rectangles.FirstOrDefault(x => x.Id == secondId);

                if (firstRectangle.Intersect(secondRectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}