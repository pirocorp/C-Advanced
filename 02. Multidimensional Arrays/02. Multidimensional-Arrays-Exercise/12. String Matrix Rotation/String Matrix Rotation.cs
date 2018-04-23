namespace _12.String_Matrix_Rotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            var listOfStrings = new List<string>();

            var rotations = Console.ReadLine()
                .Split(new []{ "Rotate(", ")" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Single();

            rotations /= 90;
            rotations %= 4;

            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                listOfStrings.Add(inputLine);
                inputLine = Console.ReadLine();
            }

            var jaggedArray = MakeJaggedArrayFromListOfStrings(listOfStrings);

            for (var i = 0; i < rotations; i++)
            {
                jaggedArray = RotateArray(jaggedArray);
            }

            PrintMatrix(jaggedArray);

        }

        private static char[][] RotateArray(char[][] arr)
        {
            var newRows = arr[0].Length;
            var newCols = arr.Length;

            var rotatedArray = new char[newRows][];

            for (var x = 0; x < newRows; x++)
            {
                rotatedArray[x] = arr.Select(p => p[x]).Reverse().ToArray();
            }

            return rotatedArray;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            var rows = matrix.Length;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                Console.WriteLine(string.Join("", matrix[rowIndex]));
            }
        }

        private static char[][] MakeJaggedArrayFromListOfStrings(List<string> listOfStrings)
        {
            var jaggedArray = new char[listOfStrings.Count][];
            var longestStringCount = listOfStrings.Max(m => m.Length);

            for (var rowIndex = 0; rowIndex < listOfStrings.Count; rowIndex++)
            {
                var padLenght = longestStringCount - listOfStrings[rowIndex].Length;
                var padString = new string(' ', padLenght);
                jaggedArray[rowIndex] = listOfStrings[rowIndex].ToCharArray().Concat(padString.ToCharArray()).ToArray();
            }

            return jaggedArray;
        }
    }
}
