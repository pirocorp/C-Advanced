namespace _02.Line_Numbers
{
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            using (var streamReader = new StreamReader("../../text.txt"))
            {
                using (var streamWrither = new StreamWriter("../../output.txt"))
                {
                    var line = string.Empty;
                    var lineNumber = 1;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        streamWrither.WriteLine($"Line {lineNumber++}: {line}");
                    }
                }
            }
        }
    }
}
