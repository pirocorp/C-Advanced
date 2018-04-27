namespace _12._Inferno_III
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class InfernoIii
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var listOfCommands = CommandInput();

            var filters = GenerateFilters(listOfCommands);

            var result = numbers.Where(n => filters.All(f => !f(numbers, n)));

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<Func<List<int>, int, bool>> GenerateFilters(List<string> listOfCommands)
        {
            var filters = new List<Func<List<int>, int, bool>>();

            foreach (var command in listOfCommands)
            {
                var filter = GenerateFilter(command);
                filters.Add(filter);
            }

            return filters;
        }

        private static List<string> CommandInput()
        {
            var listOfCommands = new List<string>();

            var commandInput = Console.ReadLine();

            while (commandInput != "Forge")
            {
                if (commandInput.Contains("Exclude"))
                {
                    listOfCommands.Add(commandInput);
                }
                else if (commandInput.Contains("Reverse"))
                {
                    var item = commandInput
                        .Split(new[] {"Reverse"}, StringSplitOptions.RemoveEmptyEntries)
                        .Single();

                    var index = listOfCommands.FindIndex(x => x.Contains(item));

                    listOfCommands.RemoveAt(index);
                }

                commandInput = Console.ReadLine();
            }

            return listOfCommands;
        }

        private static Func<List<int>, int, bool> GenerateFilter(string commandInput)
        {
            var tokens = commandInput.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var command = tokens[0];
            var filterType = tokens[1];
            var filterParameter = int.Parse(tokens[2]);

            switch (filterType)
            {
                case "Sum Left":
                    Func<List<int>, int, bool> sumLeft = (numbers, x) =>
                    {
                        var index = numbers.IndexOf(x);

                        if (index == 0)
                        {
                            return filterParameter == x + 0;
                        }

                        return filterParameter == x + numbers[index - 1];
                    };
                    return sumLeft;
                case "Sum Right":
                    Func<List<int>, int, bool> sumRight = (numbers, x) =>
                    {
                        var index = numbers.IndexOf(x);

                        if (index >= numbers.Count - 1)
                        {
                            return filterParameter == x + 0;
                        }

                        return filterParameter == x + numbers[index + 1];
                    };
                    return sumRight;
                case "Sum Left Right":
                    Func<List<int>, int, bool> sumLeftRight = (numbers, x) =>
                    {
                        var index = numbers.IndexOf(x);

                        var leftElement = 0;
                        var rightElement = 0;

                        if (index > 0)
                        {
                            leftElement = numbers[index - 1];
                        }

                        if (index < numbers.Count - 1)
                        {
                            rightElement = numbers[index + 1];
                        }

                        return filterParameter == x + leftElement + rightElement;
                    };
                    return sumLeftRight;
                default:
                    return null;
            }
        }
    }
}
