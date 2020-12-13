using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            IsPalindrome(numbers);
        }

        static void IsPalindrome(string numbers)
        {
            while (numbers != "END")
            {
                if (numbers[0] == numbers[numbers.Length - 1])
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                numbers = Console.ReadLine();
            }
        }
    }
}
