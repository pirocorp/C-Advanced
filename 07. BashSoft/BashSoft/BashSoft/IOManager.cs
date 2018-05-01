namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    public static class IOManager
    {
        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            var initialIdentation = path.Split('\\').Length;
            var subfolders = new Queue<string>();
            subfolders.Enqueue(path);

            while (subfolders.Count != 0)
            {
                //Dequeue the folder from the start of te queue
                var currentPath = subfolders.Dequeue();
                var identation = currentPath.Split('\\').Length - initialIdentation;

                //Print the folder path
                OutputWriter.WriteMessageOnNewLine(string.Format($"{new string('-', identation)}{currentPath}"));

                //Add all it's subfolders to the end of the queue
                foreach (var directoryPath in Directory.GetDirectories(currentPath))
                {
                    subfolders.Enqueue(directoryPath);
                }
            }
        }
    }
}
