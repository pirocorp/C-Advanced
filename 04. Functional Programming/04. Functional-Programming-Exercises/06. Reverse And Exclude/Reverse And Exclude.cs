namespace _06._Reverse_And_Exclude
{
    using System.Linq;
    using System;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var divisor = int.Parse(Console.ReadLine());

            Func<int, bool> operation = x => x % divisor != 0;
            Func<int[], int[]> reverse = ints => ints.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", reverse(numbers.Where(x => operation(x)).ToArray())));
        }
    }
}
