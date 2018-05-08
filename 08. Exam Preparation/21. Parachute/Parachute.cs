namespace _21._Parachute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Parachute
    {
        public static void Main()
        {
            var matrix = ReadMatrix();

            var player = FindPlayerCordinates(matrix);
            var destination = string.Empty;

            while (player.Row < matrix.Count - 1)
            {
                var currentPositionRow = player.Row;
                var currentPositionCol = player.Col;

                var nextRow = currentPositionRow + 1;
                var wind = CalculateWind(matrix, nextRow);
                var nextCol = currentPositionCol + wind;

                destination = matrix[nextRow][nextCol].ToString();
                player.Row = nextRow;
                player.Col = nextCol;

                if (destination != ">" && destination != "<" && destination != "-")
                {
                    break;
                }
            }

            switch (destination)
            {
                case "_":
                    Console.WriteLine($"Landed on the ground like a boss!");
                    break;
                case "~":
                    Console.WriteLine($"Drowned in the water like a cat!");
                    break;
                case "/":
                case "\\":
                case "|":
                    Console.WriteLine($"Got smacked on the rock like a dog!");
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{player.Row} {player.Col}");
        }

        private static int CalculateWind(List<string> matrix, int currentPositionRow)
        {
            var row = matrix[currentPositionRow];
            var windRightPower = row.Count(x => x == '>');
            var windLeftPower = row.Count(x => x == '<');

            return windRightPower - windLeftPower;
        }

        private static Element FindPlayerCordinates(List<string> matrix)
        {
            for (var rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                for (var colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    var currentElement = matrix[rowIndex][colIndex];

                    if (currentElement == 'o')
                    {
                        return new Element(rowIndex, colIndex);
                    }
                }
            }

            return null;
        }
            
        private static List<string> ReadMatrix()
        {
            var matrix = new List<string>();

            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                matrix.Add(inputLine);
                inputLine = Console.ReadLine();
            }

            return matrix;
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
