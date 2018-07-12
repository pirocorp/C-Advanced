namespace _41._Crypto_Blockchain
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;


    public class CryptoBlockchain
    {
        public static void Main()
        {
            const string cryptoBlockPattern = @"(?:(?<bracket>{)|\[)[^0-9]*(?<digits>\d*)[^0-9]*(?(bracket)}|\])";
            const string digitsPattern = "\\d{3,}";
            const string threesPattern = @"\d{3}";

            var n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (var i = 0; i < n; i++)
            {
                var currentInput = Console.ReadLine();

                sb.Append(currentInput);
            }

            var cryptoMatchCollection = Regex.Matches(sb.ToString(), cryptoBlockPattern);
            var cryptoBlocks = new List<string>();

            foreach (Match match in cryptoMatchCollection)
            {
                cryptoBlocks.Add(match.Value);
            }

            var result = new StringBuilder();

            for (var blockIndex = 0; blockIndex < cryptoBlocks.Count; blockIndex++)
            {
                var currentBlock = cryptoBlocks[blockIndex];
                var digitsInBlock = new List<string>();

                var digitsInBlockMatchCollection = Regex.Matches(currentBlock, digitsPattern);

                foreach (Match match in digitsInBlockMatchCollection)
                {
                    digitsInBlock.Add(match.Value);
                }

                var threes = digitsInBlock
                    .SelectMany(d =>
                    {
                        var threesMatches = Regex.Matches(d, threesPattern);
                        var threesSegmentList = new List<string>();

                        foreach (Match match in threesMatches)
                        {
                            threesSegmentList.Add(match.Value);
                        }

                        return threesSegmentList;
                    })
                    .Select(int.Parse)
                    .Select(d => d -= currentBlock.Length)
                    .Select(d => (char)d)
                    .ToArray();

                result.Append(threes);
            }

            Console.WriteLine(result);
        }
    }
}