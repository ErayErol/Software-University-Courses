using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            GetMiddleCharacters(input);
        }

        private static void GetMiddleCharacters(string input)
        {
            StringBuilder middleCharacters = new StringBuilder();
            for (int i = input.Length / 2; i <= input.Length / 2; i++)
            {
                if (input.Length % 2 == 0)
                {
                    middleCharacters.Append(input[i - 1]).Append(input[i]);
                }
                else
                {
                    middleCharacters.Append(input[i]);
                }
            }

            Console.WriteLine(middleCharacters);
        }
    }
}
