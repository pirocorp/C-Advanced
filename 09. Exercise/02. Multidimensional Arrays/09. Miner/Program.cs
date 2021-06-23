namespace _09._Miner
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());

            var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var field = ReadField(fieldSize);

            var totalCoals = field.SelectMany(x => x).Count(x => x == 'c');
            var collectedCoals = 0;

            var currentPosition = GetStartPosition(field);

            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up":
                        currentPosition.Row = Math.Max(0, currentPosition.Row - 1);
                        break;
                    case "down":
                        currentPosition.Row = Math.Min(fieldSize - 1, currentPosition.Row + 1);
                        break;
                    case "left":
                        currentPosition.Col = Math.Max(0, currentPosition.Col - 1);
                        break;
                    case "right":
                        currentPosition.Col = Math.Min(fieldSize - 1, currentPosition.Col + 1);
                        break;
                }

                if (field[currentPosition.Row][currentPosition.Col] == 'c')
                {
                    collectedCoals++;
                    field[currentPosition.Row][currentPosition.Col] = '*';
                }

                if (collectedCoals == totalCoals)
                {
                    Console.WriteLine($"You collected all coals! ({currentPosition.Row}, {currentPosition.Col})");
                    return;
                }

                if (field[currentPosition.Row][currentPosition.Col] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentPosition.Row}, {currentPosition.Col})");
                    return;
                }
            }

            Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({currentPosition.Row}, {currentPosition.Col})");
        }

        private static (int Row, int Col) GetStartPosition(char[][] field)
        {
            for (var i = 0; i < field.Length; i++)
            {
                for (var j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 's')
                    {
                        return (i, j);
                    }
                }
            }

            return (-1, -1);
        }

        private static char[][] ReadField(int fieldSize)
        {
            var field = new char[fieldSize][];

            for (var i = 0; i < fieldSize; i++)
            {
                field[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x[0])
                    .ToArray();
            }

            return field;
        }
    }
}
