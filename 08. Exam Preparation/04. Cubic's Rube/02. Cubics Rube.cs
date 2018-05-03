namespace _04._Cubic_s_Rube
{
    using System;
    using System.Linq;

    public class CubicRube
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var inputLine = Console.ReadLine();

            var cube = InitializeCube(n);
            var allCells = n * n * n;

            while (inputLine != "Analyze")
            {
                var tokens = inputLine
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var x = tokens[0];
                var y = tokens[1];
                var z = tokens[2];
                var value = tokens[3];

                if (x >= 0 && x < n &&
                    y >= 0 && y < n &&
                    z >= 0 && z < n && 
                    value != 0)
                {
                    cube[x][y][z] += value;
                    allCells--;
                }

                inputLine = Console.ReadLine();
            }

            var sumOfCells = SumOfCells(cube);

            Console.WriteLine(sumOfCells);
            Console.WriteLine(allCells);
        }

        private static long SumOfCells(int[][][] cube)
        {
            var result = 0L;

            foreach (var matrix in cube)
            {
                foreach (var row in matrix)
                {
                    result += row.Sum();
                }
            }

            return result;
        }

        private static int[][][] InitializeCube(int n)
        {
            var cube = new int[n][][];

            for (var matrixIndex = 0; matrixIndex < cube.Length; matrixIndex++)
            {
                cube[matrixIndex] = new int[n][];

                for (var rowIndex = 0; rowIndex < cube[matrixIndex].Length; rowIndex++)
                {
                    cube[matrixIndex][rowIndex] = new int[n];
                }
            }

            return cube;
        }
    }
}
