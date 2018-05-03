using System.IO;

namespace _06._Bunker_Buster
{
    using System;
    using System.Linq;

    public class BunkerBuster
    {
        private static int rows;
        private static int cols;
        private static int[][] matrix = null;

        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rows = dimensions[0];
            cols = dimensions[1];

            matrix = new int[rows][];

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var input = Console.ReadLine();

            while (input != "cease fire!")
            {
                var tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                var rowBomb = int.Parse(tokens[0]);
                var colBomb = int.Parse(tokens[1]);
                var bombPower = (int) tokens[2][0];

                ProcessBomb(bombPower, rowBomb, colBomb);
                
                input = Console.ReadLine();
            }

            var destroedBunkers = CountDestroedCells();
            var percent = (destroedBunkers / (double) (rows * cols)) * 100;

            Console.WriteLine($"Destroyed bunkers: {destroedBunkers}");
            Console.WriteLine($"Damage done: {percent:F1} %");
        }

        private static int CountDestroedCells()
        {
            var result = 0;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (var colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] <= 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void ProcessBomb(int bombPower, int rowBomb, int colBomb)
        {
            var reducedPowerOfBomb = (int)Math.Ceiling(bombPower / 2.0);

            var minCol = Math.Max(0, colBomb - 1);
            var maxCol = Math.Min(cols - 1, colBomb + 1);
            var minRow = Math.Max(0, rowBomb - 1);
            var maxRow = Math.Min(rows - 1, rowBomb + 1);

            for (var rowIndex = minRow; rowIndex <= maxRow; rowIndex++)
            {
                for (var colIndex = minCol; colIndex <= maxCol; colIndex++)
                {
                    if (rowIndex == rowBomb && colIndex == colBomb)
                    {
                        matrix[rowIndex][colIndex] -= bombPower;
                        continue;
                    }

                    matrix[rowIndex][colIndex] -= reducedPowerOfBomb;
                }
            }
        }
    }
}
