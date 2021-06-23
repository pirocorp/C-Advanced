namespace _08._Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private static readonly Dictionary<string, string> contests = new Dictionary<string, string>();

        private static readonly Dictionary<string, User> users = new Dictionary<string, User>();

        public static void Main()
        {
            ReadContests();

            ReadContestsResults();

            PrintOutput();
        }

        private static void ReadContests()
        {
            string input;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var tokens = input.Split(":");

                var contest = tokens[0];
                var password = tokens[1];

                contests[contest] = password;
            }
        }

        private static void ReadContestsResults()
        {
            string input;

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var tokens = input.Split("=>");

                var contest = tokens[0];
                var password = tokens[1];
                var username = tokens[2];
                var points = int.Parse(tokens[3]);

                if (!contests.ContainsKey(contest) || contests[contest] != password)
                {
                    continue;
                }

                if (!users.ContainsKey(username))
                {
                    var user = new User(username);
                    users.Add(username, user);
                }

                if (!users[username].ContestResults.ContainsKey(contest))
                {
                    users[username].ContestResults[contest] = 0;
                }

                if (users[username].ContestResults[contest] < points)
                {
                    users[username].ContestResults[contest] = points;
                }
            }
        }

        private static void PrintOutput()
        {
            var best = users
                .Select(u => u.Value)
                .OrderByDescending(u => u.ContestResults.Sum(cr => cr.Value))
                .First();

            Console.WriteLine($"Best candidate is {best.Username} with total {best.ContestResults.Sum(c => c.Value)} points.");

            Console.WriteLine("Ranking: ");

            var ordered = users
                .Select(u => u.Value)
                .OrderBy(u => u.Username);

            foreach (var user in ordered)
            {
                Console.WriteLine(user.Username);

                foreach (var result in user.ContestResults.OrderByDescending(cr => cr.Value))
                {
                    Console.WriteLine($"#  {result.Key} -> {result.Value}");
                }
            }
        }

        private class User
        {
            public User(string username)
            {
                this.Username = username;

                this.ContestResults = new Dictionary<string, int>();
            }

            public string Username { get; set; }

            public Dictionary<string, int> ContestResults { get; set; }
        }
    }
}
