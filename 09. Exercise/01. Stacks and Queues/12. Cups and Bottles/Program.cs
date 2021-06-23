namespace _12._Cups_and_Bottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var cups = new Queue<int>(ReadSpaceSeparatedCollection<int>());

            var bottles = new Stack<int>(ReadSpaceSeparatedCollection<int>());

            var wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                var cup = cups.Dequeue();
                var bottle = 0;

                while (cup > 0)
                {
                    bottle = bottles.Pop();
                    var volume = Math.Min(cup, bottle);

                    cup -= volume;
                    bottle -= volume;
                }

                if (bottle > 0)
                {
                    wastedWater += bottle;
                }
            }

            if (!cups.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");

                return;
            }

            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        private static IEnumerable<T> ReadSpaceSeparatedCollection<T>()
            => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => (T)Convert.ChangeType(x, typeof(T)));
    }
}
