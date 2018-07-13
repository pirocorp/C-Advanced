namespace _41.Crypto_Blockchain_Althernative_.net_framework_
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CryptoBlockchain
    {
        public static void Main()
        {
            const string cryptoBlockPattern = @"(?:(?<bracket>{)|\[)[^0-9]*(?<digits>\d*)[^0-9]*(?(bracket)}|\])";
            const string threesPattern = @"\d{3}";

            var n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (var i = 0; i < n; i++)
            {
                var currentInput = Console.ReadLine();
                sb.Append(currentInput);
            }

            var matches = Regex.Matches(sb.ToString(), cryptoBlockPattern);

            var result = new StringBuilder();

            for (var blockIndex = 0; blockIndex < matches.Count; blockIndex++)
            {
                var currentMatch = matches[blockIndex];

                var currentDigits = currentMatch.Groups["digits"].Value;
                var currentBlockLenght = currentMatch.Value.Length;

                if (currentDigits.Length % 3 == 0)
                {
                    var threes = Regex.Matches(currentDigits, threesPattern)
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .Select(int.Parse)
                        .Select(x => x -= currentBlockLenght)
                        .Select(x => (char)x)
                        .ToArray();

                    result.Append(threes);
                }
            }

            Console.WriteLine(result);
        }
    }
}