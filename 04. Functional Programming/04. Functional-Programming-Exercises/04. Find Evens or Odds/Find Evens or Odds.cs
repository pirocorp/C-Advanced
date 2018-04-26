using System.Collections.Generic;

namespace _04._Find_Evens_or_Odds
{
    using System;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main(string[] args)
        {
            var boundries = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var a = boundries[0];
            var b = boundries[1];

            var lowerBond = Math.Min(a, b);
            var upperBond = Math.Max(a, b);

            var filterCondition = Console.ReadLine();
            Func<int, bool> filter = GetFilterMethod(filterCondition);

            var listOfNumbers = new List<int>(upperBond - lowerBond);

            for (var i = lowerBond; i <= upperBond; i++)
            {
                listOfNumbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", listOfNumbers.Where(x => filter(x))));
        }

        private static Func<int, bool> GetFilterMethod(string filterCondition)
        {
            switch (filterCondition)
            {
                case "odd":
                    return x => Math.Abs(x % 2) == 1;
                case "even":
                    return x => x % 2 == 0;
                default:
                    return null;
            }
        }
    }   
}
