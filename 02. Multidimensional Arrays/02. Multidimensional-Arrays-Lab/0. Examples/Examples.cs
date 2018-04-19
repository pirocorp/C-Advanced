namespace _0.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Examples
    {
        public static void Main()
        {
            //InitializeAndPrintMatrix();

            //AnotherWayToInitializeMatrix();

            //HardCodeMatrix();


        }

        private static void HardCodeMatrix()
        {
            int[,] matrix =
            {
                {1, 2, 3, 4}, // row 0 values
                {5, 6, 7, 8}  // row 1 values
            };

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]:D3} ");
                }

                Console.WriteLine();
            }
        }

        private static void AnotherWayToInitializeMatrix(int x = 5, int y = 5)
        {
            var matrix = new int[x][];

            var count = 0;

            for (var row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int [y];

                for (var col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = count++;
                }
            }

            for (var row = 0; row < matrix.Length; row++)
            {
                var currentRow = matrix[row];
                var strings = currentRow.ToList().ConvertAll(input => $"{input:D3}").ToArray();

                Console.WriteLine(string.Join(", ", strings));
            }
        }

        private static void InitializeAndPrintMatrix(int x = 5, int y = 5)
        {
            var matrix = new int[x, y];
            
            var count = 0;

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = count++;
                }
            }

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]:D3} ");
                }

                Console.WriteLine();
            }
        }
    }
}
