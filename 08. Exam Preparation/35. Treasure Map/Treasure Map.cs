namespace _35._Treasure_Map
{
    using System;
    using System.Text.RegularExpressions;

    public class TreasureMap
    {
       private const string ValidateInstructionPattern = "(!|#)[^!#]*?\\b(?<street>[A-Za-z]{4})\\b[^!#]*(?<!\\d)(?<number>\\d{3})-(?<password>\\d{6}|\\d{4})(?!\\d)[^!#]*?(?!\\1)(#|!)";

        public static void Main()
        {
            var instructionsRegex = new Regex(ValidateInstructionPattern, RegexOptions.Compiled);

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();
                var matches = instructionsRegex.Matches(inputLine);
                var currentInstructionIndex = matches.Count / 2;
                var currentInstruction = matches[currentInstructionIndex];
                PrintDataFromInstruction(currentInstruction);
            }
        }

        private static void PrintDataFromInstruction(Match match)
        {
            var streetName = match.Groups["street"].Value;
            var streetNumber = match.Groups["number"].Value;
            var password = match.Groups["password"].Value;
            Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
        }
    }
}
    