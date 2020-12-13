using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int homesToVisit = int.Parse(Console.ReadLine());
            int numberOfPresent = int.Parse(Console.ReadLine());

            int present = numberOfPresent;
            int goesBack = 0;
            int diff = 0;
            int sum = 0;
            int sumOfChildren = 0;
            int homesRemainding = 0;
            for (int i = 1; i <= homesToVisit; i++)
            {
                int children = int.Parse(Console.ReadLine());
                sumOfChildren += children;
                if (children <= numberOfPresent)
                {
                    numberOfPresent -= children;
                }
                else
                {
                    goesBack++;
                    homesRemainding = homesToVisit - i;
                    diff = children - numberOfPresent;
                    numberOfPresent = ((present / i) * homesRemainding) + diff;
                    sum += numberOfPresent;
                    numberOfPresent -= diff;
                }
            }

            if (goesBack <= 0)
            {
                Console.WriteLine(numberOfPresent);
            }
            else
            {
                Console.WriteLine(goesBack);
                Console.WriteLine(sum);
            }
        }
    }
}
