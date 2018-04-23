using System.Data;

namespace _11.Parking_System
{
    using System;
    using System.Linq;

    public class ParkingSystem
    {
        public static int rows;
        public static int cols;

        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rows = dimensions[0];
            cols = dimensions[1];

            var parkingLot = InitializeParkingLot(rows, cols);

            var inputLine = Console.ReadLine();

            while (inputLine != "stop")
            {
                var tokens = inputLine
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = tokens[0];

                var row = tokens[1];
                var col = tokens[2];

                var distance = CalculateDistance(parkingLot, entryRow, row, col);

                if (distance == -1)
                {
                    Console.WriteLine($"Row {row} full");
                }
                else
                {
                    Console.WriteLine(distance);
                }

                inputLine = Console.ReadLine();
            }
        }

        private static int CalculateDistance(bool[][] parkingLot, int entryRow, int destinationRow, int destinationCol)
        {
            var distance = Math.Abs(destinationRow - entryRow);

            if (parkingLot[destinationRow] == null)
            {
                parkingLot[destinationRow] = new bool[cols];
            }

            if (parkingLot[destinationRow][destinationCol])
            {
                destinationCol = FindClosestFreeSpot(destinationCol, parkingLot[destinationRow]);
            }

            if (destinationCol == -1)
            {
                return -1;
            }

            parkingLot[destinationRow][destinationCol] = true;

            return distance + (destinationCol + 1);
        }

        private static int FindClosestFreeSpot(int destinationCol, bool[] parkingSpaces)
        {
            if (parkingSpaces.Any(b => b == false))
            {
                var lenght = Math.Max(destinationCol, parkingSpaces.Length - destinationCol);

                for (var i = 1; i < lenght; i++)
                {
                    var lowerIndex = Math.Max(1, destinationCol - i);
                    var upperIndex = Math.Min(parkingSpaces.Length - 1, destinationCol + i);

                    if (parkingSpaces[lowerIndex] == false)
                    {
                        return lowerIndex;
                    }

                    if (parkingSpaces[upperIndex] == false)
                    {
                        return upperIndex;
                    }
                }
            }

            return -1;
        }

        private static bool[][] InitializeParkingLot(int rows, int cols)
        {
            var parkingLot = new bool[rows][];

            return parkingLot;
        }
    }
}
