namespace _37._Ticket_Trouble
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class TicketTrouble
    {
        public static void Main()
        {
            var location = Console.ReadLine();
            var inputLine = Console.ReadLine();

            const string pattern = "({|\\[)[A-Z][0-9]{1,2}(}|\\])";
            var regex = new Regex(pattern, RegexOptions.Compiled);

            var validTickets = ValidTickets(inputLine, location);

            var matches = new List<string>();

            foreach (var ticket in validTickets)
            {
                var match = regex.Match(ticket).Value;

                if (match.Length > 0)
                {
                    matches.Add(match.Substring(1, match.Length - 2));
                }
            }

            if (matches.Count > 2)
            {
                for (var i = 0; i < matches.Count; i++)
                {
                    var currentMatch = matches[i];
                    var currentSeatNumber = int.Parse(currentMatch.Substring(1, currentMatch.Length - 1));

                    for (var j = i + 1; j < matches.Count; j++)
                    {
                        var checkedMatch = matches[j];
                        var checkedSeatNumber = int.Parse(checkedMatch.Substring(1, checkedMatch.Length - 1));

                        if (currentSeatNumber == checkedSeatNumber)
                        {
                            Console.WriteLine($"You are traveling to {location} on seats {currentMatch} and {checkedMatch}.");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine($"You are traveling to {location} on seats {matches[0]} and {matches[1]}.");
        }

        private static List<string> ValidTickets(string inputLine, string location)
        {
            var validTicketsStrings = new List<string>();
            var validTickets = new List<KeyValuePair<int, int>>();

            var brackets = new Stack<char>();
            var start = -1;
            var firstBracket = ' ';
            var valid = true;

            for (var i = 0; i < inputLine.Length; i++)
            {
                var currentChar = inputLine[i];

                if (currentChar == '{' || currentChar == '[')
                {
                    brackets.Push(currentChar);

                    if (firstBracket == currentChar)
                    {
                        valid = false;
                    }

                    if (start < 0)
                    {
                        start = i;
                        firstBracket = currentChar;
                    }
                }

                if (currentChar == '}')
                {
                    var openBracket = brackets.Pop();

                    if (openBracket != '{')
                    {
                        valid = false;
                    }

                    if (brackets.Count == 0)
                    {
                        if (valid)
                        {
                            validTickets.Add(new KeyValuePair<int, int>(start, i));
                        }

                        valid = true;
                        firstBracket = ' ';
                        start = -1;
                    }
                }

                if (currentChar == ']')
                {
                    var openBracket = brackets.Pop();

                    if (openBracket != '[')
                    {
                        valid = false;
                    }

                    if (brackets.Count == 0)
                    {
                        if (valid)
                        {
                            validTickets.Add(new KeyValuePair<int, int>(start, i));
                        }

                        valid = true;
                        firstBracket = ' ';
                        start = -1;
                    }
                }
            }

            foreach (var ticket in validTickets)
            {
                var startIndex = ticket.Key;
                var lenght = (ticket.Value - startIndex) + 1;

                var ticketString = inputLine.Substring(startIndex, lenght);
                validTicketsStrings.Add(ticketString);
            }

            for (var i = 0; i < validTicketsStrings.Count; i++)
            {
                if (!validTicketsStrings[i].Contains($"{{{location}}}") &&
                    !validTicketsStrings[i].Contains($"[{location}]"))
                {
                    validTicketsStrings.RemoveAt(i);
                }
            }

            return validTicketsStrings;
        }
    }
}
