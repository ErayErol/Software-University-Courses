namespace _08.Snowballs
{
    using System;
    using System.Numerics;

    class Snowballs
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int snow = 0;
            int time = 0;
            int quality = 0;
            BigInteger maxSum = -1;

            for (int i = 0; i < count; i++)
            {
                int currentSnow = int.Parse(Console.ReadLine());
                int currentTime = int.Parse(Console.ReadLine());
                int currentQuality = int.Parse(Console.ReadLine());

                BigInteger currentSum = BigInteger.Pow((currentSnow / currentTime), currentQuality);

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    snow = currentSnow;
                    time = currentTime;
                    quality = currentQuality;
                }
            }

            Console.WriteLine($"{snow} : {time} = {maxSum} ({quality})");
        }
    }
}