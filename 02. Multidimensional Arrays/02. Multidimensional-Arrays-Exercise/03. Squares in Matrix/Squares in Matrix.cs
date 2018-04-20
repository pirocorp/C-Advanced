namespace _03.Squares_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = numbers[0];
            var cols = numbers[1];

            var matrix = new char[rows][];

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s[0])
                    .ToArray();

                matrix[rowIndex] = currentRow;
            }

            var numberOfSquaresFound = 0;

            for (var rowIndex = 0; rowIndex < rows - 1; rowIndex++)
            {
                for (var colIndex = 0; colIndex < cols - 1; colIndex++)
                {
                    var currentChar = matrix[rowIndex][colIndex];

                    if (currentChar == matrix[rowIndex][colIndex + 1] &&
                        currentChar == matrix[rowIndex + 1][colIndex] &&
                        currentChar == matrix[rowIndex + 1][colIndex + 1])
                    {
                        numberOfSquaresFound++;
                    }
                }
            }

            Console.WriteLine(numberOfSquaresFound);
        }
    }
}
