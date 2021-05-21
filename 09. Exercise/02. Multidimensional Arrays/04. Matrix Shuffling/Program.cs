namespace _04._Matrix_Shuffling
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var matrix = ReadMatrixFromConsole();

            var rows = matrix.Length;
            var cols = matrix[0].Length;

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!ValidateInput(tokens, rows, cols))
                {
                    Console.WriteLine($"Invalid input!");
                    continue;
                }

                SwapCells(tokens, matrix);
                PrintMatrix(matrix);
            }
        }

        private static bool ValidateInput(string[] tokens, int rows, int cols)
        {
            if (tokens[0] != "swap")
            {
                return false;
            }

            if (tokens.Length != 5)
            {
                return false;
            }

            var coordinates = tokens.Skip(1).Select(int.Parse).ToList();

            if (coordinates.Any(x => x < 0))
            {
                return false;
            }

            if (coordinates[0] >= rows || coordinates[2] >= rows)
            {
                return false;
            }

            if (coordinates[1] >= cols || coordinates[3] >= cols)
            {
                return false;
            }

            return true;
        }

        private static void SwapCells(string[] tokens, string[][] matrix)
        {
            var cell1Row = int.Parse(tokens[1]);
            var cell1Col = int.Parse(tokens[2]);
            var cell2Row = int.Parse(tokens[3]);
            var cell2Col = int.Parse(tokens[4]);

            var swap = matrix[cell1Row][cell1Col];
            matrix[cell1Row][cell1Col] = matrix[cell2Row][cell2Col];
            matrix[cell2Row][cell2Col] = swap;
        }

        private static void PrintMatrix(string[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static string[][] ReadMatrixFromConsole()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = numbers[0];

            var matrix = new string[rows][];

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                matrix[rowIndex] = currentRow;
            }

            return matrix;
        }
    }
}
