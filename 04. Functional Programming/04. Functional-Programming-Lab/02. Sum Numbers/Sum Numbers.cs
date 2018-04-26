namespace _02._Sum_Numbers
{
    using System;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            Func<string, int> parser = n => int.Parse(n);

            var numbers = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
