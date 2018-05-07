using System.Security.Cryptography;

namespace _18._Sum_Of_All_Values
{
    using System;
    using System.Text.RegularExpressions;
    using System.Text;

    public class SumOfAllValues
    {
        public static void Main()
        {
            var keysStringInput = Console.ReadLine();
            var textStringInput = Console.ReadLine();

            const string startKeyPattern = "^[a-zA-Z_]+(?=\\d)";
            const string endKeyPattern = "(?<=[0-9])[A-Za-z_]+$";

            var startKey = Regex.Match(keysStringInput, startKeyPattern).Groups[0].Value;
            var endKey = Regex.Match(keysStringInput, endKeyPattern).Groups[0].Value;

            if (string.IsNullOrEmpty(startKey) || string.IsNullOrEmpty(endKey))
            {
                Console.WriteLine($"<p>A key is missing</p>");
                return;
            }


            var stringExtractPattern = $"{startKey}(?<extract>.*?){endKey}";
            var matches = Regex.Matches(textStringInput, stringExtractPattern);

            const string numberPattern = "^(?<number>(?:\\d+)?(?:.\\d+)?)$";
            var sum = 0.0;

            foreach (Match match in matches)
            {
                var currentMatchValue = match.Groups["extract"].Value;

                if (Regex.IsMatch(currentMatchValue, numberPattern))
                {
                    sum += double.Parse(Regex.Match(currentMatchValue, numberPattern).Value);
                }
            }

            if (sum == 0)
            {
                Console.WriteLine($"<p>The total value is: <em>nothing</em></p>");
            }
            else
            {
                var sumString = string.Empty;

                if (Math.Round(sum) == Math.Round(sum, 2))
                {
                    sumString = $"{sum:F0}";
                }
                else
                {
                    sumString = $"{sum:F2}";
                }

                Console.WriteLine($"<p>The total value is: <em>{sumString}</em></p>");
            }
        }
    }
}
