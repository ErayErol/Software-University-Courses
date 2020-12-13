namespace _02.CryptoMaster
{
    using System;
    using System.Linq;

    class CryptoMaster
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var maxLength = 1;

            for (int i = 0; i < array.Length; i++)
            {
                for (int step = 1; step < array.Length; step++)
                {
                    int currentIndex = i;

                    int nextIndex = (currentIndex + step) % array.Length;
                    int currLength = 1;

                    while (array[nextIndex] > array[currentIndex])
                    {
                        currLength++;
                        if (currLength > maxLength)
                        {
                            maxLength = currLength;
                        }

                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % array.Length;
                    }
                }
            }

            Console.WriteLine(maxLength);
        }
    }
}