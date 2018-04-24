namespace _08.Radioactive_Bunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RadioactiveBunnies
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var lairLevel = ReadLevelFromConsole(rows);

            var inputCommandsString = Console.ReadLine().ToCharArray();

            var playerCordinates = FindPlayerCordinates(lairLevel);


            for (var i = 0; i < inputCommandsString.Length; i++)
            {
                var currentCommand = inputCommandsString[i];

                var lastPlayerX = playerCordinates[0];
                var lastPlayerY = playerCordinates[1];

                var stateOfPlayer = ProcessCommand(currentCommand, playerCordinates, lairLevel);

                if (stateOfPlayer == "WIN")
                {
                    PrintLevel(lairLevel);
                    Console.WriteLine($"won: {lastPlayerX} {lastPlayerY}");
                    return;
                }

                if (stateOfPlayer == "DEAD")
                {
                    PrintLevel(lairLevel);
                    Console.WriteLine($"dead: {playerCordinates[0]} {playerCordinates[1]}");
                    return;
                }

                //Console.WriteLine();
                //PrintLevel(lairLevel);
            }
        }

        private static string ProcessCommand(char currentCommand, int[] playerCordinates, char[][] lairLevel)
        {
            var stateOfPlayer = "";

            switch (currentCommand)
            {
                case 'U':
                    RemovePlayerFromCurrentPosition(playerCordinates, lairLevel);
                    playerCordinates[0]--;
                    stateOfPlayer = MovePlayerToNewPosition(playerCordinates, lairLevel);
                    break;
                case 'D':
                    RemovePlayerFromCurrentPosition(playerCordinates, lairLevel);
                    playerCordinates[0]++;
                    stateOfPlayer = MovePlayerToNewPosition(playerCordinates, lairLevel);
                    break;
                case 'L':
                    RemovePlayerFromCurrentPosition(playerCordinates, lairLevel);
                    playerCordinates[1]--;
                    stateOfPlayer = MovePlayerToNewPosition(playerCordinates, lairLevel);
                    break;
                case 'R':
                    RemovePlayerFromCurrentPosition(playerCordinates, lairLevel);
                    playerCordinates[1]++;
                    stateOfPlayer = MovePlayerToNewPosition(playerCordinates, lairLevel);
                    break;
            }

            MultiplyBunnys(lairLevel, ref stateOfPlayer);

            return stateOfPlayer;
        }

        private static void MultiplyBunnys(char[][] lairLevel, ref string stateOfPlayer)
        {
            var cordinatesOfCurrentBunnys = new List<KeyValuePair<int, int>>();

            var rows = lairLevel.Length;
            var cols = lairLevel[0].Length;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (var colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (lairLevel[rowIndex][colIndex] == 'B')
                    {
                        cordinatesOfCurrentBunnys.Add(new KeyValuePair<int, int>(rowIndex, colIndex));
                    }
                }
            }

            for (var i = 0; i < cordinatesOfCurrentBunnys.Count; i++)
            {
                var currentCordinates = cordinatesOfCurrentBunnys[i];

                var rowIndex = currentCordinates.Key;
                var colIndex = currentCordinates.Value;

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

        private static void RemovePlayerFromCurrentPosition(int[] playerCordinates, char[][] lairLevel)
        {
            lairLevel[playerCordinates[0]][playerCordinates[1]] = '.';
        }

        private static string MovePlayerToNewPosition(int[] playerCordinates, char[][] lairLevel)
        {
            var stateOfPlayer = string.Empty;

            if (lairLevel.Length <= playerCordinates[0] || lairLevel[0].Length <= playerCordinates[1])
            {
                return stateOfPlayer = "WIN";
            }

            if (playerCordinates[0] < 0 || playerCordinates[1] < 0)
            {
                return stateOfPlayer = "WIN";
            }

            if (lairLevel[playerCordinates[0]][playerCordinates[1]] == 'B')
            {
                stateOfPlayer = "DEAD";
            }
            else
            {
                lairLevel[playerCordinates[0]][playerCordinates[1]] = 'P';
            }

            return stateOfPlayer;
        }

        private static int[] FindPlayerCordinates(char[][] lairLevel)
        {
            var playerCordinates = new int[2];

            var rows = lairLevel.Length;

            for (var rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var cols = lairLevel[rowIndex].Length;

                for (var colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (lairLevel[rowIndex][colIndex] == 'P')
                    {
                        playerCordinates[0] = rowIndex;
                        playerCordinates[1] = colIndex;

                        return playerCordinates;
                    }
                }
            }

            return playerCordinates;
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
