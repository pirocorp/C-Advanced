using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _28._Regeh
{
    public class Regeh
    {
        public static void Main(string[] args)
        {
            const string pattern = "\\[(?:\\w+?)<(\\d+)REGEH(\\d+)>(?:\\w+?)\\]";
            var regex = new Regex(pattern, RegexOptions.Compiled);

            var numbers = new List<int>();

            var inputLine = Console.ReadLine();
            var matches = regex.Matches(inputLine);

            foreach (Match match in matches)
            {
                var numeberOne = int.Parse(match.Groups[1].Value);
                var numberTwo = int.Parse(match.Groups[2].Value);
                numbers.Add(numeberOne);
                numbers.Add(numberTwo);
            }

            var indexes = new int[numbers.Count];

            for (var i = 0; i < indexes.Length; i++)
            {
                indexes[i] = numbers.Take(i).Sum() + numbers[i];
            }

            indexes = indexes
                .Select(x => x % inputLine.Length)
                .ToArray();

            var characters = new char[indexes.Length];

            for (var index = 0; index < characters.Length; index++)
            {
                var currentIndex = indexes[index];
                var currentChar = inputLine[currentIndex];
                characters[index] = currentChar;
            }

            Console.WriteLine(new string(characters));
        }
    }
}
