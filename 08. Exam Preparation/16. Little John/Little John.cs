using System.Collections.Generic;

namespace _16._Little_John
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LittleJohn
    {
        private const string arrowPattern = "(>>>----->>)|(>>----->)|(>----->)";

        private static Regex regex = new Regex(arrowPattern, RegexOptions.Compiled);

        public static void Main()
        {
            var inputString = string.Empty;

            var large = 0;
            var medium = 0;
            var small = 0;

            for (var i = 0; i < 4; i++)
            {
                inputString = Console.ReadLine();

                var counters = CountStringOccurrences(inputString);

                small += counters[0];
                medium += counters[1];
                large += counters[2];
            }

            var decString = int.Parse($"{small}{medium}{large}");
            var binString = Convert.ToString(decString, 2);
            var reversedBin = new string(binString.Reverse().ToArray());
            var concatBin = binString + reversedBin;
            var result = Convert.ToInt32(concatBin, 2);

            Console.WriteLine(result);
        }

        private static int[] CountStringOccurrences(string inputString)
        {
            var matches = regex.Matches(inputString);
            
            var maxCount = 0;
            var medCount = 0;
            var minCount = 0;

            foreach (Match match in matches)
            {
                if (!string.IsNullOrEmpty(match.Groups[1].Value))
                {
                    maxCount++;
                }
                else if (!string.IsNullOrEmpty(match.Groups[2].Value))
                {
                    medCount++;
                }
                else
                {
                    minCount++;
                }
            }

            return new int[] { minCount, medCount, maxCount };
        }
    }
}
