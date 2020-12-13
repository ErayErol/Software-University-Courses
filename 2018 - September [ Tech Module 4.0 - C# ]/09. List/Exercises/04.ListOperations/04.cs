using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                switch (commands[0])
                {
                    case "Remove":
                        int removeIndex = int.Parse(commands[1]);

                        if (numbers.Count > removeIndex && removeIndex >= 0)
                        {
                            numbers.RemoveAt(removeIndex);
                        }

                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;

                    case "Insert":
                        int indexToAdd = int.Parse(commands[1]);
                        int indexToInsert = int.Parse(commands[2]);
                        if (numbers.Count > indexToInsert && indexToInsert >= 0)
                        {
                            numbers.Insert(indexToInsert, indexToAdd);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;

                    case "Add":
                        numbers.Add(int.Parse(commands[1]));
                        break;

                    case "Shift":

                        string direction = commands[1];
                        int rotation = int.Parse(commands[2]);

                        if (direction == "right")
                        {
                            for (int i = 0; i < rotation % numbers.Count; i++)
                            {
                                numbers.Insert(0, numbers[numbers.Count - 1]);
                                numbers.RemoveAt(numbers.Count - 1);
                            }
                        }

                        else if (direction == "left")
                        {
                            for (int i = 0; i < rotation % numbers.Count; i++)
                            {
                                numbers.Insert(numbers.Count, numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        break;
                }

                commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
