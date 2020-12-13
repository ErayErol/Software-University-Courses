namespace p_02
{
    using System;
    using System.Linq;

    class KaminoFactory
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            if (length < 2)
            {
                Environment.Exit(0);
            }
            string[] currentDna = Console.ReadLine().Split(new char[] { ' ', '!' }, StringSplitOptions.RemoveEmptyEntries);

            int bestLen = int.MinValue;
            int startIndex = int.MaxValue;
            int bestSum = int.MinValue;
            int currentIndex = 0;
            int bestSequenceIndex = 0;
            string[] bestDna = null;

            while (currentDna[0] != "Clone" && currentDna[1] != "them")
            {
                currentIndex++;
                int currentLen = 0;
                int currentStartIndex = 0;

                for (int i = 0; i < length - 1; i++)
                {
                    if (currentDna[i] == currentDna[i + 1] && currentDna[i] == "1")
                    {
                        currentLen++;
                        if (currentLen == 1)
                        {
                            currentStartIndex = i;
                        }
                    }
                }

                bool isBetter = false;
                int currentSum = currentDna.Select(int.Parse).ToArray().Sum();

                if (currentLen > bestLen)
                {
                    isBetter = true;
                    if (currentStartIndex < startIndex)
                    {
                        isBetter = true;
                        if (currentSum > bestSum)
                        {
                            isBetter = true;
                        }
                    }
                }
                else if (currentLen == bestLen)
                {
                    if (currentStartIndex == startIndex && currentSum > bestSum)
                    {
                        isBetter = true;
                    }

                    if (currentStartIndex < startIndex)
                    {
                        isBetter = true;
                    }
                }

                if (isBetter)
                {
                    bestDna = currentDna;
                    bestLen = currentLen;
                    startIndex = currentStartIndex;
                    bestSum = currentSum;
                    bestSequenceIndex = currentIndex;
                }

                currentDna = Console.ReadLine().Split(new char[] { ' ', '!' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }
    }
}