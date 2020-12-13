using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> player0 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> player1 = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (player0.Count != 0 && player1.Count != 0)
            {
                if (player0[0] > player1[0])
                {
                    player0.Add(player0[0]);
                    player0.Add(player1[0]);

                    player0.RemoveAt(0);
                    player1.RemoveAt(0);
                }
                else if (player0[0] < player1[0])
                {
                    player1.Add(player1[0]);
                    player1.Add(player0[0]);

                    player0.RemoveAt(0);
                    player1.RemoveAt(0);
                }
                else
                {
                    player0.RemoveAt(0);
                    player1.RemoveAt(0);
                }
            }

            int sum = 0;
            if (player0.Count > 0)
            {
                sum = player0.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else if (player1.Count > 0)
            {
                sum = player1.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}