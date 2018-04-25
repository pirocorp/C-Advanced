namespace _03.Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Text.RegularExpressions;


    public class Program
    {
        public static void Main()
        {
            var words = GetWordsFromFIle();

            var allText = GetAllTextFromFile().ToLower();

            var wordsCount = GetCountOfWords(words, allText)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            using (var writeResult = new StreamWriter("../../result.txt"))
            {
                foreach (var word in wordsCount)
                {
                    writeResult.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }

        private static Dictionary<string, int> GetCountOfWords(string[] words, string allText)
        {
            var wordsCount = new Dictionary<string, int>();

            //var pattern = "(?<word>[a-zA-Z']+)";
            //var regex = new Regex(pattern, RegexOptions.Compiled);

            //var allWordsInText = regex.Matches(allText)
            //    .Cast<Match>()
            //    .Select(x => x.Groups["word"].Value)
            //    .ToArray();

            for (var i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];

                var matches = Regex.Matches(allText, $"\\b{currentWord}\\b");

                wordsCount[currentWord] = matches.Count;
            }

            return wordsCount;
        }

        private static string GetAllTextFromFile()
        {
            var allText = string.Empty;
            var line = string.Empty;

            using (var readText = new StreamReader("../../text.txt"))
            {

                if ((line = readText.ReadLine()) != null)
                {
                    allText = line;
                }

                while ((line = readText.ReadLine()) != null)
                {
                    allText += $"{Environment.NewLine}{line}";
                }
            }

            return allText;
        }

        private static string[] GetWordsFromFIle()
        {
            var words = new List<string>();

            var word = string.Empty;

            using (var readWords = new StreamReader("../../words.txt"))
            {
                while ((word = readWords.ReadLine()) != null)
                {
                    words.Add(word);
                }
            }

            return words.ToArray();
        }
    }
}
