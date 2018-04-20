namespace _0.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    public class Examples
    {
        public static void Main()
        {
            //InitializeAndPrintMatrix();

            //AnotherWayToInitializeMatrix();

            //HardCodeMatrix();

            //AnotherHardCode();

            //SpeedTest();

            //SpeedTest2();

        }

        private static void SpeedTest2()
        {
            var inputMaxNumber = long.Parse(Console.ReadLine());

            for (var i = 0L; i < inputMaxNumber; i++)
            {
                var startNumber = 1L;

                for (var j = 0L; j <= i; j++)
                {
                    Console.Write(startNumber);
                    Console.Write(" ");
                    startNumber = startNumber * (i - j) / (j + 1L);
                }

                Console.WriteLine();
            }
        }

        private static void SpeedTest()
        {
            int[] numbers = { 1, 4, 113, 55, 3, 1, 2, 66, 557, 124, 2 };

            var watch = new Stopwatch();

            watch.Start();

            var lenght = numbers.Length;

            var zero = new List<int>(lenght);
            var one = new List<int>(lenght);
            var two = new List<int>(lenght);

            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    zero.Add(numbers[i]);
                }
                else if (numbers[i] % 3 == 1)
                {
                    one.Add(numbers[i]);
                }
                else
                {
                    two.Add(numbers[i]);
                }
            }

            for (var i = 0; i < zero.Count; i++)
            {
                Console.Write(zero[i] + " ");
            }

            Console.WriteLine();

            for (var i = 0; i < one.Count; i++)
            {
                Console.Write(one[i] + " ");
            }

            Console.WriteLine();

            for (var i = 0; i < two.Count; i++)
            {
                Console.Write(two[i] + " ");
            }

            Console.WriteLine();

            watch.Stop();

            Console.WriteLine(watch.ElapsedTicks);
            Console.WriteLine(watch.Elapsed);
        }

        private static void AnotherHardCode()
        {
            int[][] matrix =
            {
                new []{1, 2, 3, 4}, // row 0 values
                new []{5, 6, 7, 8}  // row 1 values
            };

            for (var row = 0; row < matrix.Length; row++)
            {
                var currentRow = matrix[row];
                var strings = currentRow.ToList().ConvertAll(input => $"{input:D3}").ToArray();

                Console.WriteLine(string.Join(", ", strings));
            }
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
