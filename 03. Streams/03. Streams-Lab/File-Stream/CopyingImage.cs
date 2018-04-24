using System;
using System.IO;

public class CopyingImage
{
    const string SheepImagePath = "../../cat.jpg";
    const string DestinationPath = "../../result.jpg";

    public static void Main()
    {
        using (var source = new FileStream(SheepImagePath, FileMode.Open))
        {
            using (var destination = new FileStream(DestinationPath, FileMode.Create))
            {
                var fileLength = source.Length;
                var buffer = new byte[4096];

                while (true)
                {
                    var readBytes = source.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0)
                    {
                        break;
                    }

                    destination.Write(buffer, 0, readBytes);

                    Console.WriteLine("{0:P}", Math.Min(source.Position / (double)fileLength, 1));
                }
            }
        }
    }
}
