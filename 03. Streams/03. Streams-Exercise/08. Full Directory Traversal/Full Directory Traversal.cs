namespace _08.Full_Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            var startPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());

            PrintAllFiles(startPath);
        }

        private static void PrintAllFiles(string path)
        {
            var directories = Directory.GetDirectories(path)
                .Where(x => !x.Contains("$"))
                .Where(x => !x.Contains("System Volume Information"));
            var files = Directory.GetFiles(path);

            //Console.Clear();
            //Console.SetCursorPosition(0, 0);
            Console.WriteLine(path);

            AppendAllFilesPerDirectoryToReportFile(files);

            foreach (var directory in directories)
            {
                PrintAllFiles(directory);
            }
        }

        private static void AppendAllFilesPerDirectoryToReportFile(string[] files)
        {
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
            desktopPath = $"{desktopPath}\\report.txt";

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
                    .Select(x => $"--{x.Key} - {x.Value / 1024M:F3}kb")
                    .ToArray();

                File.AppendAllText(desktopPath, $"{extension}{Environment.NewLine}");
                File.AppendAllLines(desktopPath, filesList);
            }
        }
    }
}
