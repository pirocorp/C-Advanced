namespace WebCrawler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;


    public class HtmlParser
    {
        private const string ImgTagPattern = "<img.*?src=\"(?<imagePath>.*?)\".*?>";

        public static List<string> ParseImgTags(string html)
        {
            var regex = new Regex(ImgTagPattern, RegexOptions.Compiled);

            var matches = regex.Matches(html);

            return matches
                .Cast<Match>()
                .Select(m => m.Groups["imagePath"].Value)
                .ToList();
        }
    }
}
    