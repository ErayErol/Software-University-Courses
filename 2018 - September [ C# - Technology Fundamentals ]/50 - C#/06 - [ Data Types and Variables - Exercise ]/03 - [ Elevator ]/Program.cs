using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)peopleNumber / elevatorCapacity);
            Console.WriteLine(courses);
        }
    }
}
