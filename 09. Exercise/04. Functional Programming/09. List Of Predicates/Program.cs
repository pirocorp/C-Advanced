namespace _09._List_Of_Predicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var endRange = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Distinct()
                .Select(int.Parse)
                .ToList();

            var predicates = GeneratePredicates(dividers);

            var resultNumbers = NewMethod(endRange, predicates);

            Console.WriteLine(string.Join(" ", resultNumbers));
        }

        private static List<Predicate<int>> GeneratePredicates(List<int> dividers)
        {
            var predicates = new List<Predicate<int>>();

            dividers.ForEach(d => predicates.Add(x => x % d == 0));

            return predicates;
        }

        private static List<int> NewMethod(int endRange, List<Predicate<int>> predicates)
        {
            var result = new List<int>();

            //Uses more RAM
            //for (var i = 1; i <= endRange; i++)
            //{
            //    var currentNumber = i;

            //    if (predicates.All(x => x(currentNumber)))
            //    {
            //        result.Add(currentNumber);
            //    }
            //}

            for (var i = 1; i <= endRange; i++)
            {
                var isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}