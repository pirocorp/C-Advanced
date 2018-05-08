using System.Linq;
using System.Text;

namespace _19._Matrix_Shuffle
{
    using System;

    public class MatrixShuffle
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().ToCharArray();

            var matrix = InitializeMatrix(n);

            FillMatrix(matrix, input);
            var result = ExtractResult(matrix);

            var backgroundColor = string.Empty;

            if (IsPalindrome(result))
            {
                backgroundColor = "4FE000";
            }
            else
            {
                backgroundColor = "E0000F";
            }

            Console.WriteLine($"<div style=\'background-color:#{backgroundColor}\'>{result}</div>");
        }

        private static bool IsPalindrome(string inputString)
        {
            inputString = new string(inputString.ToLower().Where(x => char.IsLetter(x)).ToArray());

            var reversed = new string(inputString.Reverse().ToArray());
            reversed = reversed.ToLower().Replace(" ", string.Empty);

            return inputString.Equals(reversed);
        }

        private static string ExtractResult(char[][] matrix)
        {
            var matrixDimension = matrix.Length;
            var togle = true;

            var white = new StringBuilder();
            var black = new StringBuilder();

            for (var rowIndex = 0; rowIndex < matrixDimension; rowIndex++)
            {
                for (var colIndex = 0; colIndex < matrixDimension; colIndex++)
                {
                    if (togle)
                    {
                        white.Append(matrix[rowIndex][colIndex]);
                        togle = false;
                    }
                    else
                    {
                        black.Append(matrix[rowIndex][colIndex]);
                        togle = true;
                    }
                }

                if (matrixDimension % 2 == 0)
                {
                    if (togle)
                    {
                        togle = false;
                    }
                    else
                    {
                        togle = true;
                    }
                }
            }

            return white.ToString() + black.ToString();
        }

        private static void FillMatrix(char[][] matrix, char[] input)
        {
            var matrixDimension = matrix.Length;

            var startIndex = 0;

            var indexOfInput = 0;

            while (startIndex < matrixDimension / 2.0)
            {
                for (var currentCol = startIndex; currentCol < matrixDimension - startIndex; currentCol++)
                {
                    if (indexOfInput < input.Length)
                    {
                        matrix[startIndex][currentCol] = input[indexOfInput++];
                    }
                }

                for (var currentRow = startIndex + 1; currentRow < matrixDimension - startIndex; currentRow++)
                {
                    if (indexOfInput < input.Length)
                    {
                        matrix[currentRow][matrixDimension - 1 - startIndex] = input[indexOfInput++];
                    }
                }

                for (var currentCol = matrixDimension - 2 - startIndex; currentCol >= startIndex; currentCol--)
                {
                    if (indexOfInput < input.Length)
                    {
                        matrix[matrixDimension - 1 - startIndex][currentCol] = input[indexOfInput++];
                    }
                }

                for (var currentRow = matrixDimension - 2 - startIndex; currentRow >= startIndex + 1; currentRow--)
                {
                    if (indexOfInput < input.Length)
                    {
                        matrix[currentRow][startIndex] = input[indexOfInput++];
                    }
                }

                //PrintMatrix(matrix);

                startIndex++;
            }
        }

        private static void PrintMatrix(char [][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }

        private static char[][] InitializeMatrix(int n)
        {
            var matrix = new char[n][];

            for (var rowIndex = 0; rowIndex < n; rowIndex++)
            {
                matrix[rowIndex] = new char[n];
            }

            for (var rowIndex = 0; rowIndex < n; rowIndex++)
            {
                for (var colIndex = 0; colIndex < n; colIndex++)
                {
                    matrix[rowIndex][colIndex] = ' ';
                }
            }

            return matrix;
        }
    }
}
