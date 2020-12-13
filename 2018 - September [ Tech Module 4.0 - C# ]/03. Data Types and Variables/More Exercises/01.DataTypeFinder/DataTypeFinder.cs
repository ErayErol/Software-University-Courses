namespace _01.DataTypeFinder
{
    using System;

    class DataTypeFinder
    {
        static void Main(string[] args)
        {
            int integer;
            double @double;
            char @char;
            bool @bool;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if (int.TryParse(input, out integer))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (double.TryParse(input, out @double))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out @char))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out @bool))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
            }
        }
    }
}