namespace _02.Square_With_Maximum_Sum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            //Overkill solution :D

            var matrix = ReadMatrixFromConsole();

            var subMatrix = BiggestSubMatrix(matrix, 2, 2);

            PrintMatrix(subMatrix);

            Console.WriteLine(FindValueOfSubMatrix(subMatrix, 0, 0, 2, 2));
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (var row = 0; row < matrix.Length; row++)
            {
                var currentRow = matrix[row];
                var strings = currentRow.ToList().ConvertAll(input => $"{input}").ToArray();

                Console.WriteLine(string.Join(" ", strings));
            }
        }

        private static int[][] BiggestSubMatrix(int[][] matrix, int rows, int cols)
        {
            if (matrix.Length < rows)
            {
                throw new Exception("Out of boundaries");
            }

            foreach (var row in matrix)
            {
                if (row.Length < cols)
                {
                    throw new Exception("Out of boundaries");
                }
            }

            if (rows <= 0 || cols <= 0)
            {
                throw new Exception("Negative or no boundaries");
            }

            var maxSum = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;

            var matrixSearchLenght = matrix.Length - (rows - 1);

            for (var rowIndex = 0; rowIndex < matrixSearchLenght; rowIndex++)
            {
                var matrixSearchLenghtForCurrentRow = Math.Max(0, matrix[rowIndex].Length - (cols - 1));

                for (var colIndex = 0; colIndex < matrixSearchLenghtForCurrentRow; colIndex++)
                {
                    var currentValue = FindValueOfSubMatrix(matrix, rowIndex, colIndex, rows, cols);

                    if (currentValue > maxSum)
                    {
                        maxSum = currentValue;
                        maxRow = rowIndex;
                        maxCol = colIndex;
                    }
                }
            }

            var newMatrix = new int[rows][];

            for (var i = maxRow; i < maxRow + rows; i++)
            {
                for (var j = maxCol; j < maxCol + cols; j++)
                {
                    newMatrix[i - maxRow] = matrix[i].ToList().GetRange(maxCol, cols).ToArray();
                }
            }

            return newMatrix;
        }

        private static int FindValueOfSubMatrix(int[][] matrix, int rowIndexOfSubMatrix, int colIndexOfSubMatrix, int rowsOfSubMatrix, int colsOfSubMatrix)
        {
            var sum = 0;

            for (var i = rowIndexOfSubMatrix; i < rowIndexOfSubMatrix + rowsOfSubMatrix; i++)
            {
                for (var j = colIndexOfSubMatrix; j < colIndexOfSubMatrix + colsOfSubMatrix; j++)
                {
                    sum += matrix[i][j];
                }
            }

            return sum;
        }

        private static int[][] ReadMatrixFromConsole()  
        {
            var tokens = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var row = tokens[0];
            var col = tokens[1];

            var matrix = new int[row][];

            for (var rowIndex = 0; rowIndex < row; rowIndex++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[rowIndex] = currentRow;
            }

            return matrix;
        }
    }
}
