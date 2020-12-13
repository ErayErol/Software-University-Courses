using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            var matrix = new Char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            var directions = new Queue<char>(Console.ReadLine());
            var resultRow = new int[1];
            var resultCol = new int[1];
            var winOrDead = "";

            while (directions.Any())
            {
                var currDirections = directions.Dequeue();
                bool isPlayerFound = false;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row][col] == 'P')
                        {
                            if (IsPlayerInRange(matrix, row, col, currDirections, rows, cols) == false)
                            {
                                resultRow[0] = row;
                                resultCol[0] = col;
                                winOrDead = "won";
                            }

                            matrix[row][col] = '.';
                            isPlayerFound = true;
                            break;
                        }
                    }

                    if (isPlayerFound)
                    {
                        break;
                    }
                }

                bool isValid = false;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row][col] == 'B')
                        {
                            if (IsDead(matrix, row, col, currDirections, rows, cols, isValid, resultRow, resultCol))
                            {
                                winOrDead = "dead";
                            }
                        }
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row][col] == 'b')
                        {
                            matrix[row][col] = 'B';
                        }
                    }
                }

                if (winOrDead != "")
                {
                    foreach (var row in matrix)
                    {
                        Console.WriteLine(string.Join("", row));
                    }

                    Console.WriteLine($"{winOrDead}: {resultRow[0]} {resultCol[0]}");
                    Environment.Exit(0);
                }
            }
        }

        static bool IsDead(char[][] matrix, int row, int col, char currDirections, int rangeRow, int rangeCol, bool isValid, int[] resultRow, int[] resultCol)
        {
            if (row - 1 >= 0)
            {
                if (matrix[row - 1][col] == 'P')
                {
                    resultRow[0] = row - 1;
                    resultCol[0] = col;
                    matrix[row - 1][col] = 'b';
                    isValid = true;
                }
                else if (matrix[row - 1][col] == '.')
                {
                    matrix[row - 1][col] = 'b';
                }
            }
            if (row + 1 < rangeRow)
            {
                if (matrix[row + 1][col] == 'P')
                {
                    resultRow[0] = row + 1;
                    resultCol[0] = col;
                    matrix[row + 1][col] = 'b';
                    isValid = true;
                }
                else if (matrix[row + 1][col] == '.')
                {
                    matrix[row + 1][col] = 'b';
                }
            }
            if (col - 1 >= 0)
            {
                if (matrix[row][col - 1] == 'P')
                {
                    resultRow[0] = row;
                    resultCol[0] = col - 1;
                    matrix[row][col - 1] = 'b';
                    isValid = true;
                }
                else if (matrix[row][col - 1] == '.')
                {
                    matrix[row][col - 1] = 'b';
                }
            }
            if (col + 1 < rangeCol)
            {
                if (matrix[row][col + 1] == 'P')
                {
                    resultRow[0] = row;
                    resultCol[0] = col + 1;
                    matrix[row][col + 1] = 'b';
                    isValid = true;
                }
                else if (matrix[row][col + 1] == '.')
                {
                    matrix[row][col + 1] = 'b';
                }
            }

            return isValid;
        }

        static bool IsPlayerInRange(char[][] matrix, int row, int col, int direction, int rangeRow, int rangeCol)
        {
            if (direction == 'U')
            {
                if (row - 1 >= 0)
                {
                    matrix[row - 1][col] = 'P';
                    return true;
                }
            }
            else if (direction == 'D')
            {
                if (row + 1 < rangeRow)
                {
                    matrix[row + 1][col] = 'P';
                    return true;
                }
            }
            else if (direction == 'L')
            {
                if (col - 1 >= 0)
                {
                    matrix[row][col - 1] = 'P';
                    return true;
                }
            }
            else if (direction == 'R')
            {
                if (col + 1 < rangeCol)
                {
                    matrix[row][col + 1] = 'P';
                    return true;
                }
            }

            return false;
        }
    }
}