namespace _09.Crossfire
{
    using System;
    using System.Linq;

    public class Crossfire
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = InitializeMatrix(rows, cols);

            var inputCommand = Console.ReadLine();

            while (inputCommand != "Nuke it from orbit")
            {
                var numbers = inputCommand
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var rowIndex = numbers[0];
                var colIndex = numbers[1];
                var radius = numbers[2];

                var maxRowIndex = Math.Min(rows - 1, rowIndex + radius);
                var minRowIndex = Math.Max(0, rowIndex - radius);

                for (var currentRowIndex = minRowIndex; currentRowIndex <= maxRowIndex; currentRowIndex++)
                {
                    if (currentRowIndex >= 0 && currentRowIndex < matrix.Length && colIndex >= 0 && colIndex < matrix[currentRowIndex].Length)
                    {
                        matrix[currentRowIndex][colIndex] = 0;
                    }
                }

                var maxColIndex = Math.Min(cols - 1, colIndex + radius);
                var minColIndex = Math.Max(0, colIndex - radius);

                for (var currentColIndex = minColIndex; currentColIndex <= maxColIndex; currentColIndex++)
                {
                    if (rowIndex >= 0 && rowIndex < matrix.Length && currentColIndex >= 0 &&
                        currentColIndex < matrix[rowIndex].Length)
                    {
                        matrix[rowIndex][currentColIndex] = 0;
                    }
                }

                matrix = JaggTheMatrix(matrix);

                inputCommand = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static int[][] JaggTheMatrix(int[][] matrix)
        {
            var rowsInNewMatrix = GetNonZeroRowsFromMatrix(matrix);

            var jaggedMatrix = new int[rowsInNewMatrix][];
            var jaggedMatrixRow = 0;

            for (var rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                if (matrix[rowIndex].Any(x => x > 0))
                {
                    jaggedMatrix[jaggedMatrixRow] = matrix[rowIndex].Where(x => x > 0).ToArray();
                    jaggedMatrixRow++;
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            return jaggedMatrix;
        }

        private static int GetNonZeroRowsFromMatrix(int[][] matrix)
        {
            var rows = 0;

            for (var rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                if (matrix[rowIndex].Any(x => x > 0))
                {
                    rows++;
                }
            }

            return rows;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            var rows = matrix.Length;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                Console.WriteLine(string.Join(" ", matrix[rowIndex]));
            }
        }

        private static int[][] InitializeMatrix(int rows, int cols)
        {
            var matrix = new int[rows][];

            var initializer = 1;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int [cols];

                for (var colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex][colIndex] = initializer++;
                }
            }

            return matrix;
        }
    }
}
