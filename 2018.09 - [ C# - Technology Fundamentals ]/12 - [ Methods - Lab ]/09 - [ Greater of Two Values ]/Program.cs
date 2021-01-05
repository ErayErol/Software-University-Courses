using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "int":
                    int firstI = int.Parse(Console.ReadLine());
                    int secondI = int.Parse(Console.ReadLine());

                    Console.WriteLine(GetMax(firstI, secondI));
                    break;
                case "char":
                    char firstC = char.Parse(Console.ReadLine());
                    char secondC = char.Parse(Console.ReadLine());

                    Console.WriteLine(GetMax(firstC, secondC));
                    break;
                case "string":
                    string firstS = Console.ReadLine();
                    string secondS = Console.ReadLine();

                    Console.WriteLine(GetMax(firstS, secondS));
                    break;
                default:
                    break;
            }

        }

        static int GetMax(int first, int second)
        {
            return Math.Max(first, second);
        }

        static char GetMax(char first, char second)
        {
            return (char)Math.Max(first, second);
        }

        static string GetMax(string first, string second)
        {
            int result = first.CompareTo(second);
            if (result > 0)
            {
                return first;
            }
            else
            {
                return second;
            }

        }
    }
}
