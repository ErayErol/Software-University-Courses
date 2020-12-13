namespace _03.Bombs
{
    using System;
    using System.Linq;

    class Bombs
    {
        static int rowsAndCols;
        static int[][] matrix;
        static int power;

        static void Main(string[] args)
        {
            Matrix();
            Bomb();
            Print();
        }

        private static void Matrix()
        {
            rowsAndCols = int.Parse(Console.ReadLine());
            matrix = new int[rowsAndCols][];
            for (int row = 0; row < rowsAndCols; row++)
            {
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
        }

        private static void Bomb()
        {
            var bombs = Console.ReadLine().Split();
            for (int i = 0; i < bombs.Length; i++)
            {
                var bombRow = int.Parse(bombs[i][0].ToString());
                var bombCol = int.Parse(bombs[i][2].ToString());
                power = matrix[bombRow][bombCol];
                if (power > 0)
                {
                    Explode(bombRow - 1, bombCol - 1);
                    Explode(bombRow - 1, bombCol);
                    Explode(bombRow - 1, bombCol + 1);
                    Explode(bombRow, bombCol - 1);
                    Explode(bombRow, bombCol + 1);
                    Explode(bombRow + 1, bombCol - 1);
                    Explode(bombRow + 1, bombCol);
                    Explode(bombRow + 1, bombCol + 1);
                    matrix[bombRow][bombCol] = 0;
                }
            }
        }

        private static void Print()
        {
            var sum = 0;
            var aLive = 0;
            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {
                    if (matrix[row][col] > 0)
                    {
                        sum += matrix[row][col];
                        aLive++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aLive}\nSum: {sum}");
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void Explode(int row, int col)
        {
            if (row >= 0 && col >= 0 && row < rowsAndCols && col < rowsAndCols && matrix[row][col] > 0)
            {
                matrix[row][col] -= power;
            }
        }
    }
}