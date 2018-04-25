namespace _07.Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            var files = Directory.GetFiles(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()));

            //var extensions = files
            //    .Where(x => x.LastIndexOf(".") >= 0)
            //    .Select(x =>
            //    {
            //        var index = x.IndexOf(".");
            //        return x.Substring(index, x.Length - index);
            //    })
            //    .Distinct()
            //    .OrderBy(x => x)
            //    .ToArray();

            var filesPerExtension = new Dictionary<string, List<string>>();

            for (var i = 0; i < files.Length; i++)
            {
                var currentFile = files[i];
                var index = currentFile.IndexOf(".");

                var currentExtension = string.Empty;

                if (index >= 0)
                {
                    currentExtension = currentFile.Substring(index, currentFile.Length - index);
                }

                if (!filesPerExtension.ContainsKey(currentExtension))
                {
                    filesPerExtension[currentExtension] = new List<string>();
                }

                filesPerExtension[currentExtension].Add(currentFile);
            }

            filesPerExtension = filesPerExtension
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var outputFile = new StreamWriter($"{desktopPath}\\report.txt"))
            {
                foreach (var extensionFiles in filesPerExtension)
                {
                    var extension = extensionFiles.Key;

                    var filesList = extensionFiles
                        .Value.Select(x =>
                        {
                            var fileInfo = new FileInfo(x);
                            var size = fileInfo.Length;
                            return new KeyValuePair<string, long>(x, size);
                        })
                        .OrderByDescending(x => x.Value)
                        .ToDictionary(x => x.Key, x => x.Value);

                    outputFile.WriteLine(extension);

                    foreach (var file in filesList)
                    {
                        outputFile.WriteLine($"--{file.Key} - {file.Value / 1024M:F3}kb");
                    }
                }
            }
        }
    }
}
