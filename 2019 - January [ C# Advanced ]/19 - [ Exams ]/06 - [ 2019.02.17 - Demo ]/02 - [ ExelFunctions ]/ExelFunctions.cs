namespace _02.ExelFunctions
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class ExelFunctions
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var header = Console.ReadLine().Split(", ").ToList();
            var jagged = CreateJaggedArray(rows);
            var command = Console.ReadLine().Split(" ");
            Execute(command, header, rows, jagged);
        }

        private static string[][] CreateJaggedArray(int rows)
        {
            string[][] jagged = new String[rows - 1][];
            for (int i = 0; i < rows - 1; i++)
            {
                jagged[i] = Console.ReadLine().Split(", ");
            }

            return jagged;
        }

        private static void Execute(string[] command, List<string> header, int rows, string[][] jagged)
        {
            var special = command[1];
            var index = header.IndexOf(special);

            switch (command[0])
            {
                case "hide": HideAndPrint(command, header, rows, jagged, special, index); break;
                case "filter": FilterAndPrint(command, header, jagged, special, index); break;
                case "sort": SortAndPrint(command, header, jagged, special, index); break;
            }
        }

        private static void SortAndPrint(string[] command, List<string> header, string[][] jagged, string sortHeader, int index)
        {
            Console.WriteLine(string.Join(" | ", header));
            jagged = jagged.OrderBy(i => i[index]).ToArray();
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" | ", row));
            }
        }

        private static void FilterAndPrint(string[] command, List<string> header, string[][] jagged, string filterHeader, int index)
        {
            Console.WriteLine(string.Join(" | ", header));
            var value = command[2];
            foreach (var row in jagged)
            {
                if (row[index] == value)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
        }

        private static void HideAndPrint(string[] command, List<string> header, int rows, string[][] jagged, string deleteCol, int index)
        {
            header.RemoveAt(index);
            Console.WriteLine(string.Join(" | ", header));
            for (int row = 0; row < rows - 1; row++)
            {
                var resultList = new List<string>();

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (col != index)
                    {
                        resultList.Add(jagged[row][col]);
                    }
                }

                Console.WriteLine(string.Join(" | ", resultList));
            }
        }
    }
}