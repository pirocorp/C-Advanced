namespace _26._IT_Village
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ItVillage  
    {
        private const int Dimension = 4;

        private static int Coins = 50;
        private static int Storm = 0;
        private static List<Element> Inns = new List<Element>();
        private static char[][] matrix = null;
        private static Element playerOne = null;
        private static bool IsWon = false;
        private static bool IsLost = false;
        private static string result = string.Empty;
        private static int AllInns = 0;

        public static void Main()
        {
            matrix = InitializeMatrix(Dimension);
            AllInns = matrix.Sum(r => r.Where(x => x == 'I').Count());

            var startPositon = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Select(x => x - 1)
                .ToArray();

            playerOne = new Element(startPositon);

            var diceTrows = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var item in diceTrows)
            {
                if (Storm == 0)
                {
                    CalculateNewPosition(playerOne, item, Dimension);
                }

                if (Coins < 0)
                {
                    IsLost = true;
                    result = "<p>You lost! You ran out of money!<p>";
                    break;
                }

                if (AllInns == Inns.Count)
                {
                    IsWon = true;
                    result = $"<p>You won! You own the village now! You have {Coins} coins!<p>";
                    break;
                }

                if (!IsLost && !IsWon)
                {
                    if (Storm == 0)
                    {
                        Coins += 20 * Inns.Count;
                        ProccessNewPosition();
                    }
                    else
                    {
                        Storm--;
                    }
                }

                //PrintMatrixWithPointer(matrix, playerOne);
                //Console.WriteLine($"{matrix[playerOne.Row][playerOne.Col]}-{Coins}");
                //Console.WriteLine();
            }

            if (!IsLost && !IsWon)
            {
                result = $"<p>You lost! No more moves! You have {Coins} coins!<p>";
            }

            Console.WriteLine(result);
        }

        private static void ProccessNewPosition()
        {
            var currentPlayerRow = playerOne.Row;
            var currentPlayerCol = playerOne.Col;

            var currentField = matrix[currentPlayerRow][currentPlayerCol];

            switch (currentField)
            {
                case 'P':
                    Coins -= 5;
                    break;
                case 'I':
                    if (Inns.Any(x => x.Row == currentPlayerRow && x.Col == currentPlayerCol))
                    {
                        Coins -= 0;
                    }
                    else 
                    {
                        if (Coins >= 100)
                        {
                            Coins -= 100;
                            var currentInn = new Element(currentPlayerRow, currentPlayerCol);
                            Inns.Add(currentInn);
                        }
                        else
                        {
                            Coins -= 10;
                        }
                    }
                    break;
                case 'F':
                    Coins += 20;
                    break;
                case 'S':
                    Storm = 2;
                    break;
                case 'V':
                    Coins *= 10;
                    break;
                case 'N':
                    IsWon = true;
                    result = "<p>You won! Nakov's force was with you!<p>";
                    break;
            }

            if (Coins < 0)
            {
                IsLost = true;
                result = "<p>You lost! You ran out of money!<p>";
            }
        }

        private static void PrintMatrixWithPointer(char[][] matrix, Element player)
        {
            var pointerRow = player.Row;
            var pointerCol = player.Col;

            for (var rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                var currentRowLenght = matrix[rowIndex].Length;

                for (var colIndex = 0; colIndex < currentRowLenght; colIndex++)
                {
                    if (pointerRow == rowIndex && pointerCol == colIndex)
                    {
                        Console.Write($"| ");
                    }
                    else
                    {
                        Console.Write($"{matrix[rowIndex][colIndex]} ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void CalculateNewPosition(Element player, int n, int dimension)
        {
            var playerRow = player.Row;
            var playerCol = player.Col;

            while (n > 0)
            {
                if (playerRow == 0 && playerCol < dimension - 1)
                {
                    if (playerCol + n < dimension)
                    {
                        playerCol += n;
                        n = 0;
                        player.Row = playerRow;
                        player.Col = playerCol;
                        return;
                    }
                    else
                    {
                        var offset = dimension - 1 - playerCol;
                        playerCol = dimension - 1;
                        n -= offset;
                    }
                }
                else if (playerCol == dimension - 1 && playerRow < dimension - 1)
                {
                    if (playerRow + n < dimension)
                    {
                        playerRow += n;
                        n = 0;
                        player.Row = playerRow;
                        player.Col = playerCol;
                        return;
                    }
                    else
                    {
                        var offset = dimension - 1 - playerRow;
                        playerRow = dimension - 1;
                        n -= offset;
                    }
                }
                else if (playerRow == dimension - 1 && playerCol > 0)
                {
                    if (playerCol - n >= 0)
                    {
                        playerCol -= n;
                        n = 0;
                        player.Row = playerRow;
                        player.Col = playerCol;
                        return;
                    }
                    else
                    {
                        n -= playerCol;
                        playerCol = 0;
                    }
                }
                else if (playerRow > 0 && playerCol == 0)
                {
                    if (playerRow - n >= 0)
                    {
                        playerRow -= n;
                        n = 0;
                        player.Row = playerRow;
                        player.Col = playerCol;
                        return;
                    }
                    else
                    {
                        n -= playerRow;
                        playerRow = 0;
                    }
                }

                player.Row = playerRow;
                player.Col = playerCol;
            }
        }

        private static char[][] InitializeMatrix(int dimension)
        {
            var matrix = new char[dimension][];

            var rows = Console.ReadLine()
                .Split(new[] {" | "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(row => row.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries))
                .Select(row => row.Select(col => col[0]).ToArray())
                .ToArray();

            for (var rowIndex = 0; rowIndex < dimension; rowIndex++)
            {
                matrix[rowIndex] = rows[rowIndex];
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

        public Element(int[] position)
        {
            Row = position[0];
            Col = position[1];
        }
    }
}
