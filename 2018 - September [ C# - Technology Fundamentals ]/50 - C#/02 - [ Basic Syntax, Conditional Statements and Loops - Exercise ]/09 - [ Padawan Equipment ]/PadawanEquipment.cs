namespace _09.PadawanEquipment
{
    using System;

    class PadawanEquipment
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceLightsabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double salary = countOfStudents / 6;

            double total = (priceLightsabers * Math.Ceiling(countOfStudents + (countOfStudents / 10.0))) + (priceRobes * countOfStudents)
                + (priceBelts * Math.Ceiling(countOfStudents - salary));

            double diff = Math.Abs(total - amountOfMoney);

            if (amountOfMoney >= total)
            {
                Console.WriteLine($"The money is enough - it would cost {total:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {diff:F2}lv more.");
            }
        }
    }
}