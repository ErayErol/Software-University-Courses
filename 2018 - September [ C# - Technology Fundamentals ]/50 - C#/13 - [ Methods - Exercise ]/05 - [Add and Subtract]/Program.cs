using System;

namespace AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = Sum(firstNumber, secondNumber);
            int subtract = Subtract(thirdNumber, sum);

            Console.WriteLine(subtract);
        }

        static int Sum(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            return sum;
        }

        static int Subtract(int thirdNumber, int sum)
        {
            int subtract = sum - thirdNumber;
            return subtract;
        }
    }
}
