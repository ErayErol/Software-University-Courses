using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "end")
                {
                    Console.WriteLine($"[{string.Join(", ", numbers)}]");
                    break;
                }

                switch (commands[0])
                {
                    case "exchange":
                        GetExchange(numbers, commands);
                        break;
                    case "max":
                        PrintMaxOrMin(numbers, commands);
                        break;
                    case "min":
                        PrintMaxOrMin(numbers, commands);
                        break;
                    case "first":
                        PrintFirstOrLast(numbers, commands);
                        break;
                    case "last":
                        PrintFirstOrLast(numbers, commands);
                        break;
                }
            }
        }

        static void PrintFirstOrLast(List<int> numbers, string[] commands)
        {
            int count = int.Parse(commands[1]);

            if (count > numbers.Count || count < 1)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            List<int> nums = new List<int>();

            List<int> reverse = new List<int>(numbers);
            reverse.Reverse();

            nums = numbers.Where(n => n % 2 == 1).Take(count).ToList();
            if (commands[0] == "last")
            {
                nums = reverse.Where(n => n % 2 == 1).Take(count).ToList();
                nums.Reverse();
            }

            if (commands[2] == "even")
            {
                nums = numbers.Where(n => n % 2 == 0).Take(count).ToList();
                if (commands[0] == "last")
                {
                    nums = reverse.Where(n => n % 2 == 0).Take(count).ToList();
                    nums.Reverse();
                }
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static void PrintMaxOrMin(List<int> numbers, string[] commands)
        {
            int num = 0;

            if (commands[1] == "odd")
            {
                if (numbers.Where(n => n % 2 == 1).Count() == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }

                num = numbers.Where(n => n % 2 == 1).Min();
                if (commands[0] == "max")
                {
                    num = numbers.Where(n => n % 2 == 1).Max();
                }
            }
            else if (commands[1] == "even")
            {
                if (numbers.Where(n => n % 2 == 0).Count() == 0)
                {
                    Console.WriteLine("No matches");
                    return;
                }

                num = numbers.Where(n => n % 2 == 0).Min();
                if (commands[0] == "max")
                {
                    num = numbers.Where(n => n % 2 == 0).Max();
                }
            }

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] == num)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }

        static void GetExchange(List<int> numbers, string[] commands)
        {
            int index = int.Parse(commands[1]);

            if (index > numbers.Count - 1 || index < 0)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int i = 0; i <= index; i++)
            {
                int temp = numbers.First();
                numbers.Add(temp);
                numbers.RemoveRange(0, 1);
            }
        }
    }
}