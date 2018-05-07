using System.Security;

namespace _15._Clearing_Commands
{
    using System;
    using System.Collections.Generic;

    public class ClearingCommands
    {
        public static void Main(string[] args)
        {
            var matrix = ReadMetrix();

            for (var rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                for (var colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    ProcessMatrix(matrix, rowIndex, colIndex);
                }
            }

            foreach (var line in matrix)
            {
                Console.WriteLine($"<p>{SecurityElement.Escape(new string(line))}</p>");
            }
        }

        private static void ProcessMatrix(List<char[]> matrix, int currentElementRow, int currentElementCol)
        {
            var currentElement = matrix[currentElementRow][currentElementCol];

            var rows = matrix.Count;
            var cols = matrix[0].Length;

            switch (currentElement)
            {
                case '^':
                    currentElementRow--;

                    while (currentElementRow >= 0)
                    {
                        var element = matrix[currentElementRow][currentElementCol];

                        if (element != '^' && element != '>' && element != '<' && element != 'v')
                        {
                            matrix[currentElementRow][currentElementCol] = ' ';
                        }
                        else
                        {
                            break;
                        }

                        currentElementRow--;
                    }

                    break;
                case '>':
                    var maxCols = matrix[currentElementRow].Length;
                    currentElementCol++;

                    while (currentElementCol < maxCols)
                    {
                        var element = matrix[currentElementRow][currentElementCol];

                        if (element != '^' && element != '>' && element != '<' && element != 'v')
                        {
                            matrix[currentElementRow][currentElementCol] = ' ';
                        }
                        else
                        {
                            break;
                        }
                        

                        currentElementCol++;
                    }

                    break;
                case '<':
                    currentElementCol--;

                    while (currentElementCol >= 0)
                    {
                        var element = matrix[currentElementRow][currentElementCol];

                        if (element != '^' && element != '>' && element != '<' && element != 'v')
                        {
                            matrix[currentElementRow][currentElementCol] = ' ';
                        }
                        else
                        {
                            break;
                        }

                        currentElementCol--;
                    }

                    break;
                case 'v':
                    var maxRow = matrix.Count;
                    currentElementRow++;

                    while (currentElementRow < maxRow)
                    {
                        var element = matrix[currentElementRow][currentElementCol];

                        if (element != '^' && element != '>' && element != '<' && element != 'v')
                        {
                            matrix[currentElementRow][currentElementCol] = ' ';
                        }
                        else
                        {
                            break;
                        }

                        currentElementRow++;
                    }

                    break;
                default:
                    return;
            }
        }

        private static List<char[]> ReadMetrix()
        {
            var matrix = new List<char[]>();

            var inputLine = Console.ReadLine().Trim();

            while (inputLine != "END")
            {
                var currentLine = inputLine.ToCharArray();
                matrix.Add(currentLine);
                inputLine = Console.ReadLine();
            }

            return matrix;
        }
    }
}
