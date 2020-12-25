namespace _02.Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Sneaking
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var jagged = new Char[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().ToCharArray();
            }

            var diedRow = new int[1];
            var diedCol = new int[1];
            var isDead = new int[1] { 0 };

            var commands = new Queue<char>(Console.ReadLine().ToCharArray());
            while (true)
            {
                Enemy(n, jagged, diedRow, diedCol, isDead);

                if (isDead[0] == -1)
                {
                    SamIsDead(jagged, diedRow, diedCol);
                }

                var direction = commands.Dequeue();

                Sam(n, jagged, direction);
            }
        }

        private static void Sam(int n, char[][] jagged, char direction)
        {
            bool isValid = false;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] == 'S')
                    {
                        isValid = true;

                        switch (direction)
                        {
                            case 'U':
                                KillNikoladze(jagged, row, col, direction);
                                jagged[row][col] = '.';
                                jagged[row - 1][col] = 'S';
                                break;
                            case 'D':
                                KillNikoladze(jagged, row, col, direction);
                                jagged[row][col] = '.';
                                jagged[row + 1][col] = 'S';
                                break;
                            case 'R':
                                jagged[row][col] = '.';
                                jagged[row][col + 1] = 'S';
                                break;
                            case 'L':
                                jagged[row][col] = '.';
                                jagged[row][col - 1] = 'S';
                                break;
                        }

                        break;
                    }
                }

                if (isValid)
                {
                    break;
                }
            }
        }

        private static void KillNikoladze(char[][] jagged, int row, int col, char direction)
        {
            int currRow = row;
            int currCol = col;
            switch (direction)
            {
                case 'U': currRow = row - 1; break;
                case 'D': currRow = row + 1; break;
                case 'R': currCol = col + 1; break;
                case 'L': currCol = col - 1; break;
            }

            if (jagged[currRow].Contains('N'))
            {
                for (int e = 0; e < jagged[currRow].Length; e++)
                {
                    if (jagged[currRow][e] == 'N')
                    {
                        jagged[currRow][e] = 'X';
                        break;
                    }
                }

                Console.WriteLine("Nikoladze killed!");
                jagged[row][col] = '.';
                jagged[currRow][currCol] = 'S';

                foreach (var jaggedRow in jagged)
                {
                    Console.WriteLine(string.Join("", jaggedRow));
                }

                Environment.Exit(0);
            }
        }

        private static void Enemy(int n, char[][] jagged, int[] diedRow, int[] diedCol, int[] isDead)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] == 'b')
                    {
                        if (col + 1 == jagged[row].Length)
                        {
                            jagged[row][col] = 'd';

                            EnemyFromRightToLeft(jagged, col, row, diedRow, diedCol, isDead);

                            break;
                        }
                        if (jagged[row].Contains('S'))
                        {
                            EnemyFromLeftToRight(jagged, col, row, diedRow, diedCol, isDead);
                        }

                        jagged[row][col + 1] = 'b';
                        jagged[row][col] = '.';

                        break;
                    }
                    else if (jagged[row][col] == 'd')
                    {
                        if (col == 0)
                        {
                            jagged[row][col] = 'b';

                            EnemyFromLeftToRight(jagged, col, row, diedRow, diedCol, isDead);

                            break;
                        }
                        if (jagged[row].Contains('S'))
                        {
                            EnemyFromRightToLeft(jagged, col, row, diedRow, diedCol, isDead);
                        }

                        jagged[row][col - 1] = 'd';
                        jagged[row][col] = '.';

                        break;
                    }
                }
            }
        }

        private static void EnemyFromLeftToRight(char[][] jagged, int col, int row, int[] deadRow, int[] deadCol, int[] isDead)
        {
            for (int c = col; c < jagged[row].Length; c++)
            {
                if (jagged[row][c] == 'S')
                {
                    RowAndColOfDeadSam(jagged, col, row, deadRow, deadCol, c, isDead);
                }
            }
        }

        private static void EnemyFromRightToLeft(char[][] jagged, int col, int row, int[] deadRow, int[] deadCol, int[] isDead)
        {
            for (int c = col; c >= 0; c--)
            {
                if (jagged[row][c] == 'S')
                {
                    RowAndColOfDeadSam(jagged, col, row, deadRow, deadCol, c, isDead);
                }
            }
        }

        private static void RowAndColOfDeadSam(char[][] jagged, int col, int row, int[] deadRow, int[] deadCol, int c, int[] isDead)
        {
            jagged[row][c] = 'X';
            deadRow[0] = row;
            deadCol[0] = c;
            isDead[0] = -1;
        }

        private static void SamIsDead(char[][] jagged, int[] row, int[] c)
        {
            Console.WriteLine($"Sam died at {row[0]}, {c[0]}");
            foreach (var jaggedRow in jagged)
            {
                Console.WriteLine(string.Join("", jaggedRow));
            }
            Environment.Exit(0);
        }
    }
}