using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                switch (commands[0].ToLower())
                {
                    case "delete":
                        numbers.RemoveAll(x => x == int.Parse(commands[1]));
                        break;
                    case "insert":
                        numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                        break;
                }

                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
