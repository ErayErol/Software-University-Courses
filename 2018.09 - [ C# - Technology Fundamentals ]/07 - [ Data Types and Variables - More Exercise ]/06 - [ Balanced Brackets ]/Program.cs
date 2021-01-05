using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesNumber = int.Parse(Console.ReadLine());

            int openedBracketsCount = 0;
            int closedBracketsCount = 0;
            for (int i = 0; i < linesNumber; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    openedBracketsCount++;
                }
                else if (input == ")")
                {
                    closedBracketsCount++;

                    if ((openedBracketsCount - closedBracketsCount) != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
            }
            if (openedBracketsCount == closedBracketsCount)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
