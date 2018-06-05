namespace _32._Dangerous_Floor
{
    using System;
    using System.Linq;

    public class DangerousFloor
    {
        public static int Dimension = 8;
        public static char[][] Matrix;

        public static void Main()
        {
            Matrix = ReadMatrixFromConsole();

            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                ProcessMove(inputLine);
                PrintMatrix(Matrix);
                inputLine = Console.ReadLine();
            }
        }

        private static void ProcessMove(string inputLine)
        {
            var typeOfPice = inputLine[0];
            var tokens = inputLine.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            var startPosition = new Element(tokens[0]
                .Substring(1)
                .ToCharArray()
                .Select(x => int.Parse(new string(x, 1)))
                .ToArray());

            var endPosition = new Element(tokens[1]
                .ToCharArray()
                .Select(x => int.Parse(new string(x, 1)))
                .ToArray());

            var piceOnStartPosition = Matrix[startPosition.Row][startPosition.Col];

            if (typeOfPice != piceOnStartPosition)
            {
                Console.WriteLine($"There is no such a piece!");
                return;
            }

            if (!ValidMove(startPosition, endPosition, typeOfPice))
            {
                Console.WriteLine($"Invalid move!");
                return;
            }

            if (endPosition.Row >= Dimension || endPosition.Col >= Dimension)
            {
                Console.WriteLine($"Move go out of board!");
                return;
            }

            Matrix[startPosition.Row][startPosition.Col] = 'x';
            Matrix[endPosition.Row][endPosition.Col] = typeOfPice;
        }

        private static bool ValidMove(Element startPosition, Element endPosition, char typeOfPice)
        {
            switch (typeOfPice)
            {
                case 'K':
                    return KingValidMove(startPosition, endPosition);
                case 'R':
                    return RookValidMove(startPosition, endPosition);
                case 'B':
                    return BishopValidMove(startPosition, endPosition);
                case 'Q':
                    return QueenValidMove(startPosition, endPosition);
                case 'P':
                    return PawnValidMove(startPosition, endPosition);
            }

            return false;
        }

        private static bool PawnValidMove(Element startPosition, Element endPosition)
        {
            var startX = startPosition.Row;
            var startY = startPosition.Col;

            var endX = endPosition.Row;
            var endY = endPosition.Col;

            if (endX == startX - 1 && startY == endY)
            {
                return true;
            }

            return false;
        }

        private static bool QueenValidMove(Element startPosition, Element endPosition)
        {
            if (BishopValidMove(startPosition, endPosition) || RookValidMove(startPosition, endPosition))
            {
                return true;
            }

            return false;
        }

        private static bool BishopValidMove(Element startPosition, Element endPosition)
        {
            var startX = startPosition.Row;
            var startY = startPosition.Col;

            var endX = endPosition.Row;
            var endY = endPosition.Col;

            var n = Math.Abs(startX - endX);

            var leftUp = endX == startX - n && endY == startY - n;
            var rightUp = endX == startX - n && endY == startY + n;
            var leftDown = endX == startX + n && endY == startY - n;
            var rightDown = endX == startX + n && endY == startY + n;

            if (n > 0 && (leftUp || rightUp || leftDown || rightDown))
            {
                return true;
            }

            return false;
        }

        private static bool RookValidMove(Element startPosition, Element endPosition)
        {
            var startX = startPosition.Row;
            var startY = startPosition.Col;

            var endX = endPosition.Row;
            var endY = endPosition.Col;

            var sameRow = startX == endX && startY != endY;
            var sameCol = startY == endY && startX != endX;

            if (sameRow || sameCol)
            {
                return true;
            }

            return false;
        }

        private static bool KingValidMove(Element startPosition, Element endPosition)
        {
            var startX = startPosition.Row;
            var startY = startPosition.Col;

            var endX = endPosition.Row;
            var endY = endPosition.Col;

            var firstLine = endX == startX - 1 && (startY == endY - 1 || startY == endY || startY == endY + 1);
            var secondLine = endX == startX && (startY == endY - 1 || startY == endY + 1);
            var lastLine = endX == startX + 1 && (startY == endY - 1 || startY == endY || startY == endY + 1);

            if (firstLine || secondLine || lastLine)
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            Console.WriteLine();

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(",", row));
            }
        }

        private static char[][] ReadMatrixFromConsole()
        {
            var matrix = new char[Dimension][];

            for (var rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x[0])
                    .ToArray();
            }

            return matrix;
        }
    }

    public class Element
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Element(int[] tokens)
        {
            Row = tokens[0];
            Col = tokens[1];
        }

        public Element(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
