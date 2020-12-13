namespace _01.DangerousFloor
{
    using System;
    using System.Linq;

    class Program
    {
        static char[][] floor; // може да се използва навсякъде
        static int row; // може да се използва навсякъде
        static int col; // може да се използва навсякъде
        static int targetRow; // може да се използва навсякъде
        static int targetCol; // може да се използва навсякъде
        static char figure; // може да се използва навсякъде

        static void Main(string[] args)
        {
            floor = new char[8][];
            for (int i = 0; i < 8; i++)
            {
                floor[i] = Console.ReadLine().Split(",").Select(char.Parse).ToArray();
            }

            while (true)
            {
                var commands = Console.ReadLine();
                if (commands == "END") break;
                figure = commands[0];
                row = int.Parse(commands[1].ToString());
                col = int.Parse(commands[2].ToString());
                targetRow = int.Parse(commands[4].ToString());
                targetCol = int.Parse(commands[5].ToString());

                if (FigureExist() == false)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }

                if (IsMoveValid() == false)
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }

                if (IsInRange() == false)
                {
                    Console.WriteLine("Move go out of board!");
                }
            }
        }

        private static bool FigureExist()
        {
            return floor[row][col] == figure;
        }

        private static bool IsMoveValid()
        {
            switch (figure)
            {
                case 'P': return ValidPawnMove();
                case 'R': return ValidStraightMove();
                case 'B': return ValidDiagonalMove();
                case 'Q': return ValidStraightMove() || ValidDiagonalMove();
                case 'K': return ValidKingMove();
            }

            return false;
        }

        private static bool IsInRange()
        {
            if (targetRow >= 0 && targetRow <= 7 && targetCol >= 0 && targetCol <= 7)
            {
                floor[row][col] = 'x';
                floor[targetRow][targetCol] = figure;
                return true;
            }

            return false;
        }

        private static bool ValidKingMove()
        {
            bool validRow = Math.Abs(row - targetRow) < 2;
            bool validCow = Math.Abs(col - targetCol) < 2;

            return validRow && validCow;
        }

        private static bool ValidDiagonalMove()
        {
            return Math.Abs(targetRow - row) == Math.Abs(targetCol - col);
        }

        private static bool ValidStraightMove()
        {
            bool sameRow = row == targetRow;
            bool sameCol = col == targetCol;

            return sameRow || sameCol;
        }

        private static bool ValidPawnMove()
        {
            bool validRow = row - 1 == targetRow;
            bool validCol = col == targetCol;

            return validRow && validCol;
        }
    }
}