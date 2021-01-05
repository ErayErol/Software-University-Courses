using System;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            int[] sums = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                string names = Console.ReadLine();
                int totalSum = 0;
                for (int j = 0; j < names.Length; j++)
                {
                    if ((names[j] == 'a' || names[j] == 'e' || names[j] == 'i' || names[j] == 'o' || names[j] == 'u') ||
                        (names[j] == 'A' || names[j] == 'E' || names[j] == 'I' || names[j] == 'O' || names[j] == 'U'))
                    {
                        totalSum += (char)names[j] * names.Length;
                        sums[i] = totalSum;
                    }
                    else
                    {
                        totalSum += (char)names[j] / names.Length;
                        sums[i] = totalSum;
                    }
                }
            }

            Array.Sort(sums);

            foreach (var item in sums)
            {
                Console.WriteLine(item);
            }
        }
    }
}
