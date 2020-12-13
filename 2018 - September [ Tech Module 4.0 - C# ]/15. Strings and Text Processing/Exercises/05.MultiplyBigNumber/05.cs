using System;
using System.Linq;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string veryBigNumber = Console.ReadLine().TrimStart('0');
            var multiply = int.Parse(Console.ReadLine());

            if (multiply == 0 || veryBigNumber =="0")
            {
                Console.WriteLine(0);
                Environment.Exit(0);
            }

            if (multiply == 1)
            {

            }

            int currentSum = 0;
            int currentSumFirstNumber = 0;

            StringBuilder result = new StringBuilder();
            StringBuilder replaceResult = new StringBuilder();

            while (true)
            {
                int lastNumber = int.Parse(veryBigNumber.Last().ToString());

                currentSum = lastNumber * multiply;

                currentSum += currentSumFirstNumber;

                if (currentSum > 9)
                {
                    currentSumFirstNumber = int.Parse(currentSum.ToString().First().ToString());
                }
                else
                {
                    currentSumFirstNumber = 0;
                }

                int currentSumLastNumber = int.Parse(currentSum.ToString().Last().ToString());

                result.Append(currentSumLastNumber);

                if (veryBigNumber.Length == 1 && currentSumFirstNumber > 0)
                {
                    result.Append(currentSumFirstNumber);
                }

                veryBigNumber = veryBigNumber.Remove(veryBigNumber.Length - 1, 1);

                if (veryBigNumber.Length == 0)
                {
                    for (int i = result.Length - 1; i >= 0; i--)
                    {
                        replaceResult.Append(result[i]);
                    }

                    Console.WriteLine(replaceResult.ToString());
                    return;
                }
            }
        }
    }
}