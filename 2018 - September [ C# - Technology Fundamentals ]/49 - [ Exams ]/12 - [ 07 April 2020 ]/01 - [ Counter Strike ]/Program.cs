using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            string input;
            int winsCounter = 0;
            bool flag = true;

            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (energy - distance < 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winsCounter} won battles and {energy} energy");
                    flag = false;
                    break;
                }
                else
                {
                    energy -= distance;
                    winsCounter++;

                    if (winsCounter % 3 == 0)
                    {
                        energy += winsCounter;
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine($"Won battles: {winsCounter}. Energy left: {energy}");
            }
        }
    }
}
