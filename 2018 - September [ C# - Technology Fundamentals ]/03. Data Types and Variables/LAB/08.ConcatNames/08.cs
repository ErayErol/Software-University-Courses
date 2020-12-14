using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string name2 = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{name}{delimiter}{name2}");
        }
    }
}
