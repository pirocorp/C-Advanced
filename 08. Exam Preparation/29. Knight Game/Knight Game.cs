namespace _29._Knight_Game
{
    using System;

    public class KnightGame
    {
        public static void Main()
        {
            var dimension = int.Parse(Console.ReadLine());

            var matrix = new char[dimension][];
            

            for (var rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine().ToCharArray();
            }

            var count = 0;

            while (TryFindMaxKnight(matrix, out var maxKnight))
            {
                RemoveElementFromMatrix(matrix, maxKnight);
                count++;
            }

            Console.WriteLine(count);
        }

        private static void RemoveElementFromMatrix(char[][] matrix, Element maxKnight)
        {
            matrix[maxKnight.Row][maxKnight.Col] = '0';
        }

        private static bool TryFindMaxKnight(char[][] matrix, out Element maxKnight)
        {
            var dimension = matrix.Length;

            maxKnight = new Element(-1, -1);
            var maxCount = 0;
            var max = false;

            for (var rowIndex = 0; rowIndex < dimension; rowIndex++)
            {
                for (var colIndex = 0; colIndex < dimension; colIndex++)
                {
                    var currentElement = matrix[rowIndex][colIndex];

                    if (currentElement == 'K')
                    {
                        var currentKnight = new Element(rowIndex, colIndex);
                        var currentCount = ReturnCountOfKnightsHit(currentKnight, matrix);

                        if (currentCount > maxCount)
                        {
                            max = true;
                            maxCount = currentCount;
                            maxKnight.Row = rowIndex;
                            maxKnight.Col = colIndex;
                        }
                    }
                }
            }

            return max;
        }

        private static int ReturnCountOfKnightsHit(Element knight, char[][] matrix)
        {
            var dimension = matrix.Length;
            var count = 0;

            if (knight.Col - 2 >= 0)
            {
                if (knight.Row + 1 < dimension)
                {
                    if (matrix[knight.Row + 1][knight.Col - 2] == 'K')
                    {
                        count++;
                    }
                }

                if (knight.Row - 1 >= 0)
                {
                    if (matrix[knight.Row - 1][knight.Col - 2] == 'K')
                    {
                        count++;
                    }
                }
            }

            if (knight.Col - 1 >= 0)
            {
                if (knight.Row + 2 < dimension)
                {
                    if (matrix[knight.Row + 2][knight.Col - 1] == 'K')
                    {
                        count++;
                    }
                }

                if (knight.Row - 2 >= 0)
                {
                    if (matrix[knight.Row - 2][knight.Col - 1] == 'K')
                    {
                        count++;
                    }
                }
            }

            if (knight.Col + 2 < dimension)
            {
                if (knight.Row + 1 < dimension)
                {
                    if (matrix[knight.Row + 1][knight.Col + 2] == 'K')
                    {
                        count++;
                    }
                }

                if (knight.Row - 1 >= 0)
                {
                    if (matrix[knight.Row - 1][knight.Col + 2] == 'K')
                    {
                        count++;
                    }
                }
            }

            if (knight.Col + 1 < dimension)
            {
                if (knight.Row + 2 < dimension)
                {
                    if (matrix[knight.Row + 2][knight.Col + 1] == 'K')
                    {
                        count++;
                    }
                }

                if (knight.Row - 2 >= 0)
                {
                    if (matrix[knight.Row - 2][knight.Col + 1] == 'K')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }

    public class Element
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Element(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
