using System.IO.Compression;

namespace _06.Zipping_Sliced_Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            var parts = Slice("../../sliceMe.mp4", "../../", 5);
            Assemble(parts, "../../");
        }

        private static void Assemble(List<string> files, string destinationDir)
        {
            using (var ms = new MemoryStream())
            {
                for (var i = 0; i < files.Count; i++)
                {
                    var currentFilePath = files[i];

                    using (var sourceStream = new FileStream(currentFilePath, FileMode.Open))
                    {
                        using (var compressionStream = new GZipStream(sourceStream, CompressionMode.Decompress, false))
                        {
                            compressionStream.CopyTo(ms);
                        }
                    }
                }


                using (var destinationFileStream = new FileStream($"{destinationDir}output.avi", FileMode.Create))
                {
                    ms.Position = 0;
                    ms.CopyTo(destinationFileStream);
                }
            }
        }

        private static List<string> Slice(string sourceFile, string destinationDir, int parts)
        {
            var partsPaths = new List<string>();

            using (var sourceFileStream = new FileStream("../../sliceMe.mp4", FileMode.Open))
            {
                var fileLength = sourceFileStream.Length;

                var partSize = CalculatePartSize(fileLength);

                var buffer = new byte[4096];

                for (var i = 0; i < parts; i++)
                {
                    var currentPart = 1 + i;
                    var readBytes = -1;
                    var totalReadBytes = 0L;

                    var currentPath = $"{destinationDir}part{currentPart}.avi.gz";
                    partsPaths.Add(currentPath);

                    using (var destinationFileStream = new FileStream(currentPath, FileMode.Create))
                    {
                        using (var compressionStream = new GZipStream(destinationFileStream, CompressionMode.Compress, false))
                        {
                            while (totalReadBytes < partSize && (readBytes = sourceFileStream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                compressionStream.Write(buffer, 0, readBytes);

                                totalReadBytes += readBytes;

                                Console.WriteLine($"{Math.Min(sourceFileStream.Position / (double)fileLength, 1):P}");
                            }
                        }
                    }
                }
            }

            return partsPaths;
        }

        private static long CalculatePartSize(long fileLength)
        {
            var numberOfNeededBuffers = Math.Ceiling(fileLength / 4096M);

            var buffersPerPart = Math.Ceiling(numberOfNeededBuffers / 5M);

            return (long)(buffersPerPart * 4096);
        }
    }
}
