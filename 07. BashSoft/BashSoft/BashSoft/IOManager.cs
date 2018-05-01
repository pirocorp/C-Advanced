using System.ComponentModel.DataAnnotations;

namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            var path = GetCurrentDirectoryPath();
            OutputWriter.WriteEmptyLine();
            var initialIdentation = path.Split('\\').Length;
            var subfolders = new Queue<string>();
            subfolders.Enqueue(path);

            while (subfolders.Count != 0)
            {
                //Dequeue the folder from the start of te queue
                var currentPath = subfolders.Dequeue();
                var identation = currentPath.Split('\\').Length - initialIdentation;

                if (depth - identation < 0)
                {
                    break;
                }

                //Print the folder path
                OutputWriter.WriteMessageOnNewLine(string.Format($"{new string('-', identation)}{currentPath}"));

                //Display files in directory
                foreach (var file in Directory.GetFiles(currentPath))
                {
                    var indexOfLastSlash = file.LastIndexOf('\\');
                    var filename = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + filename);
                }

                //Add all it's subfolders to the end of the queue
                foreach (var directoryPath in Directory.GetDirectories(currentPath))
                {
                    subfolders.Enqueue(directoryPath);
                }
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            var path = GetCurrentDirectoryPath() + "\\" + name;
            Directory.CreateDirectory(path);
        }

        private static string GetCurrentDirectoryPath()
        {
            return SessionData.currentPath;
        }
    }
}
