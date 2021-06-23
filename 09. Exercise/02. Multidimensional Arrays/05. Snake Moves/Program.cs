namespace _05._Snake_Moves
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Program
    {
        private static string snake = string.Empty;
        private static Queue<char> currentSnake;

        private static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            snake = Console.ReadLine() ?? string.Empty;
            currentSnake = new Queue<char>(snake);

            var matrix = new char[rows, cols];

            for (var rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                if (rowIndex % 2 == 0)
                {
                    for (var colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                    {
                        matrix[rowIndex, colIndex] = GetChar();
                    }
                }
                else
                {
                    for (var colIndex = matrix.GetLength(1) - 1; colIndex >= 0; colIndex--)
                    {
                        matrix[rowIndex, colIndex] = GetChar();
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (var rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                var sb = new StringBuilder();

                for (var colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    Console.Write($"{matrix[rowIndex, colIndex]}");
                }

                Console.WriteLine();
            }
        }

        private static char GetChar()
        {
            if (!currentSnake.Any())
            {
                currentSnake = new Queue<char>(snake);
            }

            return currentSnake.Dequeue();
        }
    }
}
