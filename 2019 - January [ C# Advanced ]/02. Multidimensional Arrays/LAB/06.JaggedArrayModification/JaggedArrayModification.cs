using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int rowSize = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rowSize][];

            for (int r = 0; r < rowSize; r++)
            {
                int[] col = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[r] = col;
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "END":
                        foreach (var row in jaggedArray)
                        {
                            Console.WriteLine(string.Join(" ", row));
                        }
                        return;

                    default:
                        int currentRow = int.Parse(commands[1]);
                        int currentCol = int.Parse(commands[2]);
                        int value = int.Parse(commands[3]);

                        if (currentRow >= jaggedArray.Length || currentCol >= jaggedArray.Length || currentRow < 0 || currentCol < 0)
                        {
                            Console.WriteLine("Invalid coordinates");
                            continue;
                        }
                        if (commands[0] == "Add")
                        {
                            jaggedArray[currentRow][currentCol] += value;
                        }
                        else if (commands[0] == "Subtract")
                        {
                            jaggedArray[currentRow][currentCol] -= value;
                        }
                        break;
                }
            }
        }
    }
}