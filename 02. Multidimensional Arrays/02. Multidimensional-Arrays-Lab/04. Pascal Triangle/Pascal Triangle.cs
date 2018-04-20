namespace _04.Pascal_Triangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            var maxRows = long.Parse(Console.ReadLine());

            var pascaleTriangle = new long[maxRows][];

            for (var row = 0; row < maxRows; row++)
            {
                pascaleTriangle[row] = new long [row + 1];
                pascaleTriangle[row][0] = 1;
                pascaleTriangle[row][pascaleTriangle[row].Length - 1] = 1;

                for (var i = 1; i < pascaleTriangle[row].Length - 1; i++)
                {
                    pascaleTriangle[row][i] = pascaleTriangle[row - 1][i] + pascaleTriangle[row - 1][i - 1];
                }
            }

            foreach (var row in pascaleTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
