namespace _04.Copy_Binary_File
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            using (var readStream = new FileStream("../../copyMe.png", FileMode.Open))
            {
                using (var writeStream = new FileStream("../../output.png", FileMode.Create))
                {
                    var fileLength = readStream.Length;
                    var buffer = new byte[4096];

                    var readBytes = -1;

                    while ((readBytes = readStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writeStream.Write(buffer, 0, readBytes);

                        Console.WriteLine($"{Math.Min(readStream.Position / (double)fileLength, 1):P}");
                    }
                }
            }
        }
    }
} 
