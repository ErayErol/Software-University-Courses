using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> result = new List<int>(numbers);

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                result[i] = result[i] + result[result.Count - 1];
                result.RemoveAt(result.Count - 1);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
