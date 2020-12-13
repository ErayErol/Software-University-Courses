using System;

namespace p_01
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountOfMoney = decimal.Parse(Console.ReadLine());
            long studentsCount = long.Parse(Console.ReadLine());
            decimal sabresPrice = decimal.Parse(Console.ReadLine());
            decimal robesPrice = decimal.Parse(Console.ReadLine());
            decimal beltsPrice = decimal.Parse(Console.ReadLine());

            decimal freeBelts = studentsCount / 6;

            decimal procent = Math.Ceiling(studentsCount + (studentsCount / 10.0m));
            decimal sabes = sabresPrice * procent;
            decimal robes = robesPrice * (studentsCount);
            decimal belt = beltsPrice * (studentsCount - freeBelts);

            decimal sum = sabes + robes + belt;

            if (sum <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:F2}lv.");
            }
            else
            {
                decimal diff = sum - amountOfMoney;
                Console.WriteLine($"Ivan Cho will need {diff:F2}lv more.");
            }
        }
    }
}
