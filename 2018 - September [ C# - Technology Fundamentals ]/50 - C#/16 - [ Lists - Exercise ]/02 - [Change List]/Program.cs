using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
           
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Delete":
                        int number = int.Parse(commands[1]);
                        
                        DeletingElements(numbers, number);
                        break;
                    case "Insert":
                        int value = int.Parse(commands[1]);
                        int position = int.Parse(commands[2]);
                        
                        InsertingElements(numbers, value, position);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        static void DeletingElements(List<int> numbers, int number)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == number)
                {
                    numbers.RemoveAt(i);
                    i = -1;
                }
            }
        }

        static void InsertingElements(List<int> numbers, int value, int position)
        {
            numbers.Insert(position, value);
        }
    }
}
