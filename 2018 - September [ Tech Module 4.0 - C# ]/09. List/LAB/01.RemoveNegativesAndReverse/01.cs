using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            numbers.RemoveAll(x => x < 0);

            if (numbers.Count > 0)
            {
                numbers.Reverse();
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
