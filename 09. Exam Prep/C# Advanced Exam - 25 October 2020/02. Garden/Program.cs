namespace _02._Garden
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var matrix = InitializeMatrix();

            var input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                var (row, col) = ParseInput(input);

                if (row >= matrix.Length || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                ProcessInput(row, col, matrix);
                input = Console.ReadLine();
            }

            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }

        private static void ProcessInput(int row, int col, int[][] matrix)
        {
            for (var i = 0; i < matrix[row].Length; i++)
            {
                matrix[row][i] += 1;
            }

            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i][col] += 1;
            }

            matrix[row][col] -= 1;
        }

        private static int[][] InitializeMatrix()
        {
            var (n, m) = ParseInput(Console.ReadLine());
            var matrix = new int[n][];

            for (var i = 0; i < n; i++)
            {
                matrix[i] = new int[m];
            }

            return matrix;
        }

        private static (int A, int B) ParseInput(string input)
        {
            var values = input
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            return (values[0], values[1]);
        }
    }
}
