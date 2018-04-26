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

            Console.WriteLine(string.Join(" ", numbers.Where(x => operation(x)).Reverse()));

        }
    }
}
