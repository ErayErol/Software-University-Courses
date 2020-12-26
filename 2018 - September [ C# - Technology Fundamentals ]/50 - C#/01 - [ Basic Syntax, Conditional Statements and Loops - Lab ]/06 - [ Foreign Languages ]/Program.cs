using System;

namespace ForeignLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();
            if (countryName == "USA" || countryName == "England")
            {
                Console.WriteLine("English");
            }
            else if (countryName == "Spain" || countryName == "Argentina" || countryName == "Mexico")
            {
                Console.WriteLine("Spanish");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
