namespace _01._Diagonal_Difference
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];

            for (var row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = currentRow;
            }

            var firstDiagonalSum = 0;

            for (var i = 0; i < n; i++)
            {
                firstDiagonalSum += matrix[i][i];
            }

            var secondDiagonalSum = 0;

            for (var i = 0; i < n; i++)
            {
                secondDiagonalSum += matrix[i][(n - 1) - i];
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
