namespace _07._Predicate_For_Names
{
    using System;
    using System.Linq;

    public class PredicateForNames  
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Func<string, bool> filter = x => x.Length <= n;

            Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => filter(x))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
