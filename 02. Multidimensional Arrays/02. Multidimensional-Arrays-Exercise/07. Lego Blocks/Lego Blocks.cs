namespace _07.Lego_Blocks
{
    using System;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var jaggedArrayA = ReadArrayFromConsole(n);
            var jaggedArrayB = ReadArrayFromConsole(n);

            jaggedArrayB = ReverseArray(jaggedArrayB);

            var combinedArray = CombineArrays(jaggedArrayA, jaggedArrayB);

            if (ArrayIsMatrix(combinedArray))
            {
                PrintArray(combinedArray);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {TotalNumberOfCellsInArray(combinedArray)}");
            }
        }

        private static int TotalNumberOfCellsInArray(int[][] array)
        {
            var rows = array.Length;
            var totalCells = 0;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                totalCells += array[rowIndex].Length;
            }

            return totalCells;
        }

        private static void PrintArray(int[][] array)
        {
            var rows = array.Length;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                Console.WriteLine($"[{string.Join(", ", array[rowIndex])}]");
            }
        }

        private static bool ArrayIsMatrix(int[][] array)
        {
            var rows = array.Length;
            var cols = array[0].Length;

            for (var rowindex = 1; rowindex < rows; rowindex++)
            {
                var currentCols = array[rowindex].Length;

                if (currentCols != cols)
                {
                    return false;
                }
            }

            return true;
        }

        private static int[][] CombineArrays(int[][] jaggedArrayA, int[][] jaggedArrayB)
        {
            var rows = jaggedArrayA.Length;

            var resultArray = new int[rows][];

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var x = jaggedArrayA[rowIndex].ToList();
                x.AddRange(jaggedArrayB[rowIndex]);
                resultArray[rowIndex] = x.ToArray();
            }

            return resultArray;
        }

        private static int[][] ReverseArray(int[][] inputArray)
        {
            var rows = inputArray.Length;

            var jaggedArray = new int[rows][];

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                jaggedArray[rowIndex] = inputArray[rowIndex].Reverse().ToArray();
            }

            return jaggedArray;
        }

        private static int[][] ReadArrayFromConsole(int rows)
        {
            var jaggedArray = new int[rows][];

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                jaggedArray[rowIndex] = Console.ReadLine()
                    .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return jaggedArray;
        }
    }
}
