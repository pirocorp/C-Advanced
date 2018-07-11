namespace _40._Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sneaking
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var room = new char[n][];
            InitializeRoom(room);
            var sequenceOfDirections = new Queue<char>(Console.ReadLine().ToArray());

            var samCurrentPosition = FindSamone(room, 'S');
            var nikoCurrentPosition = FindSamone(room, 'N');

            while (sequenceOfDirections.Count > 0)
            {
                EnemiesMove(room);

                var samCurrentRow = samCurrentPosition.Key;
                var samCurrentCol = samCurrentPosition.Value;

                if (EnemiesFaceSam(room, samCurrentPosition))
                {
                    Console.WriteLine($"Sam died at {samCurrentRow}, {samCurrentCol}");
                    room[samCurrentRow][samCurrentCol] = 'X';
                    PrintMatrix(room);
                    return;
                }

                samCurrentPosition = MoveSam(room, samCurrentPosition, sequenceOfDirections.Dequeue());

                samCurrentRow = samCurrentPosition.Key;
                samCurrentCol = samCurrentPosition.Value;

                var nikoCurrentRow = nikoCurrentPosition.Key;
                var nikoCurrentCol = nikoCurrentPosition.Value;

                if (samCurrentRow == nikoCurrentRow)
                {
                    Console.WriteLine($"Nikoladze killed!");
                    room[nikoCurrentRow][nikoCurrentCol] = 'X';
                    PrintMatrix(room);
                    return;
                }

                //PrintMatrix(room);
            }
        }

        private static KeyValuePair<int, int> MoveSam(char[][] room, KeyValuePair<int, int> samCurrentPosition, char move)
        {
            var samCurrentRow = samCurrentPosition.Key;
            var samCurrentCol = samCurrentPosition.Value;

            switch (move)
            {
                case 'U':
                    room[samCurrentRow][samCurrentCol] = '.';
                    room[samCurrentRow - 1][samCurrentCol] = 'S';
                    return new KeyValuePair<int, int>(samCurrentRow - 1, samCurrentCol);
                case 'D':
                    room[samCurrentRow][samCurrentCol] = '.';
                    room[samCurrentRow + 1][samCurrentCol] = 'S';
                    return new KeyValuePair<int, int>(samCurrentRow + 1, samCurrentCol);
                case 'L':
                    room[samCurrentRow][samCurrentCol] = '.';
                    room[samCurrentRow][samCurrentCol - 1] = 'S';
                    return new KeyValuePair<int, int>(samCurrentRow, samCurrentCol - 1);
                case 'R':
                    room[samCurrentRow][samCurrentCol] = '.';
                    room[samCurrentRow][samCurrentCol + 1] = 'S';
                    return new KeyValuePair<int, int>(samCurrentRow, samCurrentCol + 1);
                default:
                    return samCurrentPosition;
            }
        }

        private static bool EnemiesFaceSam(char[][] room, KeyValuePair<int, int> samCurrentPosition)
        {
            var samCurrentRow = samCurrentPosition.Key;
            var samCurrentCol = samCurrentPosition.Value;

            for (var colIndex = 0; colIndex < room[samCurrentRow].Length; colIndex++)
            {
                var currentChar = room[samCurrentRow][colIndex];

                if (currentChar == 'b' && colIndex <= samCurrentCol)
                {
                    return true;
                }

                if (currentChar == 'd' && colIndex >= samCurrentCol)
                {
                    return true;
                }
            }

            return false;
        }

        private static KeyValuePair<int,int> FindSamone(char[][] room, char find)
        {
            for (var rowIndex = 0; rowIndex < room.Length; rowIndex++)
            {
                for (var colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
                {
                    var currentChar = room[rowIndex][colIndex];

                    if (currentChar == find)
                    {
                        return new KeyValuePair<int, int>(rowIndex, colIndex);
                    }
                }
            }

            return new KeyValuePair<int, int>(-1, -1);
        }

        private static void EnemiesMove(char[][] room)
        {
            for (var rowIndex = 0; rowIndex < room.Length; rowIndex++)
            {
                for (var colIndex = 0; colIndex < room[rowIndex].Length; colIndex++)
                {
                    var currentChar = room[rowIndex][colIndex];

                    if (currentChar == 'b')
                    {
                        var maxCol = room[rowIndex].Length - 1;

                        if (colIndex >= maxCol)
                        {
                            room[rowIndex][colIndex] = 'd';
                        }
                        else
                        {
                            room[rowIndex][colIndex] = '.';
                            room[rowIndex][colIndex + 1] = 'b';
                            colIndex++;
                        }
                    }

                    if (currentChar == 'd')
                    {
                        if (colIndex <= 0)
                        {
                            room[rowIndex][colIndex] = 'b';
                        }
                        else
                        {
                            room[rowIndex][colIndex] = '.';
                            room[rowIndex][colIndex - 1] = 'd';
                        }
                    }
                }
            } 
        }

        private static void PrintMatrix(char[][] room)
        {
            //Console.WriteLine();
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void InitializeRoom(char[][] room)
        {
            for (var rowIndex = 0; rowIndex < room.Length; rowIndex++)
            {
                var currentRow = Console.ReadLine().ToCharArray();
                room[rowIndex] = currentRow;
            }
        }
    }
}
