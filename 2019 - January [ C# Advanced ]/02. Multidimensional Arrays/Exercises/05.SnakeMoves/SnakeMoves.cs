using System;
using System.Linq;
using System.Text;

namespace _05.SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var snakeName = Console.ReadLine();

            StringBuilder snakeForResult = new StringBuilder();
            int indexForResult = 0;
            int index = 0;

            for (int row = 0; row < n[0]; row++)
            {
                for (int col = 0; col < n[1]; col++)
                {
                    if (snakeForResult.Length % snakeName.Length == 0)
                    {
                        index = 0;
                    }
                    snakeForResult.Append(snakeName[index++]);
                    Console.Write(snakeForResult[indexForResult++].ToString());
                }

                Console.WriteLine();
            }
        }
    }
}