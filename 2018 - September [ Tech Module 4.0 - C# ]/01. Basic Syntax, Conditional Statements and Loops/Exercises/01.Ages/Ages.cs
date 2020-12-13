namespace _01.Ages
{
    using System;

    class Ages
    {
        static void Main(string[] args)
        {
            int personAge = int.Parse(Console.ReadLine());

            if (personAge >= 0 && personAge <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (personAge >= 3 && personAge <= 13)
            {
                Console.WriteLine("child");
            }
            else if (personAge >= 14 && personAge <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (personAge >= 20 && personAge <= 65)
            {
                Console.WriteLine("adult");
            }
            else
            {
                Console.WriteLine("elder");
            }
        }
    }
}