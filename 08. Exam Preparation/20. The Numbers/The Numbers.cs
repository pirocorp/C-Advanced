namespace _20._The_Numbers
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class TheNumbers
    {
        public static void Main()
        {
            //core version
            var inputString = Console.ReadLine();

            const string numberPattern = "\\d+";

            var numbers = Regex.Matches(inputString, numberPattern)
                .Select(x => x.Groups[0].Value)
                .Select(int.Parse)
                .ToArray();

            var hexNumbers = numbers.Select(x => "0x" + x.ToString("X4"));

            Console.WriteLine($"{string.Join("-", hexNumbers)}");
        }

        // .Net Version
        //            var inputString = Console.ReadLine();

        //            const string numberPattern = "\\d+";

        //            var matches = Regex.Matches(inputString, numberPattern);
        //            var numbers = new int[matches.Count];

        //            for (var i = 0; i < matches.Count; i++)
        //            {
        //                numbers[i] = int.Parse(matches[i].Groups[0].Value);
        //            }

        //            var hexNumbers = numbers.Select(x => "0x" + x.ToString("X4"));

        //            Console.WriteLine($"{string.Join("-", hexNumbers)}");
    }
}
