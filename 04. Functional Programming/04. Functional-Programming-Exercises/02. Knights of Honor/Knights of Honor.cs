namespace _02._Knights_of_Honor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main(string[] args)
        {
            Action<string> printName = s => Console.WriteLine($"Sir {s}");

            Console.ReadLine()
                .Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printName);
        }
    }
}
