using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            GetVowels(input);
        }

        private static void GetVowels(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a': counter++; break; 
                    case 'e': counter++; break; 
                    case 'u': counter++; break; 
                    case 'i': counter++; break; 
                    case 'o': counter++; break; 
                }
            }

            Console.WriteLine(counter);
        }
    }
}
