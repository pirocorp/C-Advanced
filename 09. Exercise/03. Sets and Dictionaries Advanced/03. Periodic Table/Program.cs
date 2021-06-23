namespace _03._Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var set = new HashSet<string>();

            var n = int.Parse(Console.ReadLine() ?? "0");

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var token in tokens)
                {
                    set.Add(token);
                }
            }

            Console.WriteLine(string.Join(" ", set.OrderBy(x => x)));
        }
    }
}
