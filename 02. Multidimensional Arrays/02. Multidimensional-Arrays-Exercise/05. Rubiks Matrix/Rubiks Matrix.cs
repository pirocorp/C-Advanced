namespace _05.Rubiks_Matrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RubiksMatrix
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = numbers[0];
            var cols = numbers[1];

            var matrix = new int[rows][];
            var originalMatrix = new int[rows][];

            var initializer = 1;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];
                originalMatrix[rowIndex] = new int[cols];

                for (var colIndex = 0; colIndex < cols; colIndex++)
                {
                    originalMatrix[rowIndex][colIndex] = matrix[rowIndex][colIndex] = initializer++;
                }
            }

            //PrintMatrix(matrix);

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var target = int.Parse(tokens[0]);
                var command = tokens[1].ToLower();
                var moves = int.Parse(tokens[2]);

                switch (command)
                {
                    case "up":
                        MoveMatrixColumn(matrix, target, moves, "up");
                        //PrintMatrix(matrix);
                        break;
                    case "down":
                        MoveMatrixColumn(matrix, target, moves, "down");
                        //PrintMatrix(matrix);
                        break;
                    case "left":
                        MoveMatrixRow(matrix, target, moves, "left");
                        //PrintMatrix(matrix);
                        break;
                    case "right":
                        MoveMatrixRow(matrix, target, moves, "right");
                        //PrintMatrix(matrix);
                        break;
                }
            }

            ReverseMatrix(matrix, originalMatrix);
        }

        private static void ReverseMatrix(int[][] matrix, int[][] originalMatrix)
        {
            //PrintMatrix(matrix);
            //Console.WriteLine();
            //PrintMatrix(originalMatrix);

            for (var rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (var colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (originalMatrix[rowIndex][colIndex] == matrix[rowIndex][colIndex])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var originalValue = originalMatrix[rowIndex][colIndex];
                        var cordinatesInMixedMatrix = FindCordinatesOf(matrix, originalValue);

                        var row = cordinatesInMixedMatrix.Key;
                        var col = cordinatesInMixedMatrix.Value;

                        var swap = matrix[rowIndex][colIndex];
                        matrix[rowIndex][colIndex] = originalValue;
                        matrix[row][col] = swap;

                        Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({row}, {col})");
                        //PrintMatrix(matrix);
                    }
                }
            }
        }

        private static KeyValuePair<int, int> FindCordinatesOf(int[][] matrix, int value)
        {
            for (var row = 0; row < matrix.Length; row++)
            {
                for (var col = 0; col < matrix[row].Length; col++)
                {
                    var currentValue = matrix[row][col];

                    if (value == currentValue)
                    {
                        return new KeyValuePair<int, int>(row, col);
                    }
                }
            }

            return new KeyValuePair<int, int>(-1, -1);
        }

        private static void MoveMatrixRow(int[][] matrix, int target, int moves, string direction)
        {
            moves = moves % matrix[target].Length;

            if (direction == "right")
            {
                moves = matrix[target].Length - moves;
            }

            for (var currentMove = 0; currentMove < moves; currentMove++)
            {
                var rowBegining = matrix[target][0];

                for (var columnIndex = 0; columnIndex < matrix[target].Length - 1; columnIndex++)
                {
                    matrix[target][columnIndex] = matrix[target][columnIndex + 1];
                }

                matrix[target][matrix[target].Length - 1] = rowBegining;
            }
        }

        private static void MoveMatrixColumn(int[][] matrix, int colomn, int moves, string direction)
        {
            moves = moves % matrix.Length;

            if (direction == "down")
            {
                moves = matrix.Length - moves;
            }

            for (var currentMove = 0; currentMove < moves; currentMove++)
            {
                var matrixStart = matrix[0][colomn];

                for (var rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
                {
                    matrix[rowIndex][colomn] = matrix[rowIndex + 1][colomn];
                }

                matrix[matrix.Length - 1][colomn] = matrixStart;
            }
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(", ", matrix[i].ToList().ConvertAll(input => $"{input:D2}").ToArray()));
            } 
        }
    }
}
