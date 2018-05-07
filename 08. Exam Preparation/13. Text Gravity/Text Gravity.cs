namespace _13._Text_Gravity
{
    using System;
    using System.Linq;
    using System.Security;

    public class TextGravity
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var inputString = Console.ReadLine().ToCharArray();

            var matrix = ReadInputIntoMatrix(inputString, n);

            for (var rowIndex = matrix.Length - 2; rowIndex >= 0; rowIndex--)
            {
                for (var colIndex = n - 1; colIndex >= 0; colIndex--)
                {
                    var currentElement = new Element(rowIndex, colIndex);

                    TryToMoveElementDownInMatrix(matrix, currentElement);
                }
            }

            Console.Write($"<table>");

            foreach (var line in matrix)
            {
                Console.Write($"<tr>");

                foreach (var character in line)
                {
                    Console.Write($"<td>{SecurityElement.Escape(character.ToString())}</td>");
                }

                Console.Write($"</tr>");
            }

            Console.WriteLine($"</table>");
        }

        private static void TryToMoveElementDownInMatrix(char[][] matrix, Element currentElement)
        {
            var elementRow = currentElement.Row;
            var elementCol = currentElement.Col;

            var nextRowIndex = elementRow + 1;
            var nextRow = nextRowIndex < matrix.Length;

            if (nextRow)
            {
                var charOnNextRow = matrix[nextRowIndex][elementCol];
                var destinationRowIndex = -1;

                while (nextRow && charOnNextRow == ' ')
                {
                    destinationRowIndex = nextRowIndex;
                    nextRowIndex++;
                    nextRow = nextRowIndex < matrix.Length;

                    if (nextRow)
                    {
                        charOnNextRow = matrix[nextRowIndex][elementCol];
                    }
                }

                if (destinationRowIndex > 0)
                {
                    matrix[destinationRowIndex][elementCol] = matrix[elementRow][elementCol];
                    matrix[elementRow][elementCol] = ' ';
                }
            }
        }

        private static char[][] ReadInputIntoMatrix(char[] inputString, int n)
        {
            var resultLines = (int) Math.Ceiling(inputString.Length /(double) n);
            var resultMatrix = new char [resultLines][];

            var currentIndex = 0;

            while (inputString.Length > 0)
            {
                var currentLine = inputString.Take(n).ToArray();

                if (currentLine.Length < n)
                {
                    var newCurrentLine = new char[n];

                    var i = 0;

                    for (; i < currentLine.Length; i++)
                    {
                        newCurrentLine[i] = currentLine[i];
                    }

                    for (; i < newCurrentLine.Length; i++)
                    {
                        newCurrentLine[i] = ' ';
                    }

                    currentLine = newCurrentLine;
                }

                resultMatrix[currentIndex] = currentLine;
                currentIndex++;
                inputString = inputString.Skip(n).ToArray();
            }

            return resultMatrix;
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
