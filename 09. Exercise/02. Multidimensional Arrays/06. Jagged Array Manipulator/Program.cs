namespace _06._Jagged_Array_Manipulator
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var jaggedArray = ReadJaggedArray();

            for (var i = 0; i < jaggedArray.Length - 1; i++)
            {
                var currentRow = jaggedArray[i];
                var nextRow = jaggedArray[i + 1];

                Func<double, double> func = currentRow.Length == nextRow.Length
                    ? func = x => x * 2
                    : func = x => x / 2;

                jaggedArray[i] = currentRow.Select(func).ToArray();
                jaggedArray[i + 1] = nextRow.Select(func).ToArray();
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var arguments = tokens.Skip(1).Select(int.Parse).ToArray();
                
                if (ValidateArguments(arguments, jaggedArray))
                {
                    var row = arguments[0];
                    var col = arguments[1];
                    var value = arguments[2];

                    switch (command)
                    {
                        case "Add":
                            jaggedArray[row][col] += value;
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value;
                            break;
                    }
                }
            }

            PrintJaggedArray(jaggedArray);
        }

        private static bool ValidateArguments(int[] arguments, double[][] jaggedArray)
        {
            var row = arguments[0];
            var col = arguments[1];

            if (row < 0 || col < 0)
            {
                return false;
            }

            if (row >= jaggedArray.Length)
            {
                return false;
            }

            if (col >= jaggedArray[row].Length)
            {
                return false;
            }

            return true;
        }

        private static double[][] ReadJaggedArray()
        {
            var jaggedSize = int.Parse(Console.ReadLine());
            var jaggedArray = new double[jaggedSize][];

            for (var i = 0; i < jaggedSize; i++)
            {
                jaggedArray[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            return jaggedArray;
        }

        private static void PrintJaggedArray(double[][] jaggedArray)
        {
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
