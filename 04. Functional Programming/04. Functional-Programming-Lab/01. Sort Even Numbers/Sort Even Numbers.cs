namespace _01._Sort_Even_Numbers
{
    using System;
    using System.Linq;

    public class SortEvenNumbers
    {
        public static void Main()
        {
            Func<int, bool> filter = n => n % 2 == 0;

            var numbers = Console.ReadLine()
                .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(filter)
                .OrderBy(n => n);

            var result = string.Join(", ", numbers);

            Console.WriteLine(result);
        }
    }
}
