namespace _05._Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var directory = new DirectoryInfo("../../../../");

            var files = new Dictionary<string, List<string>>();

            foreach (var file in directory.EnumerateFiles())
            {
                if (!files.ContainsKey(file.Extension))
                {
                    files[file.Extension] = new List<string>();
                }

                files[file.Extension].Add($"{file.Name} - {(file.Length / 1024.0):F3}kb");
            }

            OutputData("../../../report.txt", files);
        }

        private static void OutputData(string path, Dictionary<string, List<string>> files)
        {
            using var writer = new StreamWriter(path);

            var ordered = files
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ToList();

            foreach (var kvp in ordered)
            {
                writer.WriteLine(kvp.Key);

                var orderedFiles = kvp.Value.OrderBy(f => f.Length).ToArray();

                foreach (var file in orderedFiles)
                {
                    writer.WriteLine($"--{file}");
                }
            }
        }
    }
}
