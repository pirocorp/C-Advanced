namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var lairLevel = ReadLevelFromConsole(rows);

            var inputCommandsString = Console.ReadLine().ToCharArray();

            var playerCoordinates = FindPlayerCoordinates(lairLevel);


            for (var i = 0; i < inputCommandsString.Length; i++)
            {
                var currentCommand = inputCommandsString[i];

                var lastPlayerX = playerCoordinates[0];
                var lastPlayerY = playerCoordinates[1];

                var stateOfPlayer = ProcessCommand(currentCommand, playerCoordinates, lairLevel);

                if (stateOfPlayer == "WIN")
                {
                    PrintLevel(lairLevel);
                    Console.WriteLine($"won: {lastPlayerX} {lastPlayerY}");
                    return;
                }

                if (stateOfPlayer == "DEAD")
                {
                    PrintLevel(lairLevel);
                    Console.WriteLine($"dead: {playerCoordinates[0]} {playerCoordinates[1]}");
                    return;
                }

                //Console.WriteLine();
                //PrintLevel(lairLevel);
            }
        }

        private static string ProcessCommand(char currentCommand, int[] playerCoordinates, char[][] lairLevel)
        {
            var stateOfPlayer = "";

            switch (currentCommand)
            {
                case 'U':
                    RemovePlayerFromCurrentPosition(playerCoordinates, lairLevel);
                    playerCoordinates[0]--;
                    stateOfPlayer = MovePlayerToNewPosition(playerCoordinates, lairLevel);
                    break;
                case 'D':
                    RemovePlayerFromCurrentPosition(playerCoordinates, lairLevel);
                    playerCoordinates[0]++;
                    stateOfPlayer = MovePlayerToNewPosition(playerCoordinates, lairLevel);
                    break;
                case 'L':
                    RemovePlayerFromCurrentPosition(playerCoordinates, lairLevel);
                    playerCoordinates[1]--;
                    stateOfPlayer = MovePlayerToNewPosition(playerCoordinates, lairLevel);
                    break;
                case 'R':
                    RemovePlayerFromCurrentPosition(playerCoordinates, lairLevel);
                    playerCoordinates[1]++;
                    stateOfPlayer = MovePlayerToNewPosition(playerCoordinates, lairLevel);
                    break;
            }

            MultiplyBunnies(lairLevel, ref stateOfPlayer);

            return stateOfPlayer;
        }

        private static void MultiplyBunnies(char[][] lairLevel, ref string stateOfPlayer)
        {
            var coordinatesOfCurrentBunnies = new List<KeyValuePair<int, int>>();

            var rows = lairLevel.Length;
            var cols = lairLevel[0].Length;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (var colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (lairLevel[rowIndex][colIndex] == 'B')
                    {
                        coordinatesOfCurrentBunnies.Add(new KeyValuePair<int, int>(rowIndex, colIndex));
                    }
                }
            }

            for (var i = 0; i < coordinatesOfCurrentBunnies.Count; i++)
            {
                var currentCoordinates = coordinatesOfCurrentBunnies[i];

                var rowIndex = currentCoordinates.Key;
                var colIndex = currentCoordinates.Value;

                var maxLairColsIndex = lairLevel[0].Length - 1;
                var maxLairRowIndex = lairLevel.Length - 1;

                if (lairLevel[rowIndex][Math.Max(0, colIndex - 1)] == 'P' ||
                    lairLevel[rowIndex][Math.Min(maxLairColsIndex, colIndex + 1)] == 'P' ||
                    lairLevel[Math.Max(0, rowIndex - 1)][colIndex] == 'P' ||
                    lairLevel[Math.Min(maxLairRowIndex, rowIndex + 1)][colIndex] == 'P')
                {
                    stateOfPlayer = "DEAD";
                }

                lairLevel[rowIndex][Math.Max(0, colIndex - 1)] = 'B';
                lairLevel[rowIndex][Math.Min(maxLairColsIndex, colIndex + 1)] = 'B';
                lairLevel[Math.Max(0, rowIndex - 1)][colIndex] = 'B';
                lairLevel[Math.Min(maxLairRowIndex, rowIndex + 1)][colIndex] = 'B';
            }
        }

        private static void RemovePlayerFromCurrentPosition(int[] playerCoordinates, char[][] lairLevel)
        {
            lairLevel[playerCoordinates[0]][playerCoordinates[1]] = '.';
        }

        private static string MovePlayerToNewPosition(int[] playerCoordinates, char[][] lairLevel)
        {
            var stateOfPlayer = string.Empty;

            if (lairLevel.Length <= playerCoordinates[0] || lairLevel[0].Length <= playerCoordinates[1])
            {
                return stateOfPlayer = "WIN";
            }

            if (playerCoordinates[0] < 0 || playerCoordinates[1] < 0)
            {
                return stateOfPlayer = "WIN";
            }

            if (lairLevel[playerCoordinates[0]][playerCoordinates[1]] == 'B')
            {
                stateOfPlayer = "DEAD";
            }
            else
            {
                lairLevel[playerCoordinates[0]][playerCoordinates[1]] = 'P';
            }

            return stateOfPlayer;
        }

        private static int[] FindPlayerCoordinates(char[][] lairLevel)
        {
            var playerCoordinates = new int[2];

            var rows = lairLevel.Length;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var cols = lairLevel[rowIndex].Length;

                for (var colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (lairLevel[rowIndex][colIndex] == 'P')
                    {
                        playerCoordinates[0] = rowIndex;
                        playerCoordinates[1] = colIndex;

                        return playerCoordinates;
                    }
                }
            }

            return playerCoordinates;
        }

        private static void PrintLevel(char[][] level)
        {
            var rows = level.Length;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                Console.WriteLine(string.Join("", level[rowIndex]));
            }
        }

        private static char[][] ReadLevelFromConsole(int rows)
        {
            var level = new char[rows][];

            for (var indexRow = 0; indexRow < rows; indexRow++)
            {
                level[indexRow] = Console.ReadLine().ToCharArray();
            }

            return level;
        }
    }
}
