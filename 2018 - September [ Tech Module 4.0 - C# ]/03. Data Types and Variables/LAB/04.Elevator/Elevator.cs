namespace _04.Elevator
{
using System;

    class Elevator
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)numberOfPeople / capacity);

            Console.WriteLine(courses);
        }
    }
}