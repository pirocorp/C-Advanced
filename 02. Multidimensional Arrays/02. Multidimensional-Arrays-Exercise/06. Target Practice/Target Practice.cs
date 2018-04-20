namespace _06.Target_Practice
{
    using System;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var row = dimensions[0];
            var col = dimensions[1];

            var snakeString = Console.ReadLine();

            var shotParameters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = InitializeMatrix(row, col, snakeString);

            //PrintMatrix(matrix);

            ProcessShot(matrix, shotParameters);

            //PrintMatrix(matrix);

            FallDownCharacters(matrix);

            PrintMatrix(matrix);
        }

        private static void FallDownCharacters(char[][] matrix)
        {
            for (var rowIndex = matrix.Length - 2; rowIndex >= 0; rowIndex--)
            {
                for (var colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    var currentChar = matrix[rowIndex][colIndex];

                    if (currentChar != ' ')
                    {
                        var currentRow = rowIndex + 1;

                        while (currentRow < matrix.Length && matrix[currentRow][colIndex] == ' ')
                        {
                            matrix[currentRow][colIndex] = currentChar;
                            matrix[currentRow - 1][colIndex] = ' ';

                            currentRow++;
                        }
                    }
                }
            }
        }

        private static void ProcessShot(char[][] matrix, int[] shotParameters)
        {
            var rowOfShot = shotParameters[0];
            var colOfShot = shotParameters[1];
            var shotRadius = shotParameters[2];

            matrix[rowOfShot][colOfShot] = ' ';

            //Calculate radius

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if ((row - rowOfShot) * (row - rowOfShot) + (col - colOfShot) * (col - colOfShot) <= shotRadius * shotRadius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static char[][] InitializeMatrix(int row, int col, string inputString)
        {
            var matrix = new char[row][];
            var initializer = 0;
            var flag = false;

            for (var rowIndex = row - 1; rowIndex >= 0; rowIndex--)
            {
                matrix[rowIndex] = new char[col];

                if (flag)
                {
                    for (var colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        matrix[rowIndex][colIndex] = inputString[initializer % inputString.Length];
                        initializer++;
                    }

                    flag = false;
                    continue;
                }

                for (var colIndex = matrix[rowIndex].Length - 1; colIndex >= 0; colIndex--)
                {
                    matrix[rowIndex][colIndex] = inputString[initializer % inputString.Length];
                    initializer++;
                    
                }

                flag = true;
            }

            return matrix;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }

            //Console.WriteLine();
        }
    }
}
