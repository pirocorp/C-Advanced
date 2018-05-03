namespace _09._Extract_Hyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;


    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var result = new StringBuilder();

            var input = Console.ReadLine();

            while (input != "END")
            {
                result.Append(input);
                result.Append(' ');
                input = Console.ReadLine();
            }

            var pattern = @"(?:<a)(?:[\s_0-9a-zA-Z=""()]*?.*?)(?:href([\s]*)?=(?:['""\s]*)?)(?<hyperlinks>[a-zA-Z:#\/._\-0-9!?=^+]*(\([""'a-zA-Z\s.()0-9]*\))?)(?:[\sa-zA-Z=""()0-9]*.*?)?(?:\>)";

            var regex = new Regex(pattern, RegexOptions.Compiled);

            var matches = regex.Matches(result.ToString());

            foreach (Match item in matches)
            {
                var value = item.Groups["hyperlinks"].Value;

                if (!value.Contains("fake"))
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
