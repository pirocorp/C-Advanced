namespace _08._Bombs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var matrix = ReadMatrix();

            var bombs = ReadBombs();

            foreach (var bomb in bombs)
            {
                ProcessBomb(bomb, matrix);
            }

            Console.WriteLine($"Alive cells: {matrix.SelectMany(x => x).Count(x => x > 0)}");

            Console.WriteLine($"Sum: {matrix.SelectMany(x => x).Where(x => x > 0).Sum()}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void ProcessBomb((int X, int Y) bomb, int[][] matrix)
        {
            Func<int, int, Tuple<int, int>>[] targets =
            {
                (row, col) => new Tuple<int, int>(row + 1, col),
                (row, col) => new Tuple<int, int>(row, col + 1),
                (row, col) => new Tuple<int, int>(row + 1, col + 1),

                (row, col) => new Tuple<int, int>(row - 1, col),
                (row, col) => new Tuple<int, int>(row, col - 1),
                (row, col) => new Tuple<int, int>(row - 1, col - 1),

                (row, col) => new Tuple<int, int>(row + 1, col - 1),
                (row, col) => new Tuple<int, int>(row - 1, col + 1),
            };

            var (row, col) = bomb;
            var value = matrix[row][col];

            if (value <= 0)
            {
                return;
            }

            matrix[row][col] = 0;

            foreach (var target in targets)
            {
                var (targetRow, targetCol) = target(row, col);

                if (targetRow < 0
                    || targetRow >= matrix.Length
                    || targetCol < 0
                    || targetCol >= matrix[targetRow].Length
                    || matrix[targetRow][targetCol] <= 0)
                {
                    continue;
                }

                matrix[targetRow][targetCol] -= value;
            }
        }

        private static IEnumerable<(int X, int Y)> ReadBombs()
            => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    var coordinates = x.Split(",").Select(int.Parse).ToArray();
                    return (X: coordinates[0], Y: coordinates[1]);
                });

        private static int[][] ReadMatrix()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];

            for (var i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }
    }
}
