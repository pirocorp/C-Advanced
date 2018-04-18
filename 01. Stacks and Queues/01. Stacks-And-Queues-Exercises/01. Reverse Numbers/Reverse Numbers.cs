namespace _01.Reverse_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var stackNumbers = new Stack<int>(numbers);

            Console.WriteLine(String.Join(" ", stackNumbers));
        }
    }
}
