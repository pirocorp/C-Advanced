namespace _04.Maximal_Sum
{
    using System;
    using System.Linq;

    public class MaximalSum
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

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[rowIndex] = currentRow;
            }

            var maxSum = int.MinValue;
            var rowMaxIndex = 0;
            var colMaxIndex = 0;

            for (var rowIndex = 0; rowIndex < rows - 2; rowIndex++)
            {
                for (var colIndex = 0; colIndex < cols - 2; colIndex++)
                {
                    var currentSum = matrix[rowIndex + 0][colIndex] + matrix[rowIndex + 0][colIndex + 1] + matrix[rowIndex + 0][colIndex + 2] +
                                     matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1] + matrix[rowIndex + 1][colIndex + 2] +
                                     matrix[rowIndex + 2][colIndex] + matrix[rowIndex + 2][colIndex + 1] + matrix[rowIndex + 2][colIndex + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowMaxIndex = rowIndex;
                        colMaxIndex = colIndex;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (var rowIndex = rowMaxIndex; rowIndex < rowMaxIndex + 3; rowIndex++)
            {
                for (var colIndex = colMaxIndex; colIndex < colMaxIndex + 3; colIndex++)
                {
                    Console.Write($"{matrix[rowIndex][colIndex]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
