namespace _10._Predicate_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var command = Console.ReadLine();

            while (command != "Party!")
            {
                var tokens = command.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                var functionType = tokens[0];
                var criteria = tokens[1];
                var argument = tokens[2];

                var filter = GetFilter(criteria, argument);
                var function = GetFunction(functionType, filter);

                names = function(names).ToArray();

                command = Console.ReadLine();
            }

            if (names.Length > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }

        private static Func<IEnumerable<string>, IEnumerable<string>> GetFunction(string functionType, Predicate<string> filter)
        {
            switch (functionType)
            {
                case "Remove":
                    return x => x.Where(p => !filter(p));
                case "Double":
                    return x =>
                    {
                        var result = new List<string>();

                        foreach (var str in x)
                        {
                            if (filter(str))
                            {
                                result.Add(str);
                            }

                            result.Add(str);
                        }

                        return result;
                    };
                default: return null;
            } 
        }

        private static Predicate<string> GetFilter(string criteria, string argument)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return x => x.StartsWith(argument);
                case "EndsWith":
                    return x => x.EndsWith(argument);
                case "Length":
                    return x => x.Length == int.Parse(argument);
                default:
                    return null;
            }
        }
    }
}
