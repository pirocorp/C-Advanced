namespace _01.Matrix_of_Palindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var rows = numbers[0];
            var cols = numbers[1];

            var matrix = new string[rows][];

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new string[cols];

                matrix[rowIndex][0] = new string(alphabet[rowIndex], 3);
                matrix[rowIndex][cols - 1] = $"{alphabet[rowIndex]}{alphabet[(cols - 1 ) + rowIndex]}{alphabet[rowIndex]}";

                for (var colIndex = 1; colIndex < cols - 1; colIndex++)
                {
                    matrix[rowIndex][colIndex] =
                        $"{alphabet[rowIndex]}{alphabet[rowIndex + colIndex]}{alphabet[rowIndex]}";
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
