namespace _07._The_V_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml;

    public static class Program
    {
        private static readonly Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>(); 

        public static void Main()
        {
            string input;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var tokens = input.Split(" ");
                var name = tokens[0];
                var command = tokens[1];
                var argument = tokens[2];

                switch (command)
                {
                    case "joined":
                        RegisterVlogger(name);
                        break;
                    case "followed":
                        FollowVlogger(name, argument);
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var query = vloggers
                .Select(v => v.Value)
                .OrderByDescending(v => v.Followers.Count)
                .ThenBy(v => v.Following.Count);

            var best = query.First();
            var rest = query.Skip(1);

            var i = 1;

            Console.WriteLine($"{i++}. {best.Name} : {best.Followers.Count} followers, {best.Following.Count} following");

            foreach (var follower in best.Followers.OrderBy(x => x.Name))
            {
                Console.WriteLine($"*  {follower.Name}");
            }

            foreach (var vlogger in rest)
            {
                Console.WriteLine($"{i++}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
            }
        }

        private static void FollowVlogger(string vloggerName, string targetName)
        {
            if (vloggerName == targetName)
            {
                return;
            }

            if (!vloggers.ContainsKey(vloggerName) || !vloggers.ContainsKey(targetName))
            {
                return;
            }

            var vlogger = vloggers[vloggerName];
            var target = vloggers[targetName];

            vlogger.Following.Add(target);
            target.Followers.Add(vlogger);
        }

        private static void RegisterVlogger(string name)
        {
            if (!vloggers.ContainsKey(name))
            {
                var vlogger = new Vlogger(name);
                vloggers.Add(name, vlogger);
            }
        }

        private class Vlogger
        {
            public Vlogger(string name)
            {
                this.Name = name;
                this.Followers = new HashSet<Vlogger>();
                this.Following = new HashSet<Vlogger>();
            }

            public string Name { get; }

            public HashSet<Vlogger> Followers { get; }

            public HashSet<Vlogger> Following { get; }
        }
    }
}
