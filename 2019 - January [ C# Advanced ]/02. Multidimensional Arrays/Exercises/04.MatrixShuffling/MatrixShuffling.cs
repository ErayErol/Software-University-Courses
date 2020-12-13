using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[][] jagged = new String[n[0]][];

            for (int i = 0; i < n[0]; i++)
            {
                jagged[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "END":
                        return;

                    case "swap":
                        if (commands.Length == 5)
                        {
                            int row0 = int.Parse(commands[1]);
                            int col0 = int.Parse(commands[2]);
                            int row1 = int.Parse(commands[3]);
                            int col1 = int.Parse(commands[4]);

                            if ((row0 < 0 || row0 >= n[0]) ||
                                (row1 < 0 || row1 >= n[0]) ||
                                (col0 < 0 || col0 >= n[1]) ||
                                (col1 < 0 || col1 >= n[1]))
                            {
                                Console.WriteLine("Invalid input!");
                            }
                            else
                            {
                                var tempElement = jagged[row0][col0];
                                jagged[row0][col0] = jagged[row1][col1];
                                jagged[row1][col1] = tempElement;

                                foreach (var row in jagged)
                                {
                                    Console.WriteLine(string.Join(" ", row));
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }
    }
}