namespace _02.TronRacers
{
    using System;
    using System.Linq;

    class TronRacers
    {
        static int num;
        static char[][] matrix = new char[num][];
        static int fRow;
        static int fCol;
        static int sRow;
        static int sCol;

        static void Main(string[] args)
        {
            AddPlayers();

            while (true)
            {
                var commands = Directions(out var fDirection, out var sDirection);

                bool isFirst = true;

                MovePlayers(fDirection, fRow, fCol, isFirst);

                IsPlayerDead(isFirst);

                MovePlayers(sDirection, sRow, sCol, isFirst == false);

                IsPlayerDead(isFirst == false);
            }
        }

        private static string[] Directions(out string fDirection, out string sDirection)
        {
            var commands = Console.ReadLine().Split();
            fDirection = commands[0];
            sDirection = commands[1];
            return commands;
        }

        private static void IsPlayerDead(bool isFirst)
        {
            if (isFirst)
            {
                if (matrix[fRow][fCol] == 's')
                {
                    Dead(fRow, fCol);
                }

                matrix[fRow][fCol] = 'f';
            }
            else
            {
                if (matrix[sRow][sCol] == 'f')
                {
                    Dead(sRow, sCol);
                }

                matrix[sRow][sCol] = 's';
            }
        }

        private static void MovePlayers(string direction, int row, int col, bool isFirst)
        {
            switch (direction)
            {
                case "up":
                    if (row > 0)
                    {
                        row--;
                        break;
                    }

                    row = num - 1;
                    break;
                case "down":
                    if (row < num - 1)
                    {
                        row++;
                        break;
                    }

                    row = 0;
                    break;
                case "left":
                    if (col > 0)
                    {
                        col--;
                        break;
                    }

                    col = num - 1;
                    break;
                case "right":
                    if (col < num - 1)
                    {
                        col++;
                        break;
                    }

                    col = 0;
                    break;
            }

            if (isFirst)
            {
                fRow = row;
                fCol = col;
            }
            else
            {
                sRow = row;
                sCol = col;
            }
        }

        private static void Dead(int row, int col)
        {
            matrix[row][col] = 'x';
            foreach (var r in matrix)
            {
                Console.WriteLine(string.Join("", r));
            }
            Environment.Exit(0);
        }

        private static void AddPlayers()
        {
            num = int.Parse(Console.ReadLine());
            matrix = new char[num][];
            for (int row = 0; row < num; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();

                if (matrix[row].Contains('f'))
                {
                    fRow = row;
                    fCol = Array.IndexOf(matrix[row], 'f');
                }
                else if (matrix[row].Contains('s'))
                {
                    sRow = row;
                    sCol = Array.IndexOf(matrix[row], 's');
                }
            }
        }
    }
}