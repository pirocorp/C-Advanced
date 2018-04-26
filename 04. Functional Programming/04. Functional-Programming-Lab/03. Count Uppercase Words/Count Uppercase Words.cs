namespace _03._Count_Uppercase_Words
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            var wordsUpperCase = Console.ReadLine()
                .Split(new[] {" ", ", "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, wordsUpperCase));
        }
    }
}
