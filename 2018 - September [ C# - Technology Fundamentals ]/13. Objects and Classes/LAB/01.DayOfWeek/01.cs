using System;
using System.Globalization;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            //Console.WriteLine(date.DayOfWeek);

            Dice dice1 = new Dice();
            Console.WriteLine(dice1.Roll());
        }
    }

    class Dice
    {
        public int Sides { get; set; }
        public int Roll()
        {
            Random rnd = new Random();
            return rnd.Next(1, Sides + 1);
        }
        public Dice()
        {
            this.Sides = 6;
        }

    }
}