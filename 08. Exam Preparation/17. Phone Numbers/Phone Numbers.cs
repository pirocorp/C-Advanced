using System.Text;

namespace _17._Phone_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class PhoneNumbers
    {
        public static void Main()
        {
            var listOfPhones = new List<KeyValuePair<string, string>>();

            var namePhonePairPattern = "(?<name>[A-Z][A-Za-z]*)(?<inBetween>[^a-zA-Z+]*?)(?<phone>[0-9+]((?<!\\+)[()\\/.\\- ]|[0-9])*[0-9])";
            var regex = new Regex(namePhonePairPattern, RegexOptions.Multiline);

            var sb = new StringBuilder();
            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                sb.AppendLine(inputLine);
                inputLine = Console.ReadLine();
            }

            var matches = regex.Matches(sb.ToString());

            foreach (Match match in matches)
            {
                var name = match.Groups["name"].Value;
                var phone = match.Groups["phone"].Value;

                phone = phone.Replace("(", string.Empty);
                phone = phone.Replace(")", string.Empty);
                phone = phone.Replace("/", string.Empty);
                phone = phone.Replace(".", string.Empty);
                phone = phone.Replace("-", string.Empty);
                phone = phone.Replace(" ", string.Empty);

                var currentKvp = new KeyValuePair<string, string>(name, phone);
                listOfPhones.Add(currentKvp);
            }

            if (listOfPhones.Count <= 0)
            {
                Console.WriteLine($"<p>No matches!</p>");
                return;
            }

            Console.Write($"<ol>");

            foreach (var kvp in listOfPhones)
            {
                var name = kvp.Key;
                var phone = kvp.Value;

                Console.Write($"<li><b>{name}:</b> {phone}</li>");
            }

            Console.Write($"</ol>");
        }
    }
}
