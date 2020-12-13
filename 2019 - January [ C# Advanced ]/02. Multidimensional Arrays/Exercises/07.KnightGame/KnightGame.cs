using System;

namespace _07.KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }

            int maxAttacked = -1;
            int maxRow = 0;
            int maxColumn = 0;
            int countOfRemovedKnights = 0;

            while (maxAttacked != 0)
            {
                int currentAttacks = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            currentAttacks = CalculateAttacks(row, col, board);

                            if (currentAttacks > maxAttacked)
                            {
                                maxAttacked = currentAttacks;
                                maxRow = row;
                                maxColumn = col;
                            }
                        }
                    }
                }

                if (maxAttacked == 0)
                {
                    Console.WriteLine(countOfRemovedKnights);
                    return;
                }
                board[maxRow][maxColumn] = '0';
                maxAttacked = -1;
                countOfRemovedKnights++;
            }
        }

        static int CalculateAttacks(int row, int col, char[][] board)
        {
            int result = 0;

            if (IsPositionAttacked(row - 2, col - 1, board)) result++;
            if (IsPositionAttacked(row - 2, col + 1, board)) result++;
            if (IsPositionAttacked(row - 1, col - 2, board)) result++;
            if (IsPositionAttacked(row - 1, col + 2, board)) result++;
            if (IsPositionAttacked(row + 1, col - 2, board)) result++;
            if (IsPositionAttacked(row + 1, col + 2, board)) result++;
            if (IsPositionAttacked(row + 2, col - 1, board)) result++;
            if (IsPositionAttacked(row + 2, col + 1, board)) result++;

            return result;
        }

        static bool IsPositionAttacked(int row, int col, char[][] board)
        {
            return IsOnChessBoard(row, col, board[0].Length) && board[row][col] == 'K';
        }

        static bool IsOnChessBoard(int row, int col, int n)
        {
            return (row >= 0 && row < n && col >= 0 && col < n);
        }
    }
}