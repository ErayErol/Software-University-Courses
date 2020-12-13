using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<string> commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (commands[0] != "end")
            {
                int num = int.Parse(commands[1]);
                switch (commands[0].ToLower())
                {
                    case "add": numbers.Add(num); break;
                    case "remove": numbers.Remove(num); break;
                    case "removeat": numbers.RemoveAt(num); break;
                    case "insert": numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1])); break;
                }

                commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
