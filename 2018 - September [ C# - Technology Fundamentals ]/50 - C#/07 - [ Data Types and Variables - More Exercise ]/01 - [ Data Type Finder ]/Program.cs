using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string dataType = string.Empty;
            while (command != "END")
            {
                if (int.TryParse(command, out int integerNumber))
                {
                    dataType = "integer type";
                }
                else if (float.TryParse(command, out float floatingNumber))
                {
                    dataType = "floating point type";
                }
                else if (char.TryParse(command, out char character))
                {
                    dataType = "character type";
                }
                else if (bool.TryParse(command, out bool boolean))
                {
                    dataType = "boolean type";
                }
                else
                {
                    dataType = "string type";
                }
                Console.WriteLine($"{command} is {dataType}");
                command = Console.ReadLine();
            }
        }
    }
}
