using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            decimal result = 0.0m;
            GetDataType(operation, result);
        }

        static void GetDataType(string operation, decimal result)
        {
            switch (operation)
            {
                case "int":
                    decimal inputInt = decimal.Parse(Console.ReadLine());
                    result = inputInt * 2;
                    Console.WriteLine(result);
                    break;
                case "real":
                    decimal inputReal = decimal.Parse(Console.ReadLine());
                    result = inputReal * 1.5m;
                    Console.WriteLine($"{result:F2}");
                    break;
                case "string":
                    string inputString = Console.ReadLine();
                    Console.WriteLine($"${inputString}$");
                    break;
            }
        }
    }
}