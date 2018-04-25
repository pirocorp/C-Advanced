namespace _01.Odd_Lines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            using (var streamReader = new StreamReader("../../text.txt"))
            {
                var lineNumber = 0;
                var line = streamReader.ReadLine();

                while (line != null)
                {
                    if (lineNumber % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    line = streamReader.ReadLine();
                    lineNumber++;
                }
            }
        }
    }
}
