namespace _02._EnterNumbers
{
    using System;

    public class StartUp
    {
        private const int startNumber = 1;
        private const int endNumber = 100;

        public static void Main(string[] args)
        {
            int x = 0;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int y = ReadNumber();

                    while (x >= y)
                    {
                        Console.Write($"Write bigger number than {x} : ");
                        y = ReadNumber();
                    }

                    x = y;

                    if (x == endNumber)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }
        }

        public static int ReadNumber()
        {
            Console.Write($"Write number : ");
            int number = 0;

            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw new FormatException("Number should be integer");
            }


            if (number < startNumber || number > endNumber)
            {
                throw new ArgumentOutOfRangeException($"Number should be in range [{startNumber}...{endNumber}]");
            }

            if (double.IsNaN(number))
            {
                throw new InvalidOperationException("Number should be integer");
            }

            return number;
        }
    }
}
