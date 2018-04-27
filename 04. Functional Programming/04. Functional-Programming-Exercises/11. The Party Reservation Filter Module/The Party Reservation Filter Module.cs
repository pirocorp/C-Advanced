namespace _11._The_Party_Reservation_Filter_Module
{
    using System.Linq;
    using System;
    using System.Collections.Generic;

    public class ThePartyReservationFilterModule
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var listOfCommands = ReadListOfCommands();

            var predicates = GeneratePredicates(listOfCommands);

            var result = names.Where(x => predicates.All(p => !p(x)));

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<string> ReadListOfCommands()
        {
            var listOfCommands = new List<string>();

            var command = Console.ReadLine();

            while (command != "Print")
            {
                ProccessCommand(listOfCommands, command);

                command = Console.ReadLine();
            }

            return listOfCommands;
        }

        private static List<Predicate<string>> GeneratePredicates(List<string> listOfCommands)
        {
            var listOfPredicates = new List<Predicate<string>>();

            foreach (var command in listOfCommands)
            {
                var tokens = command.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);

                //var commandToListOfPredicates = tokens[0];
                var filterType = tokens[1];
                var filterParameter = tokens[2];

                var filter = GenerateFilter(filterType, filterParameter);
                listOfPredicates.Add(filter);
            }

            return listOfPredicates;
        }

        private static void ProccessCommand(List<string> listOfCommands, string command)
        {
            if (command.Contains("Add filter"))
            {
                listOfCommands.Add(command);
            }
                
            else if (command.Contains("Remove filter"))
            {
                var item = command
                    .Split(new []{ "Remove filter" }, StringSplitOptions.RemoveEmptyEntries)
                    .Single();

                var index = listOfCommands.FindIndex(x => x.Contains(item));

                listOfCommands.RemoveAt(index);
            }
        }

        private static Predicate<string> GenerateFilter(string filterType, string filterParameter)
        {
            switch (filterType)
            {
                case "Starts with":
                    return x => x.StartsWith(filterParameter);
                case "Ends with":
                    return x => x.EndsWith(filterParameter);
                case "Length":
                    return x => x.Length == int.Parse(filterParameter);
                case "Contains":
                    return x => x.Contains(filterParameter);
                default: return null;
            }
        }
    }
}
