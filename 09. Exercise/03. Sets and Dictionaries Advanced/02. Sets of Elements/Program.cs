namespace _02._Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var lengths = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var n = lengths[0];
            var m = lengths[1];

            var firstSet = new Dictionary<int, int>();
            var secondSet = new HashSet<int>();

            for (var order = 0; order < n; order++)
            {
                var num = int.Parse(Console.ReadLine());

                if (!firstSet.ContainsValue(num))
                {
                    firstSet.Add(order, num);
                }
            }

            for (var i = 0; i < m; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            var result = firstSet
                .OrderBy(x => x.Key)
                .Select(x => x.Value)
                .Where(x => secondSet.Contains(x));

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
