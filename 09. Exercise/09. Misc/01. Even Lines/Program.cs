namespace _01._Even_Lines
{
    using System;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            using var reader = new StreamReader("./text.txt");

            var i = 0;

            var line = string.Empty;

            while ((line = reader.ReadLine()) != null)
            { 
                if (i % 2 == 0)
                {
                    Console.WriteLine(Process(line));
                }

                i++;
            }
        }

        private static string Process(string input)
        {
            var strings = new string[] {"-", ",", ".", "!", "?"};

            foreach (var s in strings)
            {
                input = input.Replace(s, "@");
            }

            var words = input.Split(" ").Reverse();

            return string.Join(" ", words);
        }
    }
}
