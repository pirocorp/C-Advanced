namespace _25._O__My_Girl_
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class OMyGirl
    {
        public static void Main()
        {
            var key = Console.ReadLine();
            var keyPattern = new StringBuilder();
            var result = new StringBuilder();

            if (!char.IsLetterOrDigit(key[0]))
            {
                keyPattern.Append($"\\{key[0]}");
            }
            else
            {
                keyPattern.Append(key[0]);
            }

            for (var strIndex = 1; strIndex < key.Length - 1; strIndex++)
            {
                var currentKeyCharacter = key[strIndex];

                if (char.IsDigit(currentKeyCharacter))
                {
                    keyPattern.Append("\\d*");
                }
                else if (char.IsUpper(currentKeyCharacter))
                {
                    keyPattern.Append("[A-Z]*");
                }
                else if (char.IsLower(currentKeyCharacter))
                {
                    keyPattern.Append("[a-z]*");
                }
                else
                {
                    keyPattern.Append($"\\{currentKeyCharacter}");
                }
            }

            if (!char.IsLetterOrDigit(key[key.Length - 1]))
            {
                keyPattern.Append($"\\{key[key.Length - 1]}");
            }
            else
            {
                keyPattern.Append(key[key.Length - 1]);
            }

            var regexPattern = $"(?:{keyPattern})(?<value>.{{2,6}})(?:{keyPattern})";
            var regex = new Regex(regexPattern);

            var inputLine = Console.ReadLine();
            var text = new StringBuilder();

            while (inputLine != "END")
            {
                text.Append(inputLine);
                inputLine = Console.ReadLine();
            }

            var matches = regex.Matches(text.ToString());

            foreach (Match item in matches)
            {
                result.Append(item.Groups["value"].Value);
            }

            Console.WriteLine(result);
        }
    }
}
