using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<string> commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            bool changes = false;

            while (commands[0] != "end")
            {
                switch (commands[0].ToLower())
                {
                    case "contains":
                        if (numbers.Contains(int.Parse(commands[1])))
                        {
                            Console.WriteLine("Yes");
                            break;
                        }

                        Console.WriteLine("No such number");
                        break;

                    case "printeven":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
                        break;

                    case "printodd":
                        Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 1)));
                        break;

                    case "getsum":
                        Console.WriteLine(numbers.Sum());
                        break;

                    case "filter":
                        int num = int.Parse(commands[2]);
                        switch (commands[1])
                        {
                            case ">": Console.WriteLine(string.Join(" ", numbers.Where(x => x > num))); break;
                            case ">=": Console.WriteLine(string.Join(" ", numbers.Where(x => x >= num))); break;
                            case "<=": Console.WriteLine(string.Join(" ", numbers.Where(x => x <= num))); break;
                            case "<": Console.WriteLine(string.Join(" ", numbers.Where(x => x < num))); break;
                        }
                        break;

                    case "add":
                        numbers.Add(int.Parse(commands[1]));
                        changes = true;
                        break;
                    case "remove":
                        numbers.Remove(int.Parse(commands[1]));
                        changes = true;
                        break;
                    case "removeat":
                        numbers.RemoveAt(int.Parse(commands[1]));
                        changes = true;
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                        changes = true;
                        break;
                }

                commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            if (changes)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
