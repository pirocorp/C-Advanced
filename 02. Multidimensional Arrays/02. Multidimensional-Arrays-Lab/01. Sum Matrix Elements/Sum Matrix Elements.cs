namespace _01.Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
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

            var sum = 0;

            foreach (var rowInMatrix in matrix)
            {
                sum += rowInMatrix.Sum();
            }

            Console.WriteLine(row);
            Console.WriteLine(col);
            Console.WriteLine(sum);
        }
    }
}
