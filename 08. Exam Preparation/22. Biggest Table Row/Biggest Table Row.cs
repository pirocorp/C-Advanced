
using System.Collections.Generic;
using System.Linq;

namespace _22._Biggest_Table_Row
{
    using System;
    using System.Text.RegularExpressions;
    
    public class BiggestTableRow
    {
        public static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();

            const string numberPattern = "(-?(?:\\d+)(?:\\.\\d+)?)";
            var numberRegex = new Regex(numberPattern, RegexOptions.Compiled);

            var maxSum = double.MinValue;
            List<string> maxNumbers = null;

            while (inputLine != "</table>")
            {
                if (inputLine.Contains("<td>"))
                {
                    var currentNumbersMatches = numberRegex.Matches(inputLine);

                    var currentNumbers = new List<string>();
                    
                    foreach (Match match in currentNumbersMatches)
                    {
                        var currentValue = match.Value;

                        if (!string.IsNullOrEmpty(currentValue))
                        {
                            currentNumbers.Add(match.Value);
                        }
                    }

                    var currentSum = currentNumbers.Where(x => !string.IsNullOrEmpty(x)).Select(double.Parse).Sum();

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxNumbers = currentNumbers;
                    }
                }

                inputLine = Console.ReadLine();
            }

            if (maxNumbers.Count <= 0)
            {
                Console.WriteLine($"no data");
            }
            else
            {
                Console.WriteLine($"{maxSum} = {string.Join(" + ", maxNumbers)}");
            }
        }
    }
}
