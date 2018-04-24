using System;
using System.IO;

public class StreamReaderDemo
{
    public static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader("../../somefile.txt"))
        {
            var lineNumber = 0;
            var line = reader.ReadLine();

            while (line != null)
            {
                lineNumber++;
                Console.WriteLine("Line {0}: {1}", lineNumber, line);
                line = reader.ReadLine();
            }
        }
    }
}
    