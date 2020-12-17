namespace _01._SquareRoot
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Write a number: ");
                int number = int.Parse(Console.ReadLine());

                double squareOfNumber = Math.Sqrt(number);

                if (double.IsNaN(squareOfNumber))
                {
                    Console.WriteLine("Negative number");
                    return;
                }

                Console.Write("Square of number is: ");

                Console.WriteLine(squareOfNumber);
            }
            catch
            {
                Console.WriteLine("Invalid number!");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }
}
