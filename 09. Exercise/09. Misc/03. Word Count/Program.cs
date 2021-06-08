namespace _03._Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var words = ReadAllLines("./words.txt");
            var allWordsInText = NormalizeText().Split(" ");

            var occurrences = new Dictionary<string, int>();

            foreach (var word in words)
            {
                occurrences[word] = allWordsInText.Count(x => x.ToLower().Equals(word.ToLower()));
            }

            WriteToFile("../../../actualResult.txt", occurrences);
            WriteToFile("../../../expectedResult.txt", occurrences.OrderByDescending(x => x.Value));
        }

        private static string NormalizeText()
        {
            var text = ReadAllLines("./text.txt").ToList();

            var punctuation = new string[] {"-", ",", ".", "!", "?",}.ToList();

            for (var i = 0; i < text.Count; i++)
            {
                var line = text[i];
                punctuation.ForEach(p => line = line.Replace(p, null));
                text[i] = line;
            }

            return string.Join(" ", text);
        }

        private static IEnumerable<string> ReadAllLines(string path)
        {
            using var stream = new StreamReader(path);

            var lines = new List<string>();

            string line;

            while ((line = stream.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }

        private static void WriteToFile(string path, IEnumerable<KeyValuePair<string, int>> values)
        {
            using var writer = new StreamWriter(path);

            foreach (var kvp in values)
            {
                writer.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
