namespace _04.Matching_Brackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var indexesOfOpeningBrackets = new Stack<int>();
            var results = new List<string>();

            for (var i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];

                if (currentChar == '(')
                {
                    indexesOfOpeningBrackets.Push(i);
                }

                if (currentChar == ')')
                {
                    var startIndex = indexesOfOpeningBrackets.Pop();
                    var endIndex = i;

                    var lenghtOfSubstring = (endIndex - startIndex) + 1;
                    var currentSubstring = input.Substring(startIndex, lenghtOfSubstring);

                    results.Add(currentSubstring);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, results));
        }
    }
}
