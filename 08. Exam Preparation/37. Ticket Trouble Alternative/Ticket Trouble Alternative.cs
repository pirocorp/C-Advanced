namespace _37._Ticket_Trouble_Alternative
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class TicketTroubleAlternative
    {
        public static void Main(string[] args)
        {
            var location = Console.ReadLine();

            var pattern = @"((?<opener>\[)|{)(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)" + location +
                             @"(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener){|\[)(?<seat>[A-Z][0-9]{1,2})(?(opener)}|\])(?(opener)[^\[\]]*?|[^{}]*?)(?(opener)\]|})";

            var input = Console.ReadLine();

            var matches = Regex.Matches(input, pattern);
            var seats = matches.Select(m => m.Groups["seat"].Value).ToArray();

            if (seats.Length > 2)
            {
                seats = seats.GroupBy(s => s.Substring(1))
                    .Where(g => g.Count() > 1)
                    .Select(g => g.ToArray())
                    .First();
            }

            Console.WriteLine($"You are traveling to {location} on seats {seats[0]} and {seats[1]}.");
        }
    }
}