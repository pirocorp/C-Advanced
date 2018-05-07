namespace _14._Uppercase_Words
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Security;

    public class UppercaseWords
    {
        public static void Main()
        {
            var pattern = "(?<![A-Za-z])(?<words>[A-Z]+)(?<after>[^A-Za-z]+|$)";
            var regex = new Regex(pattern);

            var result = new StringBuilder();

            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                var matches = regex.Matches(inputLine);

                inputLine = regex.Replace(inputLine, match =>
                {
                    var currentMatchValue = match.Groups["words"].Value;
                    var reversedCurrentMatchValue = new string(currentMatchValue.Reverse().ToArray());

                    if (currentMatchValue == reversedCurrentMatchValue)
                    {
                        var sb = new StringBuilder();

                        foreach (var character in currentMatchValue)
                        {
                            sb.Append(new string(character, 2));
                        }

                        return $"{sb.ToString()}{match.Groups["after"]}";
                    }
                    else
                    {
                        return $"{reversedCurrentMatchValue}{match.Groups["after"]}";
                    }
                });

                result.AppendLine(SecurityElement.Escape(inputLine));
                inputLine = Console.ReadLine();
            }

            Console.WriteLine(result);
        }
    }
}
