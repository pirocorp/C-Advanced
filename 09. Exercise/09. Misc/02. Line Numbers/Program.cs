namespace _02._Line_Numbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        private static int count = 1;

        public static void Main()
        {
            using var reader = new StreamReader("./text.txt");
            using var writer = new StreamWriter("../../../output.txt");

            var line = string.Empty;

            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(Process(line));
            }
        }

        private static string Process(string line)
        {
            var punctuation = new string[] { "-", ",", ".", "!", "?", "'" }.ToList();

            var punctuationsCount = line
                .Select(x => x.ToString())
                .Count(x => punctuation.Contains(x));

            var letterCount = line.Count(x => (x >= 'a' && x <= 'z') || (x >= 'A' && x <= 'Z'));

            return $"Line {count++}: {line} ({letterCount})({punctuationsCount})";
        }
    }
}
