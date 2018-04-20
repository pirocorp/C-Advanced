namespace _02.Diagonal_Difference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];

            for (var row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = currentRow;
            }

            var firstDigonalSum = 0;

            for (var i = 0; i < n; i++)
            {
                firstDigonalSum += matrix[i][i];
            }

            var secondDiagonalSum = 0;

            for (var i = 0; i < n; i++)
            {
                secondDiagonalSum += matrix[i][(n - 1) - i];
            }

            Console.WriteLine(Math.Abs(firstDigonalSum - secondDiagonalSum));
        }
    }
}
