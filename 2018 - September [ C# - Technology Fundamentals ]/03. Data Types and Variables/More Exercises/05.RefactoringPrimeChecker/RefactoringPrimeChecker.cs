namespace _05.RefactoringPrimeChecker
{
    using System;

    class RefactoringPrimeChecker
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int currentNumber = 2; currentNumber <= number; currentNumber++)
            {
                bool isPrime = true;
                for (int currentDivider = 2; currentDivider < currentNumber; currentDivider++)
                {
                    if (currentNumber % currentDivider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{currentNumber} -> {isPrime.ToString().ToLower()}");
            }
        }
    }
}