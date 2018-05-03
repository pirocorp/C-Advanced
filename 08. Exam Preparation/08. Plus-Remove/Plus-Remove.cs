namespace _08._Plus_Remove
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlusRemove
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

            var nextRowLength = jaggedCharList[elementRow + 1].Length;
            var rowAfterNextLenth = jaggedCharList[elementRow + 2].Length;

            var rows = elementRow + 2 < jaggedCharList.Count;
            var nextRow = elementCol - 1 >= 0 && elementCol + 1 < nextRowLength;
            var rowAfterNext = elementCol < rowAfterNextLenth;

            if (rows && nextRow && rowAfterNext)
            {
                var currentChar = char.ToLower(jaggedCharList[elementRow][elementCol]);
                var nextRowFirstChar = char.ToLower(jaggedCharList[elementRow + 1][elementCol - 1]);
                var nextRowMiddleChar = char.ToLower(jaggedCharList[elementRow + 1][elementCol]);
                var nextRowLastChar = char.ToLower(jaggedCharList[elementRow + 1][elementCol + 1]);
                var rowAfterNextRowChar = char.ToLower(jaggedCharList[elementRow + 2][elementCol]);

                if (currentChar == nextRowFirstChar &&
                    currentChar == nextRowMiddleChar &&
                    currentChar == nextRowLastChar &&
                    currentChar == rowAfterNextRowChar)
                {

                    var currentElement = new Element(elementRow, elementCol);
                    var nextRowFirstElement = new Element(elementRow + 1, elementCol - 1);
                    var nextRowMiddleElement = new Element(elementRow + 1, elementCol);
                    var nextRowLastElement = new Element(elementRow + 1, elementCol + 1);
                    var rowAfterNextElement = new Element(elementRow + 2, elementCol);

                    elementsForRemoval.Add(currentElement);
                    elementsForRemoval.Add(nextRowFirstElement);
                    elementsForRemoval.Add(nextRowMiddleElement);
                    elementsForRemoval.Add(nextRowLastElement);
                    elementsForRemoval.Add(rowAfterNextElement);
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
