namespace _0.Examples
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;

    public class Examples
    {
        public static void Main()
        {
            //ReadContentFromSourceFile();
            //ReverseLinesInFIle();
            //WritingTextToFile();
            //CopyingFile();
            //ReadInMemoryString();
            //SimpleWebServer();
        }

        private static void SimpleWebServer()
        {
            var tcpListener = new TcpListener(IPAddress.Any, 8080);
            tcpListener.Start();
            Console.WriteLine("Listening on port {0}...", 8080);

            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    var request = new byte[4096];
                    stream.Read(request, 0, 4096);
                    Console.WriteLine(Encoding.UTF8.GetString(request));

                    var html = string.Format("{0}{1}{2}{3} - {4}{2}{1}{0}",
                        "<html>", "<body>", "<h1>", "Welcome to my awesome site!", DateTime.Now);

                    var htmlBytes = Encoding.UTF8.GetBytes(html);
                    Console.WriteLine(html);
                    stream.Write(htmlBytes, 0, htmlBytes.Length);
                }
            }

        }

        private static void ReadInMemoryString()
        {
            var text = "In-memory text.";

            var bytes = Encoding.UTF8.GetBytes(text);

            using (var memoryStream = new MemoryStream(bytes))
            {
                while (true)
                {
                    var readByte = memoryStream.ReadByte();

                    if (readByte == -1)
                    {
                        break;
                    }

                    Console.WriteLine((char) readByte);
                }
            }
        }

        private static void CopyingFile()
        {
            using (var source = new FileStream("../../cat.jpg", FileMode.Open))
            {
                using (var destination = new FileStream("../../copyCat.jpg", FileMode.OpenOrCreate))
                {
                    while (true)
                    {
                        var buffer = new byte[4096];

                        var readBytes = source.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }

        private static void WritingTextToFile()
        {
            var text = "Кирилица";

            var fileStream = new FileStream(@"..\..\log.txt", FileMode.OpenOrCreate);

            try
            {
                var bytes = Encoding.UTF8.GetBytes(text);
                fileStream.Write(bytes, 0, bytes.Length);
            }
            finally 
            {
                fileStream.Close();
            }
        }

        private static void ReverseLinesInFIle()
        {
            using (var streamReader = new StreamReader(@"..\..\Examples.cs"))
            {
                using (var streamWriter = new StreamWriter(@"..\..\output.txt"))
                {
                    var line = string.Empty;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine(new string(line.Reverse().ToArray()));
                    }
                }
            }

        }

        private static void ReadContentFromSourceFile()
        {
            using (var stream = new StreamReader(@"..\..\Examples.cs"))
            {
                var line = string.Empty;
                var linesCount = 1;

                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine($"Line {linesCount}: {line}");
                    linesCount++;
                }
            }
        }
    }
}
