namespace _05._Convert.ToDouble
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split().ToArray();

            double result;

            foreach (string value in values)
            {
                try
                {
                    result = Convert.ToDouble(value);
                    Console.WriteLine("Converted '{0}' to {1}.", value, result);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to convert '{0}' to a Double.", value);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("'{0}' is outside the range of a Double.", value);
                }
            }
        }
    }
}
