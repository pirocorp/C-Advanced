namespace SemantikHtml
{
    using System;
    using System.Text.RegularExpressions;

    public class SemantikHtml
    {
        public static void Main()
        {
            var row = Console.ReadLine();

            const string openTagPattern = @"<div(.*)(id|class)\s*=\s*""(\w+)""(.*)>";
            const string closeTagPattern = @"</div>(\s*<!--\s*(\w+)\s*-->)";

            while (row != "END")
            {
                if (Regex.IsMatch(row, openTagPattern))
                {
                    var matches = Regex.Match(row, @"(id|class)\s*=\s*""(\w+)""");
                    var tagName = matches.Groups[2].Value.Trim();
                    var before = matches.Groups[0].Value.Trim();
                    var result = row.Replace("div", tagName);
                    result = result.Replace(before, string.Empty);
                    result = Regex.Replace(result, "\\s+", " ");
                    result = result.Replace(" >", ">");
                    Console.WriteLine(result);


                }
                else if (Regex.IsMatch(row, closeTagPattern))
                {
                    var mathes = Regex.Match(row, closeTagPattern);
                    var tagname = mathes.Groups[2].Value;
                    var comment = mathes.Groups[1].Value;
                    var result = row.Replace(comment, "");
                    result = result.Replace("div", tagname);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine(row);
                }
                row = Console.ReadLine();
            }
        }
    }
}
