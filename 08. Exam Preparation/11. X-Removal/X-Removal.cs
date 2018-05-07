namespace _11._X_Removal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class XRemoval
    {
        static List<char[]> jaggedCharList = new List<char[]>();
        static List<Element> elementsForRemoval = new List<Element>();

        public static void Main()
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                jaggedCharList.Add(input.ToCharArray());
                input = Console.ReadLine();
            }

            for (var rowIndex = 0; rowIndex < jaggedCharList.Count - 2; rowIndex++)
            {
                var currentRow = jaggedCharList[rowIndex];

                for (var colIndex = 0; colIndex < currentRow.Length; colIndex++)
                {
                    var anchorElement = new Element(rowIndex, colIndex);

                    MarkElementsForRemoval(anchorElement);
                }
            }

            foreach (var element in elementsForRemoval)
            {
                var elementRow = element.Row;
                var elementCol = element.Col;

                jaggedCharList[elementRow][elementCol] = ' ';
            }

            foreach (var row in jaggedCharList)
            {
                Console.WriteLine(new string(row.Where(x => x != ' ').ToArray()));
            }
        }

        private static void MarkElementsForRemoval(Element anchorElement)
        {
            var elementRow = anchorElement.Row;
            var elementCol = anchorElement.Col;

            var currentRowLenght = jaggedCharList[elementRow].Length;
            var nextRowLength = jaggedCharList[elementRow + 1].Length;
            var rowAfterNextLenth = jaggedCharList[elementRow + 2].Length;

            var rows = elementRow + 2 < jaggedCharList.Count;
            var currentRow = elementCol + 2 < currentRowLenght;
            var nextRow = elementCol + 1 < nextRowLength;
            var rowAfterNext = elementCol + 2 < rowAfterNextLenth;

            if (rows && currentRow && nextRow && rowAfterNext)
            {
                var currentChar = char.ToLower(jaggedCharList[elementRow][elementCol]);
                var currentRowNextChar = char.ToLower(jaggedCharList[elementRow][elementCol + 2]);
                var nextRowChar = char.ToLower(jaggedCharList[elementRow + 1][elementCol + 1]);
                var rowAfterNextRowFirstChar = char.ToLower(jaggedCharList[elementRow + 2][elementCol]);
                var rowAfterNextRowSecondChar = char.ToLower(jaggedCharList[elementRow + 2][elementCol + 2]);

                if (currentChar == currentRowNextChar &&
                    currentChar == nextRowChar &&
                    currentChar == rowAfterNextRowFirstChar &&
                    currentChar == rowAfterNextRowSecondChar)
                {

                    var currentElement = new Element(elementRow, elementCol);
                    var currentRowNextElement = new Element(elementRow, elementCol + 2);
                    var nextRowElement = new Element(elementRow + 1, elementCol + 1);
                    var rowAfterNextRowFirstElement = new Element(elementRow + 2, elementCol);
                    var rowAfterNextRowSecondElement = new Element(elementRow + 2, elementCol + 2);

                    elementsForRemoval.Add(currentElement);
                    elementsForRemoval.Add(currentRowNextElement);
                    elementsForRemoval.Add(nextRowElement);
                    elementsForRemoval.Add(rowAfterNextRowFirstElement);
                    elementsForRemoval.Add(rowAfterNextRowSecondElement);
                }
            }
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
