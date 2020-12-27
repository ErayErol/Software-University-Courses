using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "int":
                    int intValue = int.Parse(Console.ReadLine());
                    Console.WriteLine(Calculations(intValue));
                    break;
                case "real":
                    double doubleValue = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{Calculations(doubleValue):f2}");
                    break;
                case "string":
                    string stringValue = Console.ReadLine();
                    Console.WriteLine(Calculations(stringValue));
                    break;
                default:
                    break;
            }
        }

        static int Calculations(int intValue)
        {
            int result = intValue * 2;
            return result;
        }

        static double Calculations(double doubleValue)
        {
            double result = doubleValue * 1.5;
            return result;
        }

        static string Calculations(string stringValue)
        {
            string result = $"${stringValue}$";
            return result;
        }
    }
}
