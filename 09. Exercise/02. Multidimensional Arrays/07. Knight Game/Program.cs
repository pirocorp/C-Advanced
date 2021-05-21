namespace _07._Knight_Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private static List<Knight> problemKnights = new List<Knight>();

        public static void Main()
        {
            var board = ReadBoard();
            var count = 0;

            FindProblemKnights(board);

            while (problemKnights.Any())
            {
                var knight = problemKnights
                    .OrderByDescending(x => x.Count)
                    .ThenBy(x => x.Row)
                    .ThenBy(x => x.Col)
                    .First();

                count++;
                board[knight.Row][knight.Col] = '0';
                FindProblemKnights(board);
            }

            Console.WriteLine(count);
        }

        private static void FindProblemKnights(char[][] board)
        {
            problemKnights = new List<Knight>();

            for (var rowIndex = 0; rowIndex < board.Length; rowIndex++)
            {
                var row = board[rowIndex];

                for (var colIndex = 0; colIndex < row.Length; colIndex++)
                {
                    if (board[rowIndex][colIndex] != 'K')
                    {
                        continue;
                    }

                    if (HitKnight(rowIndex, colIndex, board, out var count))
                    {
                        var knight = new Knight(rowIndex, colIndex, count);
                        problemKnights.Add(knight);
                    }
                }
            }
        }

        private static bool HitKnight(int rowIndex, int colIndex, char[][] board, out int count)
        {
            Func<int, int, Tuple<int, int>>[] targets =
            {
                (x, y) => new Tuple<int, int>(x + 1, y + 2),
                (x, y) => new Tuple<int, int>(x + 2, y + 1),

                (x, y) => new Tuple<int, int>(x + 1, y - 2),
                (x, y) => new Tuple<int, int>(x + 2, y - 1),

                (x, y) => new Tuple<int, int>(x - 1, y + 2),
                (x, y) => new Tuple<int, int>(x - 2, y + 1),

                (x, y) => new Tuple<int, int>(x - 1, y - 2),
                (x, y) => new Tuple<int, int>(x - 2, y - 1),
            };

            count = 0;

            foreach (var target in targets)
            {
                var (targetRow, targetCol) = target(rowIndex, colIndex);

                if (targetRow < 0 
                    || targetRow >= board.Length
                    || targetCol < 0
                    || targetCol >= board[targetRow].Length)
                {
                    continue;
                }

                if (board[targetRow][targetCol] == 'K')
                {
                    count++;
                }
            }

            return count != 0;
        }

        private static char[][] ReadBoard()
        {
            var n = int.Parse(Console.ReadLine());

            var board = new char[n][];

            for (var i = 0; i < n; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }

            return board;
        }

        private class Knight
        {
            public Knight(int row, int col, int count)
            {
                this.Row = row;
                this.Col = col;
                this.Count = count;
            }

            public int Row { get; set; }

            public int Col { get; set; }

            public int Count { get; set; }
        }
    }
}
